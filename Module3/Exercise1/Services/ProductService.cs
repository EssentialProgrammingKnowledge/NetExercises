namespace Exercise1.Services
{
    public class ProductService : Service
    {
        public void Add(Product product)
        {
            base.Add(product);
        }

        public Product? Get(int id)
        {
            return GetById(id) as Product;
        }
    }
}
