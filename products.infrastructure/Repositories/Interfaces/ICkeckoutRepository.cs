using products.core.Entities;

namespace products.infrastructure.Repositories
{
    public interface ICkeckoutRepository
    {
        public Task<Checkout> GetCheckoutByID(Guid prCheckoutId);
        public Task<bool> CreateCkeckout(Checkout prCheckout);
        public Task<bool> DeleteCheckoutByID(Guid prCheckout);
        public Task<bool> UpdateCheckout(Checkout prCheckout);
        public Task<List<Checkout>> GetAllCheckouts();
    }
}