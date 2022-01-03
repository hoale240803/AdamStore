using Application.Catalog.ShoppingCart;
using Shared.Entities;

namespace AdamStore.Infrastructure.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}