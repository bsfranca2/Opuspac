const { Command } = require("commander");
const { fileToJson } = require("../utils");
const { interfaceOption } = require("./_options");

const print = new Command()
  .name("print")
  .description("Imprime uma página na impressora local.")
  .argument("<file>", "local do arquivo JSON da prescrição.")
  .addOption(interfaceOption)
  .action(async (file, opts) => {
    const prescriptionData = fileToJson(file);
    try {
      await print(opts.interface, prescriptionData);
    } catch (error) {
      console.error("Print error:", error);
      process.exit(1);
    }
  });

module.exports = print;
