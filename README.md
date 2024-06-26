
# Bem-vindo ao Sistema de Gestão de Portfólio de Investimentos!

Este sistema foi desenvolvido para facilitar a gestão de investimentos financeiros em uma empresa de consultoria, permitindo aos usuários realizar operações como compra, venda e consulta de investimentos de forma eficiente e segura.

## Funcionalidades Principais

* #### Gestão de Produtos Financeiros:
    * Cadastro, atualização e remoção de produtos disponíveis para investimento.

* #### Operações de Investimento:
    * Compra e venda de produtos financeiros.
    * Consulta de extrato detalhado de investimentos por cliente.

* #### Notificação Automatizada:
    * E-mails diários para administradores sobre produtos com vencimento próximo.

#### Tecnologias Utilizadas

* **Plataforma:** ASP.NET Core Web API
* **Linguagem:** C#
* **Framework:** .NET 6.0
* **ORM:** Entity Framework Core
* **Banco de Dados:** SQL Server
* **Serviços Adicionais:** Integração com serviço de e-mail para notificações automatizadas.

### Requisitos de Desempenho
O sistema foi projetado para suportar um grande volume de requisições, mantendo um tempo de resposta abaixo de 100ms nas operações principais de consulta e atualização de dados.

### Como Executar a Aplicação
Para executar o sistema localmente, siga estas etapas:

#### Setup.sh
* Foi criado um arquivo .sh onde caso prefira, pode ser executado.
Esse arquivo faz toda as instalações e executa as Migrations para o funcionamento adequado do projeto.
Obs: Lembrando que préviamente você deve configurar a aplicação passando as informações do seu banco de dados.
Para executar o arquivo pasta abri um CMD ou GitBash onde o arquivo se encontra, ou seja na raiz do projeto e colocar o seguinte comando:
```./setup.sh```

####  1. Pré-requisitos:
*  Instale o .NET SDK 6.0: [Download .Net](https://dotnet.microsoft.com/pt-br/download)
* Certifique-se de ter um servidor SQL Server disponível ou ajuste a string de conexão para um banco de dados local ou em nuvem.

#### 2. Configuração do Banco de Dados:
* Atualize a string de conexão no arquivo **appsettings.json** com suas credenciais do SQL Server.

#### 3. Executar Migrations:
* Abra um terminal na pasta raiz do projeto.
* Execute os comandos:
``` dotnet ef database update --project SeuProjeto.csproj```

#### 4. Executar a Aplicação:
* No terminal, execute: 
``` dotnet run --project SeuProjeto.csproj ```

#### 5. Acessar a API:
* Ao executar o projeto, você terá as seguinte opções de **endpoints**.
    - **Clients CRUD:**
        - Onde você poderá fazer o cadastro, consulta, atualização e exclusão de cliente.
    ![CRUD Clients](https://github.com/TNasci/PortfolioManagement/blob/master/PortfolioManagement/Img/Clients.PNG)
    - **Products CRUD:**
        - Onde você poderá fazer o cadastro, consulta, atualização e exclusão do seu produto.
    ![CRUD Products](https://github.com/TNasci/PortfolioManagement/blob/master/PortfolioManagement/Img/CrudProducts.PNG)
    
    - **BuyAndSellProducts:**
        - Onde você poderá, fazer a compra e venda do seu produto, além de fazer consulta todos os produtos por cliente e individualmente um produto e seu cliente.
    ![Buy And Sell Products](https://github.com/TNasci/PortfolioManagement/blob/master/PortfolioManagement/Img/BuyAndSellProducts.PNG)
    - **CreateRanDomMass:**
        - Caso não queira criar seus produtos um por um, temos a opção de gerar uma massa para teste, onde será criado **1000 produtos** aleatóriamente para conseguir executar os outros **endpoints**
    ![Create Random Mass](https://github.com/TNasci/PortfolioManagement/blob/master/PortfolioManagement/Img/createRandomMass.PNG)
    - **SendEmail**
        - **Endpoint** que tem a finalidade de fazer o envio de e-mail.
    ![Send Email](https://github.com/TNasci/PortfolioManagement/blob/master/PortfolioManagement/Img/SendEmail.PNG)
   Obs: Para o funcionamento adequado do envio de mensagens será necessário adicionar o seu email e senha no appsetting do projeto além de adicionar o email destinatário no serviço de email.

### Contribuições e Melhorias
Este projeto está em constante evolução. Se você deseja contribuir ou sugerir melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request no GitHub.

### Contato
Para mais informações ou suporte, entre em contato conosco em t.nascimento.work@gmail.com




