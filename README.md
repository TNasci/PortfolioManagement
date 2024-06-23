Bem-vindo ao Sistema de Gestão de Portfólio de Investimentos!
Este sistema foi desenvolvido para facilitar a gestão de investimentos financeiros em uma empresa de consultoria, permitindo aos usuários realizar operações como compra, venda e consulta de investimentos de forma eficiente e segura.

Funcionalidades Principais
Gestão de Produtos Financeiros:

Cadastro, atualização e remoção de produtos disponíveis para investimento.
Operações de Investimento:

Compra e venda de produtos financeiros.
Consulta de extrato detalhado de investimentos por cliente.
Notificação Automatizada:

E-mails diários para administradores sobre produtos com vencimento próximo.
Tecnologias Utilizadas
Plataforma: ASP.NET Core Web API
Linguagem: C#
Framework: .NET 6.0
ORM: Entity Framework Core
Banco de Dados: SQL Server
Serviços Adicionais: Integração com serviço de e-mail para notificações automatizadas.
Requisitos de Desempenho
O sistema foi projetado para suportar um grande volume de requisições, mantendo um tempo de resposta abaixo de 100ms nas operações principais de consulta e atualização de dados.

Como Executar a Aplicação
Para executar o sistema localmente, siga estas etapas:

Pré-requisitos:

Instale o .NET SDK 6.0: Download .NET
Certifique-se de ter um servidor SQL Server disponível ou ajuste a string de conexão para um banco de dados local ou em nuvem.
Configuração do Banco de Dados:

Atualize a string de conexão no arquivo appsettings.json com suas credenciais do SQL Server.
Executar Migrations:

Abra um terminal na pasta raiz do projeto.
Execute os comandos:
bash
Copiar código
dotnet ef database update --project SeuProjeto.csproj
Executar a Aplicação:

No terminal, execute:
bash
Copiar código
dotnet run --project SeuProjeto.csproj
Acessar a API:

Acesse a API pelo navegador ou usando ferramentas como Postman:
Endpoint de produtos: GET /api/FinancialProducts
Endpoint de investimentos: GET /api/Investments/statement/{clientId}/{productId}
Endpoint de operações de compra/venda: POST /api/Investments/buy e POST /api/Investments/sell
Contribuições e Melhorias
Este projeto está em constante evolução. Se você deseja contribuir ou sugerir melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request no GitHub.

Contato
Para mais informações ou suporte, entre em contato conosco em email@empresa.com 
