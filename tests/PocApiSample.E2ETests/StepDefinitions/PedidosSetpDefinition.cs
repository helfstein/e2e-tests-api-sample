using PocApiSample.Domain;
using PocApiSample.E2ETests.Support.Contexts;
using Refit;
using System.Net;

namespace PocApiSample.E2ETests.StepDefinitions
{
    [Binding]
    public class PedidosSetpDefinition
    {

        private PedidoContext _pedidoContext;
        private IApiService _apiService;

        public PedidosSetpDefinition(PedidoContext pedidoContext)
        {
            _pedidoContext = pedidoContext;
            _apiService = RestService.For<IApiService>("https://localhost:9443");
        }

        [Given("que estou autenticado")]
        public void DadoQueEstouAutenticado()
        {
            //logar no ambiente via jwt
        }

        [When("envio um novo pedido com valor total \"(.*)\" para a API")]
        public async Task QuandoEnvioUmNovoPedidoComValorTotal(decimal valor)
        {
            _pedidoContext.Pedido = new Pedido
            {
                Total = valor,
            };

            _pedidoContext.Response = await _apiService.CriarPedidoAsync(_pedidoContext.Pedido).ConfigureAwait(false);

        }

        [When("busco todos os pedidos na API")]
        public async Task QuandoBuscoTodosOsPedidosNaApi()
        {
            _pedidoContext.Response = await _apiService.BuscarTodosPedidosAsync().ConfigureAwait(false);

        }

        [Then("deve retornar o status \"(.*)\"")]
        public void DeveRetornarOStatus(HttpStatusCode status)
        {

            _pedidoContext.Response.Should().NotBeNull();
            _pedidoContext.Response?.StatusCode.Should().Be(status);

        }

        [Then("retornar o id do pedido criado")]
        public void DeveRetornarOIdDoPedidoCriado()
        {

            _pedidoContext.Response.Should().NotBeNull();
            _pedidoContext.Response.As<ApiResponse<Guid>>().Content.Should<Guid>().BeAssignableTo<Guid>();

        }

        [Then("retornar uma lista de pedidos")]
        public void DeveRetornarUmaListaDePedidos()
        {

            _pedidoContext.Response.Should().NotBeNull();
            _pedidoContext.Response.As<ApiResponse<List<Pedido>>>().Content.Should().NotBeNull();
            _pedidoContext.Response.As<ApiResponse<List<Pedido>>>().Content?.Count.Should().BeGreaterThan(1);

        }


    }
}
