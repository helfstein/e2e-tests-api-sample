#Sobre
Projeto de exemplo de implementação de testes E2E(end-to-end) utilizando SpecFlow e xUnit

#Pré-requisitos
- Docker Desktop
- Docker-Compose
- Extensão do SpecfFlow para Visual Studio([VS 2019](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio), [Vs 2022](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio2022))

#Repo
[https://github.com/helfstein/e2e-tests-api-sample](https://github.com/helfstein/e2e-tests-api-sample)

#Execução
Executar os comandos abaixo na pasta onde está o arquivo **docker-compose.yml**.
```bash
docker-compose build
```

```bash
docker-compose up -d
`````

Com a API em execução, basta buildar o projeto E2E para o Visual Studio exibir os testes E2E para execução.

#Demo
![ExemploTesteE2E-Regressivo.gif](https://github.com/helfstein/e2e-tests-api-sample/blob/main/e2e-sample.gif?raw=true)
