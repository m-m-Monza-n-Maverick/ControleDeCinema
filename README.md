# Controle de Cinema
 
Com a necessidade de gerenciar melhor as vendas de ingressos do Cinema da Galera, foi proposto pelo dono do cinema, o
Sr. Jo�o do Nascimento, a cria��o de um sistema que auxilia no controle das vendas dos ingressos para os clientes que
desejam assistir os filmes e comer aquela pipoca nos finais de semana.

---

## Requisitos Funcionais:

- O cinema possui muitas salas sendo necess�rio, portanto, registrar informa��es a respeito de cada uma, como sua
capacidade; 

- O cinema apresenta tamb�m muitos filmes e um filme tem suas
informa��es mais importantes, como t�tulo, g�nero e dura��o. Ao chegar um lan�amento, os funcion�rios devem ter a possibilidade registrar no acervo do cinema;

- Um mesmo filme pode ser apresentado em salas e hor�rios diferentes, constituindo-se uma sess�o. Uma sess�o tem um
n�mero m�ximo de ingressos colocados � venda, determinado pela capacidade da sala onde a sess�o acontece;

- A venda de ingressos � intermediada por um funcion�rio do cinema. Um ingresso deve conter informa��es como o tipo de
ingresso (inteiro ou meio ingresso) e, al�m disso, um cliente s� pode comprar ingressos para sess�es ainda n�o
encerradas;

- O funcion�rio do cinema deve ser capaz de visualizar as sess�es do dia agrupados por filme, tanto as em andamento
quanto aquelas ainda por serem iniciadas;

- Atendendo � solicita��o de um cliente, o funcion�rio dever� efetuar a venda de um ou mais ingressos, obedecendo �
capacidade m�xima de cada sala;

- O sistema de Controle de Cinema deve possuir um m�dulo de cadastro, onde ser�o mantidas, no m�nimo, as sess�es. Este
m�dulo deve permitir a consulta, inclus�o, altera��o e remo��o de sess�es;

- O sistema deve apresentar os detalhes das sess�es, mostrando as poltronas dispon�veis e j� vendidas.

## Requisitos N�o Funcionais:

**Persist�ncia das informa��es**
- Os dados devem ser salvos e recuperados em banco de dados utilizando ORM.

**Arquitetural**
- Deve-se trabalhar utilizando o modelo de camadas.

**Qualidade**
- Deve-se criar testes automatizados para os componentes da aplica��o;
- Deve-se criar a documenta��o do projeto, prot�tipos, diagramas e README.

---

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.

---

## Como Usar

#### Clone o Reposit�rio
```
git clone https://github.com/m-m-Monza-n-Maverick/ControleDeCinema
```

#### Navegue at� a pasta raiz da solu��o
```
cd ControleDeCinema
```

#### Restaure as depend�ncias
```
dotnet restore
```

#### Navegue at� a pasta do projeto
```
cd ControleDeCinema.WebApp
```

#### Execute o projeto
```
dotnet run
```

#### Abra seu navegador
```
http://localhost:9000/sessoes/listar
```
