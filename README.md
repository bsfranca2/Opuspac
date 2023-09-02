# Opuspac
O Opuspac é uma aplicação que permite a impressão de prescrições médicas utilizando a impressora Epson TM-T20x. Este projeto é composto por um backend escrito em C# e um frontend em Vue.js.
> Para uma resposta rápida sobre se o projeto é capaz de imprimir, você pode pular para a seção [Agente de Impressão](#agente-de-impressão). Certifique-se de atender aos [requisitos necessários](#requisitos).

## Requisitos
Certifique-se de ter os seguintes requisitos instalados em seu ambiente antes de executar o Opuspac:
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download)
- [StatusAPI for EPSON Advanced Printer Driver 6](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=7234&scat=31&pcat=3)
- [EPSON Advanced Printer Driver for TM-T20X](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=6695&scat=31&pcat=3)
- [POS for .NET v1.14.1](https://www.microsoft.com/en-US/download/details.aspx?id=55758)
- [EPSON OPOS ADK for .NET (for Microsoft .NET Framework 4.0 or later)](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=7289&scat=39&pcat=3)

Opcional para o Agente de Impressão, porém necessário para compilar o site:
- [Node.js >=18](https://nodejs.org/en)

## Estrutura 
![Fluxo do projeto](/docs/diagram.png)
- **Site:** Este é o painel administrativo do sistema.
- **Servidor:**  Executa as regras de negócios e expõe uma API REST.
- **Agente de Impressão:** Este programa é responsável por efetuar a impressão e se comunica com o servidor por meio de websocket. 

## Agente de Impressão
### Configurar impressora setupPos
- Executar projeto em forma de teste: `dotnet run --project .\Opuspac.Agent\ print-test`
- Executar projeto se conectando com o servidor `dotnet run --project .\Opuspac.Agent\ connect <serverUri>`

## Servidor e Site
- Executar o servidor
- Compilar o frontend