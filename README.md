# Representantes

* RM 550687 Phablo Santos
* RM 551821 Lucas Serbato
* RM 552228 Vitor Teixeira
* RM 552364 Ronald de Oliveira
* RM 552466 Gustavo Carvalho




- Definir a arquitetura da API, explicando a escolha entre uma abordagem monolítica ou microservices

  Minha aplicação foi desenvolvida utilizando uma arquitetura monolítica, o que significa que todas as funcionalidades estão centralizadas em um único projeto que gerencia as diversas camadas, como as entidades, controladores, serviços, repositórios e o contexto de banco de dados. Abaixo estão os motivos e justificativas para essa escolha:

  Justificativa para a minha aplicação ser monolitica:
  1. Simplicidade e facilidade no desenvolvimento
     * A arquitetura monolítica é mais fácil de gerenciar em termos de desenvolvimento, especialmente em estágios iniciais do projeto, ou quando a equipe de desenvolvimento é pequena. Tudo está centralizado em um único código-base, o que facilita a integração entre diferentes partes do sistema.
     * Isso simplifica o fluxo de trabalho e permite que as equipes trabalhem de forma mais eficiente, sem precisar lidar com a complexidade de gerenciar múltiplos serviços independentes, como ocorre em uma arquitetura de microsserviços.
  2. Facilidade de Implantação:
     * A aplicação monolítica é implantada como uma única unidade. Não é necessário coordenar a implantação de vários serviços, o que reduz a complexidade de manter a aplicação em funcionamento. Isso é vantajoso em ambientes de desenvolvimento e produção mais simples, onde uma única instância da aplicação pode atender aos requisitos do sistema.
  3. Facilidade de Manutenção em Pequenos Projetos:
     * Para um projeto com escopo relativamente limitado, a arquitetura monolítica reduz a sobrecarga de gerenciamento que vem com a arquitetura de microsserviços, como a necessidade de orquestração e comunicação entre diferentes serviços. Isso é ideal para projetos que ainda estão evoluindo e não requerem alta escalabilidade imediata.
    
         
  - Design Patterns utilizado
    ![image](https://github.com/user-attachments/assets/e7685195-f307-4242-9c6a-13a1bdc905df)
    ![image](https://github.com/user-attachments/assets/b55762d0-bee1-4129-bef8-f44a99723cff)

## Funcionalidades Implementadas

- **Cadastro de Clientes**: Rota para cadastrar novos clientes.
- **Cadastro de Ramos**: Rota para associar um ramo a um cliente já existente.
- **Recomendação de Produtos**: Recurso de recomendação utilizando machine learning, que sugere produtos com base em características do cliente e do ramo.

## Estrutura do Projeto

- **Entidades**:
  - `ClienteEntity`: Representa o cliente no sistema.
  - `RamoEntity`: Representa o ramo de atuação de cada cliente.
- **Serviços**:
  - `ClienteApplicationService`: Gerencia a lógica de negócios relacionada a clientes.
- **Controladores**:
  - `ClienteController`: Controlador para gerenciar endpoints de clientes.
  - `RamoController`: Controlador para gerenciar endpoints de ramos.
  - `RecomendacaoController`: Controlador para recomendações baseadas em ML.
## Como Executar o Projeto

### Passo 1: Clonar o Repositório

```bash
git clone https://github.com/PhabloFiap/Challenge-Innov8Tech.git
cd Challenge-Innov8Tech

# Passo 2: Configurar o Banco de Dados Oracle
echo "Configure seu banco de dados Oracle editando o arquivo appsettings.json com suas credenciais."

# Passo 3: Restaurar as Dependências
echo "Restaurando dependências..."
dotnet restore

# Passo 4: Aplicar as Migrations
echo "Aplicando as migrations..."
dotnet ef database update

# Passo 5: Rodar a API
echo "Rodando a API..."
dotnet run

## Observações Adicionais

Este projeto também utiliza machine learning para recomendações. O modelo é treinado a partir de um CSV e salvo em um arquivo `.zip`. Certifique-se de que o arquivo `fictitious_client_data_no_address.csv` está na pasta de dados (`Data`) para o treinamento do modelo, se necessário.

# Instruções finais
echo "A API está rodando em http://localhost:5000"
echo "Use o Swagger para testar: http://localhost:5000/swagger"

