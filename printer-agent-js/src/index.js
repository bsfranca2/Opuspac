#!/usr/bin/env node
const { Command } = require("commander");
const print = require("./commands/print");
const connect = require("./commands/connect");

process.on("SIGINT", () => process.exit(0));
process.on("SIGTERM", () => process.exit(0));

function main() {
  const program = new Command()
    .name("printer-agent")
    .description(
      "Este programa conecta-se ao servidor e imprime documentos na impressora local a partir de instruções remotas."
    )
    .version("0.1.0");

  program.addCommand(print).addCommand(connect);

  program.parse();
}

main();
