namespace Exercise1.Services
{
    public class CartService
    {
        private readonly List<Cart> _carts = new();

        public void Add(Cart cart)
        {
            int id = GetId();
            cart.Id = id;
            _carts.Add(cart);
        }

        public Cart? Get(int id)
        {
            foreach (Cart cart in _carts)
            {
                if (cart.Id == id)
                {
                    return cart;
                }
            }

            return null;
        }

        private int GetId()
        {
            return _carts.Count > 0 ? _carts[^1].Id + 1 : 1;
        }
    }
}
