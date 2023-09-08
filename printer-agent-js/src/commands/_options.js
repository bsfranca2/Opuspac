const { Option } = require("commander");
const { normalizeCom } = require("../utils");

const interfaceOption = new Option(
  "-i, --interface <interface>",
  "interface da conexão da impressora"
)
  .default("\\\\.\\COM2", "COM2") // "printer:EPSON TM-T20X Receipt";
  .argParser((value, previous) => {
    const currentValue = value ?? previous;
    if (currentValue.toLocaleLowerCase().includes("com")) {
      return normalizeCom(currentValue);
    }
    return currentValue;
  });

module.exports = {
  interfaceOption,
};
