using PocApiSample.Domain;
using Refit;

namespace PocApiSample.E2ETests
{
    public interface IApiService
    {
        [Post("/api/pedido")]
        Task<ApiResponse<Guid>> CriarPedidoAsync(
            [Body] Pedido pedido);

        [Get("/api/pedido/{id}")]
        Task<ApiResponse<Pedido>> BuscarPedidoAsync(Guid id);

        [Get("/api/pedido")]
        Task<ApiResponse<List<Pedido>>> BuscarTodosPedidosAsync();

    }
}
