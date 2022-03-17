namespace PocApiSample.Domain
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }

    }
}