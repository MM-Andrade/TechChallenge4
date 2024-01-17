
# PetHealthMonitor - Aplicação de triagem de Pets baseada em mensageria


## Projeto da Fase 4 - FIAP - Tech Challenge
 

## Visão Geral

  
O projeto PetHealtMonitor é um conjunto de aplicações desenvolvidas utilizando a tecnologia de mensageria com o RabbitMQ como broker e os conceitos de clean architecture.

A aplicação permite o cadastro de um pet, tutor e a temperatura para realizar uma verificação se o mesmo está febril.
![Fluxo Aplicação](.github/fluxo_aplicacao.png?style=flat)

  
## Estrutura

  
O projeto segue um padrão baseado em Domain-Driven Design (DDD):

 ![Estrutura](.github/estrutura_projeto.png?style=flat)

- **Camada Core**: Essa camada contém o domínio e as regras de negócio da aplicação. Contém as entidades, serviços de domínio, objetos de valor e agregados;

- **Camada Infrastructure**: Gerencia aspectos técnicos, como acesso a banco de dados, serviços externos e comunicação com a camada de domínio. Nesta camada, utiliza-se o RabbitMQ como broker responsável por realizar o serviço de enfileiramento de mensagens. Também utiliza-se um repositório para salvar as os dados recebidos da camada presentation em memória para processamento.

- **Camada Presentation**: Nesta camada, possuímos o projeto **PetHealthMonitor.Producer** que é uma interface web que possibilita que o usuário informe os dados do pet a ser analisado. Os projetos **PetHealthMonitor.Consumer** e **PetHealthMonitor.Functions.Consumer** são responsáveis por realizar a triagem e informar o estado do pet;

![Arquitetura](.github/arquitetura.png?style=flat)



## Execução Local

Para executar a aplicação PetHealthMonitor localmente, siga as etapas abaixo:
  
1. Clone o repositório para o seu ambiente de desenvolvimento;
2. Certifique-se que você tem o **Docker** instalado em seu ambiente;
3. Entre no diretório onde o repositório foi clonado e execute o comando abaixo:

		docker compose up

4. Ao iniciar o swagger estará disponível na URL  `https://localhost:63549/swagger/index.html`

![Swagger](.github/endpoints.png?style=flat)

  

>   Para acesso a console do RabbitMQ, será necessária a configuração das portas para a rede externa no Docker. No arquivo `docker-compose.yaml`adicione as seguintes linhas no bloco  `pethealthmonitor-mq`:
> 
>       ports:
>       - "5672:5672"
>       - "15672:15672"
>
> Encerre os containers caso estejam em execução e execute o comando `docker compose up` novamente, em seguida acesse a URL http://localhost:15672/ com o usuário `guest` e a senha `guest`

![RabbitMQ](.github/rabbitmq_queues.png?style=flat)

A aplicação também pode ser iniciada através do Visual Studio executando diretamente o Docker Compose no menu "build":


## Resultado do processamento
Os projetos **PetHealthMonitor.Consumer** e **PetHealthMonitor.Functions.Consumer** são responsáveis por realizar a o processamento dos dados informados através do **PetHealthMonitor.Producer**

![PetHealthMonitor.Consumer](.github/consumer.png?style=flat)

> O projeto **PetHealthMonitor.Functions.Consumer** é uma aplicação Serveless para execução no Azure Functions e adicinada a solution como referência para estudos

## Conclusão

  Este projeto demonstra a integração entre aplicações utilizando um software de mensageria como o RabbitMQ e práticas de clean architecture no desenvolvimento.

> Implementado por: Daniela Miranda de Almeida, Jhean Ricardo Ramos, Lucas dos anjos Varela, Marcelo de Moraes Andrade e Wellington Chida de Oliveira.