# Controle de Bar
 
O Sr. João do Nascimento, proprietário do Bar da Galera, precisa controlar melhor o que cada cliente consumiu em seu estabelecimento, para consequentemente aumentar a produtividade e alavancar o sucesso do seu bar. A equipe do Bar da Galera precisa de mais agilidade na realização das atividades e processos, e desta forma precisam de um sistema que ajude a controlar as questões financeiras do estabelecimento.

O programa proposto deve registrar o que os clientes consumiram, registrar o garçom que atende as mesas e ao final do dia ser capaz de fornecer o valor faturado pelo restaurante.

Geralmente os clientes ficam localizados em suas mesas. Eles realizam seus pedidos e um garçom registra o pedido na conta da mesa. Os pedidos podem ser adicionados e removidos de uma determinada conta. O total da conta é emitido para uma mesa específica.

O sistema deve permitir a possibilidade de o Sr. João visualizar as contas que estão abertas e o total faturado no dia. 

---

## Requisitos Funcionais:

- O sistema deve permitir que o garçom registre os pedidos dos clientes em suas respectivas mesas.
- O sistema deve permitir a adição e remoção de pedidos/produtos em uma determinada conta.
- O sistema deve gerar relatório diário de faturamento do restaurante.
- O sistema deve permitir que os funcionários cadastrem produtos.
- O sistema deve permitir que os funcionários cadastrem mesas.
- O sistema deve permitir que os funcionários cadastrem garçons.
- O sistema deve permitir visualizar as contas que estão em aberto.
- O sistema deve permitir visualizar o total faturado no dia, na semana e no mês.

## Requisitos Não Funcionais:

**Persistência das informações**
- Os dados devem ser salvos e recuperados em banco de dados utilizando ORM.

**Arquitetural**
- Deve-se trabalhar utilizando o modelo de camadas

**Interfaces com Usuário**
- A visualização dos registros deve ser apresentada utilizando o componente DataGridView
- As telas de cadastro devem aparecer centralizadas
- Não deve permitir redimensionar telas de cadastro
- Não deve permitir minimizar ou maximizar telas de cadastro
- As telas de cadastro devem ser dialogs
- As telas de cadastro devem ter um título
- Os elementos das telas de cadastro devem seguir um padrão de posicionamento
- Os elementos das telas de cadastro devem estar alinhados
- O nome do sistema deve ser apresentado na tela principal
- As notificações para usuário devem ser apresentadas seguindo um padrão
- As telas de cadastro devem ter uma opção que fecha a janela e não grava as alterações
- As telas de cadastro devem ter uma opção que grava as alterações
- A tabulação dos campos deve seguir uma sequência lógica iniciando pelos campos superiores
- As alterações realizadas devem ser gravadas e devem manter uma referência única em todas as telas
- As telas de listagem devem permitir selecionar apenas um registro

---

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

---

## Como Usar

#### Clone o Repositório
```
git clone https://github.com/academia-do-programador/controle-de-bar--2024.git
```

#### Navegue até a pasta raiz da solução
```
cd controle-de-bar--2024
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd ControleDeBar.WinApp
```

#### Execute o projeto
```
dotnet run
```
