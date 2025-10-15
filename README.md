# RhSensoERP

Protótipo inicial do sistema ERP de Recursos Humanos com backend ASP.NET Core Web API e frontend ASP.NET Core MVC utilizando Razor Views.

> **Importante:** todo o backend está em memória para fins de demonstração. Não há persistência em banco de dados ou validação real de senha.

## Sumário

1. [Visão geral da solução](#visão-geral-da-solução)
2. [Requisitos de ambiente](#requisitos-de-ambiente)
3. [Arquitetura e portas utilizadas](#arquitetura-e-portas-utilizadas)
4. [Passo a passo de execução](#passo-a-passo-de-execução)
5. [Credenciais e dados de acesso](#credenciais-e-dados-de-acesso)
6. [Componentes principais](#componentes-principais)
7. [Próximos passos sugeridos](#próximos-passos-sugeridos)

## Visão geral da solução

O projeto é composto por dois serviços:

- **RhSensoERP.Api** – API REST em ASP.NET Core que expõe endpoints para autenticação, gestão de usuários, grupos, funcionários e dashboards, com dados mantidos em memória.
- **RhSensoERP.Web** – Aplicação ASP.NET Core MVC que consome a API e oferece as telas de autenticação e gestão via Razor Views.

## Requisitos de ambiente

- [.NET SDK 8](https://dotnet.microsoft.com/pt-br/download)
- Sistema operacional Windows, Linux ou macOS com suporte ao .NET 8
- Navegador moderno (Chrome, Edge, Firefox ou similar)

> O ambiente desta avaliação não possui o SDK .NET instalado. Instale os requisitos acima para executar localmente.

## Arquitetura e portas utilizadas

```
src/
├── api/
│   └── RhSensoERP.Api/             # Web API com dados em memória (porta HTTPS padrão 5001)
└── web/
    └── RhSensoERP.Web/             # Aplicação MVC consumindo a API (porta HTTPS padrão 5002)
```

- **RhSensoERP.Api**
  - HTTPS: `https://localhost:5001`
  - HTTP (quando habilitado): `http://localhost:5000`
  - Documentação Swagger: `https://localhost:5001/swagger`
- **RhSensoERP.Web**
  - HTTPS: `https://localhost:5002`
  - HTTP (quando habilitado): `http://localhost:5003`

Caso deseje alterar as portas, ajuste os arquivos `launchSettings.json` correspondentes em cada projeto.

## Passo a passo de execução

1. **Clonar o repositório**
   ```bash
   git clone <url-do-repositorio>
   cd projetorh
   ```
2. **Restaurar pacotes NuGet e compilar**
   ```bash
   dotnet restore
   dotnet build
   ```
3. **Subir a API (porta 5001)**
   ```bash
   cd src/api/RhSensoERP.Api
   dotnet run
   ```
4. **Subir o frontend MVC (porta 5002)**
   Em outro terminal:
   ```bash
   cd src/web/RhSensoERP.Web
   dotnet run
   ```
5. **Acessar os serviços**
   - API: `https://localhost:5001/swagger`
   - Frontend: `https://localhost:5002`

## Credenciais e dados de acesso

- **Login administrativo padrão**
  - Usuário: `admin@empresa.com`
  - Senha: qualquer valor (a verificação de senha ainda não foi implementada; o serviço aceita qualquer senha para o e-mail cadastrado)
  - Token: gerado dinamicamente como GUID codificado em Base64 com validade de 8 horas
- **Outros usuários**: apenas o usuário administrativo está pré-carregado. Novos usuários podem ser cadastrados via interface.
- **Banco de dados**: não há banco configurado. Todos os dados residem em `InMemoryDatabase` e são reinicializados a cada execução.

## Componentes principais

- **Autenticação**: `AuthService` gera tokens fake e não valida senha real.
- **Seed de dados**: `InMemoryDatabase` inicializa usuários, grupos e funcionários em memória.
- **Configuração do frontend**: `appsettings.json` define `Api:BaseUrl` para `https://localhost:5001/`.

## Próximos passos sugeridos

- Implementar persistência real (SQL Server ou PostgreSQL)
- Adicionar autenticação JWT verdadeira com verificação de senha e refresh tokens
- Cobrir casos de erro e validações avançadas
- Configurar testes unitários e de integração
- Integrar template completo do Inspinia e componentes adicionais
