
# PetHealthMonitor - Aplicação de triagem de Pets baseada em mensageria

## Atualização: Projeto da Fase 5 - Tech Challenge

## Visão Geral

O tech challenge da fase 5 consiste em criar um cluster Kubernetes utilizando uma das aplicações desenvolvidas em fases anteriores.

Para atendimento desse Tech Challenge, utilizamos a aplicação da fase 4 conforme documentação.

#### Pré requisitos

Para reproduzir o cenário em máquinas locais, são necessários os recursos a seguir

- Docker: https://www.docker.com/get-started/
- Kubernetes: https://kubernetes.io/docs/setup/
- K9s (Opcional): https://k9scli.io/topics/install/

#### Executando localmente
Os arquivos de configuração dos clusters estão contidos nesse repositório na pasta "k8s"

`pethealth-mq.yaml` - Arquivo de configuração para o RabbitMQ
`rabbitmq-secret.yaml` - Arquivo contendo as credenciais de acesso RabbitMQ
`pethealthmonitor-consumer.yaml` - Arquivo de configuração da aplicação consumer do PetHealthMonitor
`pethealthmonitor-producer.yaml` - Arquivo de Configuração da aplicação Producer do PetHealthMonitor

Acesse o diretório k8's e execute os seguintes comandos para iniciar o cluster
`kubectl apply -f pethealth-mq.yaml `
`kubectl apply -f rabbitmq-secret.yaml `
`kubectl apply -f pethealthmonitor-consumer.yaml `
`kubectl apply -f pethealthmonitor-producer.yaml `

Você pode validar a criação dos recursos executando `kubectl get all`.
![kubectl get all](.github/kubectl_get_all.png?style=flat)

Ou através do k9s
![k9s](.github/k9s_clusters.png?style=flat)

Para acessar a aplicação via web, será necessário fazer a liberação da porta para a rede local. 
Execute o comando `kubectl port-forward service/pethealthmonitor-producer 9080:8080` para habilitar.
> kubectl port-foward "nomedoserviço" portadestino:portaorigem

Com a porta habilitada em rede local, o acesso poderá ser realizado através do endereço `http://localhost:9080/swagger/index.html`

![acesso aplicação web](.github/acesso_aplicacao_k8s.png?style=flat)

A vantagem da utilização de ferramentas de gerenciamento como a K9s, nos permite ter acesso aos logs do projeto consumer de forma mais fácil e resumida

![k9s log da aplicação consumer](.github/k9s_consumer.png?style=flat)

O cluster também pode ser utilizado em um serviço de cloud. Para melhor compreensão, acompanhe o video [Tech Challenge Fase 5](https://www.youtube.com/watch?v=o3iXurwIHSU).

 


## Conclusão

  Este projeto demonstra a utilização do projeto da fase 4 dentro de um cluster Kubernetes. Possibilitando assim, maior escalabilidade, disponibilidade e estabilidade da aplicação.

> Implementado por: Daniela Miranda de Almeida, Jhean Ricardo Ramos, Lucas dos anjos Varela, Marcelo de Moraes Andrade e Wellington Chida de Oliveira.


## Projeto da Fase 4 - FIAP - Tech Challenge
 

## Visão Geral

  
O projeto PetHealthMonitor é um conjunto de aplicações desenvolvidas utilizando a tecnologia de mensageria com o RabbitMQ como broker e os conceitos de clean architecture.

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

> O projeto **PetHealthMonitor.Functions.Consumer** é uma aplicação Serverless para execução no Azure Functions e adicionada a solution como referência para estudos

## Conclusão

  Este projeto demonstra a integração entre aplicações utilizando um software de mensageria como o RabbitMQ e práticas de clean architecture no desenvolvimento.

> Implementado por: Daniela Miranda de Almeida, Jhean Ricardo Ramos, Lucas dos anjos Varela, Marcelo de Moraes Andrade e Wellington Chida de Oliveira.