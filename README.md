
Este é um projeto de API para gerenciamento de reservas de voos, utilizando o **ASP.NET Core** com **Entity Framework Core** como ORM e **SQL Server** como banco de dados.

## Funcionalidades

A API permite a realização de operações de CRUD para voos, passageiros e reservas, além de funcionalidades específicas como check-in e geração de bilhetes eletrônicos. Abaixo estão as funcionalidades detalhadas:

### Voo (`Voo`)
- **GET /api/Voo**: Lista voos disponíveis com base nos critérios de origem, destino, data de embarque e data de retorno (se houver).
- **GET /api/Voo/{id}**: Obtém os detalhes de um voo específico pelo seu `id`.
- **POST /api/Voo**: Adiciona um novo voo.
- **PUT /api/Voo/{id}**: Atualiza os dados de um voo existente.
- **DELETE /api/Voo/{id}**: Remove um voo do sistema.

### Passageiro (`Passageiro`)
- **POST /api/Passageiro/cadastro**: Cadastra um novo passageiro informando os detalhes pessoais e o CPF.
- **GET /api/Passageiro/{cpf}**: Obtém os dados do passageiro pelo CPF.

### Reserva (`Reserva`)
- **POST /api/Reserva**: Cria uma nova reserva associada a um voo. Verifica se há assentos disponíveis e, em caso positivo, decrementa a quantidade de assentos.
- **GET /api/Reserva/{id}**: Obtém os detalhes de uma reserva específica pelo seu `id`.
- **DELETE /api/Reserva/{id}**: Cancela uma reserva e aumenta o número de assentos disponíveis no voo.
- **POST /api/Reserva/{id}/checkin**: Realiza o check-in de uma reserva, gerando o bilhete eletrônico.

## Configuração e Instalação

### Pré-requisitos
- .NET 6 SDK ou superior
- SQL Server
- Visual Studio ou Visual Studio Code

### Passos para Configuração do Banco de Dados

1. Instale o [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) e configure um banco de dados para a API.
2. Atualize o arquivo `appsettings.json` com sua string de conexão SQL Server.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO_DE_DADOS;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
```
3. Abra o terminal do NuGet Package Manager no Visual Studio e execute os seguintes comandos para aplicar as migrações e criar as tabelas no banco de dados:
  Add-Migration InitialCreate
  Update-Database

### Documentação
- Acesse o link para ver a documentação da API através do swagger: https://localhost:{PORT}/swagger/index.html.

### Autores
- Gabriel Cordeiro Alves, Diógenes Junior Lópes Dias De Souza, Caio Ramalho de Vasconcelos, Samuel Favero de Jesus, Gabriel de Jesus Souza Cesário , Eduardo Miranda de Freitas
