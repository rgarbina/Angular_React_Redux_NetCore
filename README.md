# Angular_React_Redux_NetCore
Pessoas
React Redux Saga / ASP.NET Core EF Core / SQL Server
Aplicacao com modelagem e aplicabilidade para Pessoas 
ASP.Net Core 3.1

Requisitos:
NodeJs, 
Microsoft SQL Server com login de autenticacao local,
NET Core 3.0 SDK

Instruções:
Aplicar os Scripts de Banco se encontracao na pasta data ou realizar o update-database com migrations.

Se atentar para o endereco do servidor backend.

Para quem utiliza Visual Studio 2019 abrir a solution e executar o projeto

para os demais ainda nao possivel:

Na pasta raiz do servidor back-end restuarar os pacotes com o comando
dotnet restore e apos dotnet watch run o servidor de API sera iniciado no endereco https://localhost:5001; http://localhost:5000.

para o servidor de aplicacao web cliente é necessario entrar na raiz da pasta ClienteApp
restaurar os pacotes do front com 
npm install
npm install typescript
e iniciar o servidor com npm start sera iniciado http://localhost:3000
em caso de mudanca de endereco do servidor backend redirecionar o endereco no arquivo src\actions\userActions.js

TODO:
resolver problema com cors rodar sem o visual studio 2019
Adicionar requisicao API para o CEP
Adicionar Funcionalidades e implementacoes pra outros modelos
Melhorar e Padronizar os Names e boas praticas no sistema
Melhorar Log e erros
Melhorar interface e revisar idioma
Estuadar e melhorar o aprendizado