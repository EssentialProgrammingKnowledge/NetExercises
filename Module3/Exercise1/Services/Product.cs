namespace Exercise1.Services
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            // description could be so long and don't want to show
            return $"Id = {Id}; Name = {Name}; Category = {Category}";
        }
    }
}
