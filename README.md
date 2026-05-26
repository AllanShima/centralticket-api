# Escopo MVP da API do projeto "CentralTicket"

![escopo_centralticket-api drawio](https://private-user-images.githubusercontent.com/126991927/596448135-6dca769d-6c04-4b64-be96-f76042b3599e.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3Nzk4Mjk5NjIsIm5iZiI6MTc3OTgyOTY2MiwicGF0aCI6Ii8xMjY5OTE5MjcvNTk2NDQ4MTM1LTZkY2E3NjlkLTZjMDQtNGI2NC1iZTk2LWY3NjA0MmIzNTk5ZS5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjYwNTI2JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI2MDUyNlQyMTA3NDJaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT05NGNlNjk3YTg0MDFjMzZhZWY2NzRmYjI0ZjA1MDlhM2I0Y2RkNWMyMDllNDkxYmNmNTRlNmRhYTI3NDM1ODcwJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZyZXNwb25zZS1jb250ZW50LXR5cGU9aW1hZ2UlMkZwbmcifQ.q9Ta966weETtX4L--XmrxNB8Ae845b0m2m9wxc6fSvE)

API REST para venda e gerenciamento de ingressos, desenvolvida como projeto da matéria de Arquitetura e Organização de Softwares.

## Tecnologias

- .NET 10
- ASP.NET Core
- Entity Framework Core
- MySQL (Pomelo)
- JWT Bearer Authentication
- Scalar (documentação de API)

## Arquitetura

O projeto segue os princípios de Domain-Driven Design (DDD), organizado em Bounded Contexts independentes:

- **Auth** — cadastro, login e gerenciamento de tokens JWT
- **Billing** — vendas e emissão de ingressos
- **Profile** — dados de perfil do usuário

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [MySQL 8+](https://dev.mysql.com/downloads/)
- [EF Core CLI](https://learn.microsoft.com/ef/core/cli/dotnet)

```bash
dotnet tool install --global dotnet-ef
```

## Configuração

Clone o repositório e acesse a pasta do projeto:

```bash
git clone https://github.com/UInfinitu/centralticket-api.git
cd centralticket-api/CentralTicket
```

Edite o arquivo `appsettings.json` com suas credenciais:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1;Port=3306;Database=CentralTicketDb;User ID=root;Password=suasenha;"
  },
  "AppSettings": {
    "Token": "sua_chave_secreta_jwt_longa",
    "Issuer": "CentralTicket",
    "Audience": "CentralTicketUsers"
  }
}
```

## Banco de dados

Crie e aplique as migrations de cada contexto:

```bash
# Criar as migrations (apenas na primeira vez)
dotnet ef migrations add Init --context AuthDbContext --output-dir Contexts/Auth/Migrations
dotnet ef migrations add Init --context BillingDbContext --output-dir Contexts/Billing/Migrations
dotnet ef migrations add Init --context ProfileDbContext --output-dir Contexts/Profile/Migrations

# Aplicar ao banco
dotnet ef database update --context AuthDbContext
dotnet ef database update --context BillingDbContext
dotnet ef database update --context ProfileDbContext
```

Se as migrations já existirem no repositório, basta aplicar:

```bash
dotnet ef database update --context AuthDbContext
dotnet ef database update --context BillingDbContext
dotnet ef database update --context ProfileDbContext
```

## Executando

```bash
dotnet run
```

A API estará disponível em `http://localhost:5041`.

A documentação interativa (Scalar) pode ser acessada em:

```
http://localhost:5041/scalar
```
