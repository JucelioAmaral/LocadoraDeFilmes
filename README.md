# Locadora de Filmes

Api feita em .Net core 3.1 usando Dapper como Micro ORM, para consultas dos relatórios, Entity framework para persistencia e acesso ao banco de dados,
Swagger para documentação da Api, SQLServer como SGBD.
Front-End utilizando Vue.js.

## Pré requisitos

1. [Node.js](https://nodejs.org/en/download/)
2. [ASP.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
3. [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/)

## Como baixar o código

git clone https://github.com/JucelioAmaral/LocadoraDeFilmes.git

## Como configurar?

1. Abrir a solution;
2. Configurar o arquivo "appsettings.json" com a connectionString, apontando para o banco SQL server;
3. Abrir o Console do Visual Studio;
4. Executar o comando: Add-Migration InitialCreate;
5. Update-Database;
6. Executar a API pelo Visual Studio;

**API roda na porta https://localhost:5001/swagger/index.html**

## Como executar o client?

1. Abrir o CMD na pasta da solution;
2. cd LocadoraDeFilmes.app;
3. Execuatr no CMD o comando: npm install;
4. Execuatr no CMD o comando: npm run serve.

