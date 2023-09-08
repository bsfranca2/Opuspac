const {
  ThermalPrinter,
  PrinterTypes,
  CharacterSet,
  BreakLine,
} = require("node-thermal-printer");
const { PrescriptionBuilder } = require("./prescription");

/**
 * @param {string} interface
 * @param {object} data
 */
async function print(interface, data) {
  const printer = new ThermalPrinter({
    type: PrinterTypes.EPSON,
    interface: interface,
    characterSet: CharacterSet.PC860_PORTUGUESE,
    removeSpecialCharacters: false, // Removes special characters - default: false
    lineCharacter: "-",
    breakLine: BreakLine.WORD, // Break line after WORD or CHARACTERS. Disabled with NONE - default: WORD
  });

  const isConnected = await printer.isPrinterConnected();
  console.log("Printer connected:", isConnected);

  const builder = new PrescriptionBuilder(printer)
    .addHeader(data.prescriptionCode)
    .addField("Paciente", data.patientName)
    .addField("Setor/Leito", data.patientBed)
    .addField("Atendimento", data.attendantId)
    .addNewLine()
    .addField("Horário", `${data.time}hrs`);
  for (const medicine of data.medicines) {
    builder.addMedicine(
      medicine.name,
      medicine.quantity,
      medicine.administrationInstructions
    );
  }
  builder.build();

  console.log(printer.getText());

  await printer.execute();
  console.log("Print success.");
}

module.exports = print;
