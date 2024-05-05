using products.core.Entities;

namespace products.infrastructure.Repositories.Interfaces
{
    public interface ICkeckoutRepository
    {
        public Checkout GetCheckoutByID(Guid prCheckoutId);
        public bool CreateCkeckout(Checkout prCheckout);
        public bool DeleteCheckoutByID(Guid prCheckout);
        public bool UpdateCheckout(Checkout prCheckout);
        public List<Checkout> GetAllCheckouts();
    }
}