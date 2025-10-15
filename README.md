# RhSensoERP

Protótipo inicial do sistema ERP de Recursos Humanos com backend ASP.NET Core Web API e frontend ASP.NET Core MVC utilizando Razor Views.

## Estrutura

```
src/
├── api/
│   └── RhSensoERP.Api/             # Web API com dados em memória
└── web/
    └── RhSensoERP.Web/             # Aplicação MVC consumindo a API
```

## Como executar

> O ambiente desta avaliação não possui o SDK .NET instalado. Para executar localmente, instale o [.NET SDK 8](https://dotnet.microsoft.com/pt-br/download).

1. Restaure os pacotes e compile as soluções:
   ```bash
   dotnet restore
   dotnet build
   ```
2. Suba a API:
   ```bash
   cd src/api/RhSensoERP.Api
   dotnet run
   ```
3. Em outro terminal, execute o frontend:
   ```bash
   cd src/web/RhSensoERP.Web
   dotnet run
   ```
4. Acesse `https://localhost:5001/swagger` para a documentação da API e `https://localhost:5002` para a interface web.

## Funcionalidades cobertas

- Autenticação simulada com token JWT fake
- Gestão de usuários com DataTables e modal de cadastro
- Gestão de grupos e permissões em listagem responsiva
- Módulo de funcionários com máscaras e indicadores de status
- Dashboard com KPIs e gráficos Chart.js consumindo dados da API

## Próximos passos sugeridos

- Implementar persistência real (SQL Server ou PostgreSQL)
- Adicionar autenticação JWT verdadeira e refresh tokens
- Cobrir casos de erro e validações avançadas
- Configurar testes unitários e de integração
- Integrar template completo do Inspinia e componentes adicionais
