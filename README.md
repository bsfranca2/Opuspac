# Opuspac

O Opuspac é uma aplicação que permite a impressão de prescrições médicas utilizando a impressora Epson TM-T20x. Este projeto é composto por um backend escrito em C# e um frontend em Vue.js.

> Para uma resposta rápida sobre se o projeto é capaz de imprimir, você pode pular para a seção [Agente de Impressão](#agente-de-impressão). Certifique-se de atender aos [requisitos necessários](#requisitos).

## Requisitos

- [StatusAPI for EPSON Advanced Printer Driver 6](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=7234&scat=31&pcat=3)
- [EPSON Advanced Printer Driver for TM-T20X](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=6695&scat=31&pcat=3)
- [TM Virtual Port Driver](https://download.epson-biz.com/modules/pos/index.php?page=single_soft&cid=6919&scat=36&pcat=3)

## Estrutura

![Fluxo do projeto](/docs/diagram.png)

- **Site:** Este é o painel administrativo do sistema.
- **Servidor:** Executa as regras de negócios e expõe uma API REST.
- **Agente de Impressão:** Este programa é responsável por efetuar a impressão e se comunica com o servidor por meio de websocket.

## Executando

### .NET

Você pode acessar a versão do agente em .NET em [/docs/local.md](/docs/local.md)

> Observação: Você pode conferir a versão anterior do README.md na tag [v0.1](https://github.com/bsfranca2/Opuspac/tree/v0.1)

### Site e Servidor

- **Website:** [https://opuspac.vercel.app](https://opuspac.vercel.app)
- **Api:** [https://vmiho9xjf9.execute-api.us-east-2.amazonaws.com/prod/](https://vmiho9xjf9.execute-api.us-east-2.amazonaws.com/prod/)

### Agente de Impressão

Antes de executar o Agente de Impressão, é necessário fazer uma ou duas configurações:

1. Configurar o driver da impressora, que pode ser encontrado no documento [APD6_Install_en_revC.pdf](/docs/APD_604_T20X_WM/APD6_Install_en_revC.pdf) que acompanha o instalador do EPSON Advanced Printer Driver for TM-T20X.
2. Caso sua impressora esteja conectada usando a porta COM, você pode ignorar essa etapa, pois o agente atual utiliza a porta COM para enviar comandos ESC/POS. Após a instalação do TM Virtual Port Driver, abra-o, selecione COM2 e pressione "Assign Port"; por fim, selecione sua impressora.

> Observacao: Não é difícil disponibilizar a impressão com portas USB. No momento, o pacote do Node.js de impressoras feito pela comunidade (não é oficial) está desatualizado.

> Observacao: É possível fazer a mesma coisa com .NET, não é necessário todas aquelas dependências. Eu vi alguns pacotes que fazem algo parecido com o agente em Node.js, mas tive problemas com a versão .NET. O pior cenário seria não encontrar nenhuma compatível e precisar criar uma biblioteca para executar comandos ESC/POS, o que não seria difícil, pois é possível utilizar até mesmo bibliotecas de outras linguagens como referência de comandos.

Para verificar se a impressão está funcionando:

1. Baixe o executável [aqui](https://github.com/bsfranca2/Opuspac/releases/download/v0.2/printer-agent.exe). O motivo de ter 48MB é porque já vem com o Node.js embutido.
2. Com o terminal aberto no mesmo local do executável, execute`.\printer-agent.exe`,
3. Se estiver funcionando corretamente, ele listará as opções disponíveis do programa.

O programa tem dois comandos

1. `.\printer-agent.exe print <arquivo>` Caminho do arquivo JSON com os dados da prescrição. [JSON de exemplo](/example-print-data.json)
2. `.\printer-agent.exe connect` Comando para se conectar ao servidor e escutar por tarefas de impressão.

### Bugs

Quando é realizada a tarefa de imprimir e a impressora não está conectada, está aparecendo a mensagem de sucesso, mesmo sendo o inverso.
