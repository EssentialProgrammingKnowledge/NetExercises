namespace Exercise1.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new();

        public void Add(Product product)
        {
            int id = GetId();
            product.Id = id;
            _products.Add(product);
        }

        public Product? Get(int id)
        {
            foreach (Product product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }

        private int GetId()
        {
            return _products.Count > 0 ? _products[^1].Id + 1 : 1;
        }
    }
}
