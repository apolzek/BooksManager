# API de Gerenciamento de Livro/Biblioteca

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/CaioTito/BooksManager/blob/master/LICENSE.txt)

Este é um projeto em C#, consiste em uma API de Gerenciamento de Livro/Biblioteca. A API utiliza o framework ASP.NET Core 8 e o banco de dados Microsoft SQL Server, utilizando Entity Framework como ORM.

A API conta com as seguintes **funcionalidades**:

**Gestão dos livros**
  
  Realizado a criação de endpoints utilizando padrão CQRS, de maneira a qual o Backoffice possa criar, editar, consultar e deletar livros, além de criar usuário, realizar login e criação de empréstimos.
  
**Disparo de e-mail diário para notificar os usuarios a respeito dos empréstimos de livros com vencimento próximo (3 dias).**
  
  Criado utilizando a biblioteca Quartz, roda um job em background todo dia as 08:00 e quando a aplicação é iniciada, onde é feita uma consulta e retornado todos empréstimos do usuario que estejam a menos de 03 dias do vencimento e são encaminhados para o e-mail do usuario, para notificação e atualização dos empréstimos. 
  
**Cobertura de 80% com testes unitários**

  Realizado a criação de projeto de testes unitários, utilizando xUnit, Moq e Bogus.

**Autorização e autenticação**

  Feito através de token JWT, existem duas roles a de Administrador e a de Cliente, contando com os endpoints de cadastro e login disponiveis, para possibilitar a criação do acesso.

**Validação de dados**

  Feito a validação de todos os dados de entrada dos parametros enviados nos endpoints, utilizando a biblioteca FluentValidations.
  
# Endpoints

http://localhost:5299/swagger/index.html

![image](https://github.com/CaioTito/BooksManager/assets/47333681/cc886ab8-8e8a-455a-b68d-d98ee1ec1ed8)

## Como executar o projeto
Para executar o projeto, siga as seguintes etapas:

1. Clone este repositório em sua máquina local usando o comando git clone `https://github.com/CaioTito/BooksManager.git`
2. Abra o projeto no Visual Studio ou em outra IDE de sua preferência.
3. Configure a string de conexão do banco de dados no arquivo `appsettings.Development.json`.
4. No Console do Gerenciador de Pacotes, execute o comando `Update-Database` para criar o banco de dados e suas tabelas.
5. Utilize um cliente SQL de sua preferencia e faça a conexão ao seu banco de dados local.
6. Compile o projeto e execute a aplicação.
7. Ao executar o  Swagger se abrirá automaticamente para que você possa testar os endpoints da API.

## Testes unitários

![image](https://github.com/CaioTito/BooksManager/assets/47333681/08f6a5fd-c958-4b37-8710-e2615360a2fb)
## local

```
export PATH="$PATH:/home/apolzek/.dotnet/tools"
dotnet ef database update
cd BooksManager.API/
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef database update -- --environment Development
docker run -d -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Pass@12345' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
http://localhost:5299/swagger/index.html
```
