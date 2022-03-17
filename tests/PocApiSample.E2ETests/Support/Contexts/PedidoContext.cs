using PocApiSample.Domain;
using Refit;

namespace PocApiSample.E2ETests.Support.Contexts
{
    public class PedidoContext
    {

        public Pedido? Pedido { get; set; }
        public IApiResponse? Response { get; set; }
    }
}
