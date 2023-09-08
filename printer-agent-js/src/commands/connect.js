const signalR = require("@microsoft/signalr");
const os = require("os");
const { Command } = require("commander");
const prompts = require("prompts");
const print = require("../printer/print");
const { PrintJobStatus } = require("../utils");
const { interfaceOption } = require("./_options");

const connect = new Command()
  .name("connect")
  .description("Estabelece conexão com o servidor.")
  .addOption(interfaceOption)
  .action(async (opts) => {
    let { server } = await prompts({
      type: "select",
      name: "server",
      message: "Deseja se conectar a qual servidor?",
      choices: [
        {
          title: "http://3.21.53.249 (Prod)",
          value: "http://3.21.53.249",
        },
        {
          title: "http://localhost:5091 (Local)",
          value: "http://localhost:5091",
        },
        {
          title: "Outro",
          value: null,
        },
      ],
    });
    if (server === null) {
      const { serverUrl } = await prompts({
        type: "text",
        name: "serverUrl",
        message: "Digite o servidor para se conectar:",
      });
      if (!serverUrl) {
        console.log("E necessário informar url do servidor");
        process.exit(1);
      }
      server = serverUrl;
    }

    const connection = new signalR.HubConnectionBuilder()
      .withUrl(`${server}/printer`, {
        headers: {
          "X-Agent-Name": os.hostname,
          "X-Printer-Model": "EPSON TM-T20X",
        },
      })
      .build();

    async function start() {
      try {
        await connection.start();
      } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
      }
    }

    connection.on("Print", async (message) => {
      try {
        console.log("Executando tarefa de impressão:", message.printJobId);
        await connection.invoke(
          "UpdatePrintJobStatus",
          message.printJobId,
          PrintJobStatus.Running
        );
        await print(opts.interface, message);
        await connection.invoke(
          "UpdatePrintJobStatus",
          message.printJobId,
          PrintJobStatus.Done
        );
      } catch (error) {
        console.log(error);
        console.log("Erro na tarefa: ", message.printJobId);
        await connection.invoke(
          "UpdatePrintJobStatus",
          message.printJobId,
          PrintJobStatus.Error
        );
      } finally {
        console.log("Tarefa de impressão finalizada:", message.printJobId);
      }
    });

    connection.onclose(async () => {
      await start();
    });

    start();
  });

module.exports = connect;
