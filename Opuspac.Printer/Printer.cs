using System;
using System.Collections.Generic;
using Microsoft.PointOfService;

namespace Opuspac.Printer
{
    internal class Printer : IDisposable
    {
        PosPrinter m_Printer = null;

        public Printer()
        {
            string strLogicalName = "PosPrinter";

            try
            {
                //Create PosExplorer
                PosExplorer posExplorer = new PosExplorer();

                DeviceInfo deviceInfo = null;

                try
                {
                    deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName);
                    m_Printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);
                }
                catch (Exception)
                {
                    // TODO: Melhorar tratamento?
                    return;
                }

                //Open the device
                m_Printer.Open();

                //Get the exclusive control right for the opened device.
                //Then the device is disable from other application.
                m_Printer.Claim(1000);

                //Enable the device.
                m_Printer.DeviceEnabled = true;

                //Output by the high quality mode
                m_Printer.RecLetterQuality = true;
            }
            catch (PosControlException)
            {
                // TODO: Melhorar tratamento?
                Console.WriteLine("Erro instanciando Printer");
            }
        }

        public bool Print(PrintData printData)
        {
            DateTime nowDate = DateTime.Now;
            string strDate = nowDate.ToString("dd/MM/yyyy HH:mm:ss");

            try
            {
                m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Transaction);
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|1B");

                m_Printer.PrintBarCode(PrinterStation.Receipt, printData.GetPresc(), BarCodeSymbology.QRCode, 150, 150, PosPrinter.PrinterBarCodeCenter, BarCodeTextPosition.None);
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|25uF");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "\u001b|bC" + $"Prescrição nº {printData.GetPresc()}\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|3uF");
                int iRecLineCharsCount = m_Printer.RecLineCharsList.Length;
                if (iRecLineCharsCount >= 2)
                {
                    m_Printer.RecLineChars = m_Printer.RecLineCharsList[1];
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + strDate + "\n");
                    m_Printer.RecLineChars = m_Printer.RecLineCharsList[0];
                }
                else
                {
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + strDate + "\n");
                }
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|25uF");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + "Paciente: ");
                m_Printer.PrintNormal(PrinterStation.Receipt, printData.PatientName.ToUpper() + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + "Setor/Leito: ");
                m_Printer.PrintNormal(PrinterStation.Receipt, printData.PatientBed.ToUpper() + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + "Atendimento: ");
                m_Printer.PrintNormal(PrinterStation.Receipt, printData.AttendantId.ToUpper() + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|20uF");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + "Horário: ");
                m_Printer.PrintNormal(PrinterStation.Receipt, $"{printData.Time}hrs" + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "------------------------------------------------" + "\n");


                foreach (var medicine in printData.Medicines)
                {
                    var quantity = medicine.Quantity.ToString().PadLeft(2, '0');
                    m_Printer.PrintNormal(PrinterStation.Receipt, $"{quantity}x {medicine.Name.ToUpper()}" + "\n");
                    if (iRecLineCharsCount >= 2)
                    {
                        m_Printer.RecLineChars = m_Printer.RecLineCharsList[1];
                        m_Printer.PrintNormal(PrinterStation.Receipt, medicine.AdministrationInstructions.ToUpper() + "\n");
                        m_Printer.RecLineChars = m_Printer.RecLineCharsList[0];
                    }
                    else
                    {
                        m_Printer.PrintNormal(PrinterStation.Receipt, medicine.AdministrationInstructions.ToUpper() + "\n");
                    };
                }

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");

                m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Normal);
            }
            catch (PosControlException)
            {
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            if (m_Printer != null)
            {
                try
                {
                    //Cancel the device
                    m_Printer.DeviceEnabled = false;

                    //Release the device exclusive control right.
                    m_Printer.Release();

                }
                catch (PosControlException)
                {
                }
                finally
                {
                    //Finish using the device.
                    m_Printer.Close();
                }
            }
        }
    }

    internal class PrintData
    {
        public string PrescriptionCode { get; set; }

        public string PatientName { get; set; }

        public string PatientBed { get; set; }

        public string AttendantId { get; set; }

        public string Time { get; set; }

        public List<Medicine> Medicines { get; set; }

        public string GetPresc()
        {
            return "PRESC1-" + PrescriptionCode;
        }
    }

    internal class Medicine
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string AdministrationInstructions { get; set; }
    }
}
