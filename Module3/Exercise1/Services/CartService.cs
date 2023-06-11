namespace Exercise1.Services
{
    public class CartService : Service
    {
        public void Add(Cart cart)
        {
            base.Add(cart);
        }

        public Cart? Get(int id)
        {
            return GetById(id) as Cart;
        }
    }
}
