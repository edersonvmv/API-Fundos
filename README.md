# Case de engenharia Itau - .Net
##API .NET Core para gestão de fundos de investimento.

## Tecnologias

- **Linguagem & Framework**
  - .NET 8

- **Acesso a Dados**
  - Dapper
  - SQLite

- **Validações**
  - FluentValidation

- **Mapeamentos**
  - AutoMapper

- **Logs**
  - Serilog

- **Documentação**
  - Swagger

- **Autenticação**
  - JWT

- **Testes**
  - xUnit

## Projeto

- **API** → Controllers, Configs, Validators, ViewModels
- **Domain** → Services (regar de négocio), DTOs, Interfaces, Models, Notificacoes
- **Infra** → Repositories (Dapper, SQLite), Queries
- **Tests** → Domain (Tests), Attributes (NSubstitute)

## Introdução
Neste projeto esta sendo utilizada a base de dados sqlite (arquivo dbcaseitau S3db) com as seguintes tabelas:

    Tabela: TIPO_FUNDO > "Tipos de fundos existentes"
	- CODIGO      - INT         NOT NULL - PRIMARY KEY
	- NOME        - VARCHAR(20) NOT NULL

    Tabela: FUNDO > "Registro relacionados ao cadastro de fundos"
	- CODIGO      - VARCHAR(20)  UNIQUE NOT NULL - PRIMARY KEY
	- NOME        - VARCHAR(100)        NOT NULL
	- CNPJ        - VARCHAR(14)  UNIQUE NOT NULL
	- CODIGO_TIPO - INT                 NOT NULL - FOREIGN KEY TIPO_FUNDO(CODIGO)
	- PATRIMONIO  - NUMERIC                 NULL

> Obs.: você pode fazer o uso do [sqliteadmin] para gerenciar a base de dados, visualizar as tabelas e seus respectivos dados


## 🔑 Autenticação JWT

O projeto utiliza autenticação via JWT. Para autenticar, é necessário gerar um token de acesso. Você pode validar seu token [aqui](https://jwt.io).

	Para gerar o token, informe os seguintes parâmetros:

		- **Secret/Key**
		- **Issuer**
		- **Audience**
		- **Expiration Time**

Essas informações estão configuradas no arquivo `appsettings.json`.

**Exemplo de token:**

	  Secret: 9a5e95c2-5c13-4fbe-9a09-9733f8c88cf5e294848bd8e5b74e42928dc0b9230

	 Payload:   
   	 {
 	     "iss": "CaseItau",
  	     "aud": "CaseItau", 
  	     "exp": 1754078400
	 }

    
	![image](https://github.com/user-attachments/assets/26673de3-0543-4f02-976f-86fc1d86eece)
	![image](https://github.com/user-attachments/assets/b3411208-6f4d-45c7-ae41-0bffb3372866)
 	![image](https://github.com/user-attachments/assets/3089730c-458c-4f97-aaa9-5a8efe1ac152)


 	




