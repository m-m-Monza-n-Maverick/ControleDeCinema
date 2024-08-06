# Controle de Bar
 
O Sr. Jo�o do Nascimento, propriet�rio do Bar da Galera, precisa controlar melhor o que cada cliente consumiu em seu estabelecimento, para consequentemente aumentar a produtividade e alavancar o sucesso do seu bar. A equipe do Bar da Galera precisa de mais agilidade na realiza��o das atividades e processos, e desta forma precisam de um sistema que ajude a controlar as quest�es financeiras do estabelecimento.

O programa proposto deve registrar o que os clientes consumiram, registrar o gar�om que atende as mesas e ao final do dia ser capaz de fornecer o valor faturado pelo restaurante.

Geralmente os clientes ficam localizados em suas mesas. Eles realizam seus pedidos e um gar�om registra o pedido na conta da mesa. Os pedidos podem ser adicionados e removidos de uma determinada conta. O total da conta � emitido para uma mesa espec�fica.

O sistema deve permitir a possibilidade de o Sr. Jo�o visualizar as contas que est�o abertas e o total faturado no dia. 

---

## Requisitos Funcionais:

- O sistema deve permitir que o gar�om registre os pedidos dos clientes em suas respectivas mesas.
- O sistema deve permitir a adi��o e remo��o de pedidos/produtos em uma determinada conta.
- O sistema deve gerar relat�rio di�rio de faturamento do restaurante.
- O sistema deve permitir que os funcion�rios cadastrem produtos.
- O sistema deve permitir que os funcion�rios cadastrem mesas.
- O sistema deve permitir que os funcion�rios cadastrem gar�ons.
- O sistema deve permitir visualizar as contas que est�o em aberto.
- O sistema deve permitir visualizar o total faturado no dia, na semana e no m�s.

## Requisitos N�o Funcionais:

**Persist�ncia das informa��es**
- Os dados devem ser salvos e recuperados em banco de dados utilizando ORM.

**Arquitetural**
- Deve-se trabalhar utilizando o modelo de camadas

**Interfaces com Usu�rio**
- A visualiza��o dos registros deve ser apresentada utilizando o componente DataGridView
- As telas de cadastro devem aparecer centralizadas
- N�o deve permitir redimensionar telas de cadastro
- N�o deve permitir minimizar ou maximizar telas de cadastro
- As telas de cadastro devem ser dialogs
- As telas de cadastro devem ter um t�tulo
- Os elementos das telas de cadastro devem seguir um padr�o de posicionamento
- Os elementos das telas de cadastro devem estar alinhados
- O nome do sistema deve ser apresentado na tela principal
- As notifica��es para usu�rio devem ser apresentadas seguindo um padr�o
- As telas de cadastro devem ter uma op��o que fecha a janela e n�o grava as altera��es
- As telas de cadastro devem ter uma op��o que grava as altera��es
- A tabula��o dos campos deve seguir uma sequ�ncia l�gica iniciando pelos campos superiores
- As altera��es realizadas devem ser gravadas e devem manter uma refer�ncia �nica em todas as telas
- As telas de listagem devem permitir selecionar apenas um registro

---

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.

---

## Como Usar

#### Clone o Reposit�rio
```
git clone https://github.com/academia-do-programador/controle-de-bar--2024.git
```

#### Navegue at� a pasta raiz da solu��o
```
cd controle-de-bar--2024
```

#### Restaure as depend�ncias
```
dotnet restore
```

#### Navegue at� a pasta do projeto
```
cd ControleDeBar.WinApp
```

#### Execute o projeto
```
dotnet run
```
