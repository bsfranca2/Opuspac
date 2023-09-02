using Microsoft.PointOfService;

namespace Opuspac.Agent.Printer;

class Printer : IPrinter
{
    PosPrinter m_Printer = null;

    public void Load()
    {
        //Use a Logical Device Name which has been set on the SetupPOS.
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
                // TODO: Temporario
                Console.WriteLine("ChangeButtonStatus");
                return;
            }

            //Open the device
            m_Printer.Open();

            //Get the exclusive control right for the opened device.
            //Then the device is disable from other application.
            m_Printer.Claim(1000);

            //Enable the device.
            m_Printer.DeviceEnabled = true;
        }
        catch (PosControlException)
        {
            // TODO: Temporario
            Console.WriteLine("ChangeButtonStatus");
        }
    }

    public void Close()
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

    public async Task<bool> Print()
    {
        try
        {
            //As using the PrintNormal method, send strings to a printer, and print it
            //[\n] is the standard code for starting a new line.
            m_Printer.PrintNormal(PrinterStation.Receipt, "Hello OPOS for .Net\n");
        }
        catch (PosControlException)
        {
            return false;
        }

        return true;
    }
}
