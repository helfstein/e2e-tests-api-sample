#language: pt-BR
Funcionalidade: Pedidos
	Eu como sistema consumidor, 
	quero poder manipular os pedidos através de chamadas de API

Cenário de Fundo: 
	Dado que estou autenticado

@Pedido
Cenário: Criar Pedido
	Quando envio um novo pedido com valor total "123,99" para a API
	Então deve retornar o status "201"
	E retornar o id do pedido criado

@Pedido
Cenário: Buscar Todos os Pedido
	Quando busco todos os pedidos na API
	Então deve retornar o status "200"
	E retornar uma lista de pedidos