# Controle de Cinema
 
Com a necessidade de gerenciar melhor as vendas de ingressos do Cinema da Galera, foi proposto pelo dono do cinema, o
Sr. João do Nascimento, a criação de um sistema que auxilia no controle das vendas dos ingressos para os clientes que
desejam assistir os filmes e comer aquela pipoca nos finais de semana.

---

## Requisitos Funcionais:

- O cinema possui muitas salas sendo necessário, portanto, registrar informações a respeito de cada uma, como sua
capacidade; 

- O cinema apresenta também muitos filmes e um filme tem suas
informações mais importantes, como título, gênero e duração. Ao chegar um lançamento, os funcionários devem ter a possibilidade registrar no acervo do cinema;

- Um mesmo filme pode ser apresentado em salas e horários diferentes, constituindo-se uma sessão. Uma sessão tem um
número máximo de ingressos colocados à venda, determinado pela capacidade da sala onde a sessão acontece;

- A venda de ingressos é intermediada por um funcionário do cinema. Um ingresso deve conter informações como o tipo de
ingresso (inteiro ou meio ingresso) e, além disso, um cliente só pode comprar ingressos para sessões ainda não
encerradas;

- O funcionário do cinema deve ser capaz de visualizar as sessões do dia agrupados por filme, tanto as em andamento
quanto aquelas ainda por serem iniciadas;

- Atendendo à solicitação de um cliente, o funcionário deverá efetuar a venda de um ou mais ingressos, obedecendo à
capacidade máxima de cada sala;

- O sistema de Controle de Cinema deve possuir um módulo de cadastro, onde serão mantidas, no mínimo, as sessões. Este
módulo deve permitir a consulta, inclusão, alteração e remoção de sessões;

- O sistema deve apresentar os detalhes das sessões, mostrando as poltronas disponíveis e já vendidas.

## Requisitos Não Funcionais:

**Persistência das informações**
- Os dados devem ser salvos e recuperados em banco de dados utilizando ORM.

**Arquitetural**
- Deve-se trabalhar utilizando o modelo de camadas.

**Qualidade**
- Deve-se criar testes automatizados para os componentes da aplicação;
- Deve-se criar a documentação do projeto, protótipos, diagramas e README.

---

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

---

## Como Usar

#### Clone o Repositório
```
git clone https://github.com/m-m-Monza-n-Maverick/ControleDeCinema
```

#### Navegue até a pasta raiz da solução
```
cd ControleDeCinema
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
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
