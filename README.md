# Opuspac
O Opuspac é uma aplicação que permite a impressão de prescrições médicas utilizando a impressora Epson TM-T20x. Este projeto é composto por um backend escrito em C# e um frontend em Vue.js.
> Para uma resposta rápida sobre se o projeto é capaz de imprimir, você pode pular para a seção [Agente de Impressão](#agente-de-impressão). Certifique-se de atender aos [requisitos necessários](#requisitos).

## Requisitos
API
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download)

 Site
- [Node.js >=18](https://nodejs.org/en)

Agente de Impressão
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download)
- [.NET 4.8 SDK](https://dotnet.microsoft.com/download/dotnet-framework/net40)
- [StatusAPI for EPSON Advanced Printer Driver 6](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=7234&scat=31&pcat=3)
- [EPSON Advanced Printer Driver for TM-T20X](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=6695&scat=31&pcat=3)
- [POS for .NET v1.14.1](https://www.microsoft.com/en-US/download/details.aspx?id=55758)
- [EPSON OPOS ADK for .NET (for Microsoft .NET Framework 4.0 or later)](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=7289&scat=39&pcat=3)

## Estrutura 
![Fluxo do projeto](/docs/diagram.png)
- **Site:** Este é o painel administrativo do sistema.
- **Servidor:**  Executa as regras de negócios e expõe uma API REST.
- **Agente de Impressão:** Este programa é responsável por efetuar a impressão e se comunica com o servidor por meio de websocket. 

## Executando local
### Servidor e Site (Em andamento)
- Executar o servidor 
- Compilar o frontend

### Agente de Impressão
Antes de executar o Agente de Impressão, é necessário fazer duas configurações:
1. Configurar o driver da impressora, que pode ser encontrado no documento [APD6_Install_en_revC.pdf](/docs/APD_604_T20X_WM/APD6_Install_en_revC.pdf) que acompanha o instalador do EPSON Advanced Printer Driver for TM-T20X.
2. Configurar a impressora que está sendo utilizada pela SDK do .NET. Isso pode ser encontrado no arquivo [InstallManual.pdf](/docs/OPOSN1.14.27/InstallManual.pdf) que acompanha o EPSON OPOS ADK for .NET.

> Importante: Para evitar erros na execução, é necessário que o nome da impressora no `setupPos` seja `PosPrinter`

O motivo de precisar de duas SDKs diferentes é porque o POS for .NET tem compatibilidade apenas com .NET 4. Portanto, o projeto está organizado da seguinte forma:
- `./Opuspac.Agent` Projeto em .NET 7 que se comunica com o servidor. Quando recebe instruções de impressão, executa o executável em `./Opuspac.Printer`
- `./Opuspac.Printer` Projeto em .NET 4, responsável apenas pela impressão. O executável recebe como parâmetro o local do JSON com os dados da prescrição. [Exemplo do JSON.](/example-print-data.json)

Para verificar se a impressão está funcionando, você pode executar apenas  `./Opuspac.Printer`. Vou mostrar os comandos no terminal, mas recomendo o uso do Visual Studio.

1. Abra o terminal na pasta do projeto.
2. Restaure as dependências: `nuget.exe restore`
3. Compile: `MSBuild.exe .\Opuspac.Printer\Opuspac.Printer.csproj /p:Configuration=Release`
4. Execute: `.\Opuspac.Printer\bin\Release\Opuspac.Printer.exe .\example-print-data.json`
5. Se todos os passos foram concluídos corretamente até aqui, a impressão será realizada. Você pode personalizar os dados da impressão editando o arquivo passado como parâmetro, neste caso, `.\example-print-data.json`

Agora, para executar o `./Opuspac.Agent` e conectá-lo ao servidor:
1. Atualize o arquivo `./Opuspac.Agent/serversettings.json` com o local do compilado do `./Opuspac.Printer` que executamos anteriormente 
1. Abra o terminal na pasta do projeto.
2. Restaure as dependências: `dotnet restore`
3. Compile: `dotnet publish .\Opuspac.Agent\ --configuration Release`
4. Execute: `.\Opuspac.Agent\bin\Release\net7.0\Opuspac.Agent.exe connect`. Isso manterá uma conexão ativa com o servidor.
