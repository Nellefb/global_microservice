# **GS Web Engineering**

Um projeto de engenharia web que utiliza MongoDB e ASP.NET Core para gerenciar o consumo de energia. A aplicação permite adicionar, atualizar, listar e remover informações sobre consumo de energia utilizando um sistema de API RESTful.

## **Índice**
- [Visão Geral](#visão-geral)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Uso](#uso)
- [Endpoints da API](#endpoints-da-api)

## **Visão Geral**

GS Web Engineering é um projeto para gerenciar dados de consumo de energia elétrica. A aplicação foi desenvolvida para estudar o consumo e prover ferramentas para análise dos dados através de APIs RESTful utilizando ASP.NET Core e MongoDB. 

A arquitetura do sistema foi planejada para ser escalável e de fácil manutenção, utilizando um repositório de padrão com uma camada de serviço para lidar com a lógica de negócios.

## **Tecnologias Utilizadas**

As principais tecnologias usadas no projeto são:

- **ASP.NET Core** — Framework para construção da API RESTful.
- **MongoDB** — Banco de dados NoSQL para armazenar informações de consumo.
- **Redis** — Banco de dados Rdis para armazenar informações cache e melhorar performance.
- **Visual Studio 2022** — Ambiente de desenvolvimento para ASP.NET Core.
- **C#** — Linguagem de programação principal do projeto.
- **Swagger** — Documentação e teste da API.

## **Instalação**

Para rodar o projeto localmente, siga os passos abaixo:

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/seu_usuario/seu_projeto.git
   cd seu_projeto
   ```

2. **Instale as dependências:**

   Certifique-se de que você tenha o [.NET SDK](https://dotnet.microsoft.com/download) instalado.

   ```bash
   dotnet restore
   ```

3. **Configure o banco de dados MongoDB:**

   Certifique-se de que o MongoDB esteja instalado e rodando na sua máquina local. Você pode usar o seguinte comando para rodar o MongoDB:

   ```bash
   mongod
   ```

4. **Inicie a aplicação:**

   ```bash
   dotnet run
   ```

## **Configuração**

### **Banco de Dados**

Certifique-se de que o MongoDB está rodando na porta padrão `27017`. Se você precisar modificar a string de conexão, altere o valor na classe `ConsumoRepository.cs`:

```csharp
string connectionString = "mongodb://localhost:27017";
```

## **Uso**

Para testar a API, você pode usar o Swagger que já está integrado ao projeto. Após iniciar a aplicação, vá para:

```
http://localhost:5000/swagger
```

## **Endpoints da API**

### **Consumo**

#### **1. Listar Consumo**
- **Método**: GET
- **Endpoint**: `/api/consumo`
- **Descrição**: Retorna uma lista de todos os consumos cadastrados.
- **Exemplo de Resposta**:
  
  ```json
  [
    {
      "id": 0,
        "dataLeitura": "2024-11-22T23:57:36.507Z",
        "custo": 0,
        "consumoKWh": 0
    },
    ...
  ]
  ```

#### **2. Adicionar Consumo**
- **Método**: POST
- **Endpoint**: `/api/consumo`
- **Descrição**: Adiciona um novo registro de consumo.
- **Body**:
  
  ```json
  {
    "id": 0,
    "dataLeitura": "2024-11-22T23:57:36.510Z",
    "custo": 0,
    "consumoKWh": 0
  }
  ```

### **Health check**
- **Método**: GET
- **Endpoint**: `/api/consumo/health`
- **Descrição**: Retorna uma String sobre o status do serviço de consumo...
