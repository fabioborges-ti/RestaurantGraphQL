# Restaurant GraphQL API

Uma API GraphQL completa para sistema de gestão de restaurante, construída com ASP.NET Core, demonstrando arquitetura robusta e melhores práticas de desenvolvimento.

## 🚀 Características

- **API GraphQL**: Interface única e flexível para todas as operações
- **Arquitetura em Camadas**: Separação clara de responsabilidades
- **Entity Framework Core**: ORM moderno para persistência de dados
- **Hot Chocolate**: Framework GraphQL poderoso para .NET
- **SQL Server**: Banco de dados robusto e confiável

## 🏗️ Arquitetura do Projeto

O projeto segue uma arquitetura de camadas bem definida:

```
├── RestaurantGraphQL.API/          # Camada de Apresentação
│   ├── Schemas/                    # Esquemas GraphQL
│   ├── Queries/                    # Consultas GraphQL
│   └── Mutations/                  # Mutações GraphQL
│
├── RestaurantGraphQL.Core/         # Camada de Domínio
│   ├── Models/                     # Modelos de domínio
│   └── Interfaces/                 # Contratos dos repositórios
│
└── RestaurantGraphQL.Infrastructure/ # Camada de Infraestrutura
    ├── Data/                       # Contexto do banco de dados
    └── Repositories/               # Implementação dos repositórios
```

### Componentes Principais

- **RestaurantGraphQL.API**: Camada de apresentação que hospeda o servidor GraphQL
- **RestaurantGraphQL.Core**: Contém modelos de domínio (Menu, Reserva, Categoria) e interfaces
- **RestaurantGraphQL.Infrastructure**: Implementa repositórios usando Entity Framework Core

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core 8**: Framework principal da aplicação
- **GraphQL**: Linguagem de consulta de dados
- **HotChocolate**: Biblioteca GraphQL para .NET
- **Entity Framework Core**: ORM para gerenciamento do banco de dados
- **SQL Server**: Banco de dados relacional

## 📊 GraphQL vs RESTful

| Característica | GraphQL | RESTful |
|----------------|---------|---------|
| **Endpoints** | Único endpoint (`/graphql`) | Múltiplos endpoints (`/users`, `/posts`) |
| **Eficiência** | Busca exatamente os dados necessários | Pode resultar em over-fetching ou under-fetching |
| **Tipagem** | Fortemente tipado com sistema integrado | Tipagem fraca, estrutura fixa |
| **Requisições** | Uma única requisição para múltiplos recursos | Múltiplas requisições podem ser necessárias |

## 🚀 Como Executar

### Pré-requisitos

- .NET 8 SDK
- SQL Server (local ou remoto)
- Git

### Passos para Execução

1. **Clone o repositório:**
```bash
git clone https://github.com/fabioborges-ti/restaurantgraphql.git
cd restaurantgraphql
```

2. **Configure a conexão com o banco de dados:**

Edite o arquivo `src/RestaurantGraphQL.API/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=restauranteDb;Persist Security Info=True;User ID=sa;Password=#Br@sil10;Trust Server Certificate=True;"
  }
}
```

3. **Execute a aplicação:**
```bash
cd src/RestaurantGraphQL.API
dotnet run
```

4. **Acesse o GraphQL Playground:**

Navegue para: `https://localhost:7004/graphql`

> **Nota**: As migrações do Entity Framework são aplicadas automaticamente na inicialização.

## 📝 Exemplos de Uso

Todas as requisições são enviadas via **HTTP POST** para `https://localhost:7004/graphql`.

### 🔍 Consultas (Queries)

#### Listar Menus com Paginação e Ordenação
```graphql
query {
  menus(first: 10, order: { preco: DESC }) {
    nodes {
      id
      nome
      preco
      categoria {
        nome
      }
    }
  }
}
```

#### Obter Reserva por ID
```graphql
query {
  getReservaById(id: 1) {
    nomeCliente
    dataHora
    numeroPessoas
    observacoes
  }
}
```

### ✏️ Mutações (Mutations)

#### Adicionar Item ao Menu
```graphql
mutation {
  addMenu(input: {
    nome: "Pizza Pepperoni",
    descricao: "Tradicional pizza de pepperoni e queijo",
    preco: 45.50,
    categoriaId: 1
  }) {
    nome
    preco
  }
}
```

#### Atualizar Reserva
```graphql
mutation {
  updateReserva(
    id: 1,
    input: {
      nomeCliente: "João da Silva",
      numeroPessoas: 4,
      observacoes: "Mesa para 4 pessoas, preferência por mesa na janela."
    }
  ) {
    nomeCliente
    numeroPessoas
  }
}
```

#### Deletar Categoria
```graphql
mutation {
  deleteCategoria(id: 1)
}
```

## 🎯 Quando Usar GraphQL?

GraphQL é ideal para:

- **Aplicativos móveis**: Reduz o uso de dados e melhora a performance
- **Microsserviços**: Agrega dados de múltiplas fontes
- **Interfaces dinâmicas**: Permite flexibilidade na busca de dados
- **APIs públicas**: Oferece controle fino sobre os dados retornados

## 🤝 Contribuindo

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`)
3. Commit suas mudanças (`git commit -am 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/nova-feature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

**Fabio Borges**
- GitHub: [@fabioborges-ti](https://github.com/fabioborges-ti)

---

⭐ **Gostou do projeto? Deixe uma estrela!**