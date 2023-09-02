using System.Globalization;
using Microsoft.PointOfService;

namespace Opuspac.Agent.Printer;

public class PrinterBarcode : IPrinter
{
    public async Task<bool> Print()
    {
        return true;
    }
    
// 	PosPrinter m_Printer = null;
// 	
//     public bool Print()
//     {
//         //<<<step2>>>--Start
// //Initialization
// DateTime nowDate = DateTime.Now;							//System date
// DateTimeFormatInfo dateFormat = new DateTimeFormatInfo();	//Date Format
// dateFormat.MonthDayPattern = "MMMM";
// string strDate = nowDate.ToString("MMMM,dd,yyyy  HH:mm",dateFormat);
// string strbcData = "4902720005074";
//
// try
// {
// 	//<<<step3>>>--Start
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"\u001b|1B");
// 	//<<<step3>>>--End
//
// 	//Print address
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"\u001b|N"
// 		+ "123xxstreet,xxxcity,xxxxstate\n");
//
// 	//Print phone number
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"\u001b|rA"
// 		+"TEL 9999-99-9999   C#2\n");
// 	//Print date
// 	//   \u001b|cA = Centaring char
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"\u001b|cA" + strDate + "\n\n");
// 	//Print buying goods
// 	m_Printer.PrintNormal(PrinterStation.Receipt, "apples                  $20.00\n");
//
// 	m_Printer.PrintNormal(PrinterStation.Receipt, "grapes                  $30.00\n");
//
// 	m_Printer.PrintNormal(PrinterStation.Receipt, "bananas                 $40.00\n");
//
// 	m_Printer.PrintNormal(PrinterStation.Receipt, "lemons                  $50.00\n");
//
// 	m_Printer.PrintNormal(PrinterStation.Receipt, "oranges                 $60.00\n\n");
//
// 	//Print the total cost
// 	//\u001b|bC = Bold
// 	//\u001b|uC = Underline
// 	//\u001b|2C = Wide charcter
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"\u001b|bC" 
// 		+ "Tax excluded.          $200.00" +  "\u001b|N\n");
//
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"\u001b|uC"
// 		+ "Tax  5.0%               $10.00" +  "\u001b|N\n");
//
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"\u001b|bC" +  "\u001b|2C" 
// 		+ "Total   $210.00" + "\u001b|N\n");
//
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"Customer's payment     $250.00\n");
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"Change                  $40.00\n\n");
//
// 	//<<<step4>>>--Start
// 	if(m_Printer.CapRecBarCode == true)
// 	{
// 		//Barcode printing
// 		m_Printer.PrintBarCode(PrinterStation.Receipt,strbcData,
// 			BarCodeSymbology.EanJan13,30,
// 			m_Printer.RecLineWidth,PosPrinter.PrinterBarCodeLeft,
// 			BarCodeTextPosition.Below);
// 	}	
// 	//<<<step4>>>--End
//
// 	m_Printer.PrintNormal(PrinterStation.Receipt,"\u001b|fP");
// 	//<<<step2>>>--End
// }
// catch(PosControlException)
// {
// }
// 		
//     }
}