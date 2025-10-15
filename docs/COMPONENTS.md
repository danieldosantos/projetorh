# Guia de Componentes Reutilizáveis

## Frontend (RhSensoERP.Web)

### Layout Principal
- **Arquivo**: `Views/Shared/_Layout.cshtml`
- **Descrição**: Define o shell da aplicação com barra lateral fixa, cabeçalho com usuário autenticado e rodapé corporativo.
- **Tecnologias**: Bootstrap 5, Font Awesome, DataTables, Chart.js, SweetAlert2.

### Dashboard
- **Arquivo**: `Views/Home/Index.cshtml`
- **Descrição**: Consome o serviço `DashboardApiService` e renderiza KPIs e gráficos dinamicamente com Chart.js.

### DataTables
- **Usuários**: `Areas/SEG/Views/Usuarios/Index.cshtml`
- **Grupos**: `Areas/SEG/Views/Grupos/Index.cshtml`
- **Funcionários**: `Areas/RHU/Views/Funcionarios/Index.cshtml`

Cada tabela inicializa o DataTable com localização pt-BR e integrações com botões/modais conforme necessário.

### Serviços de API
- **Diretório**: `Services/`
- `ApiService`: HttpClient central com injeção do token do usuário
- Serviços específicos (`UsuarioApiService`, `GrupoApiService`, `FuncionarioApiService`, `DashboardApiService`) realizam chamadas tipadas para a API.

## Backend (RhSensoERP.Api)

### Banco em Memória
- `InMemoryDatabase`: Estrutura singleton com dados seed de usuários, grupos e funcionários.

### Serviços de Domínio
- `AuthService`, `UsuarioService`, `GrupoService`, `FuncionarioService`, `DashboardService` encapsulam regras simples de negócio.

### Controllers REST
- Disponíveis em `Controllers/` com endpoints RESTful padronizados (`api/auth`, `api/usuarios`, `api/grupos`, `api/funcionarios`, `api/dashboard`).

## Extensões Futuras
- Substituir seed in-memory por banco relacional.
- Introduzir TagHelpers específicos para permissões e componentes de formulário.
- Implementar versionamento de API e documentação avançada no Swagger.
