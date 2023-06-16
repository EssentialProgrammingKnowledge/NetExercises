namespace Exercise4
{
    // ten serwis pozostaje bez zmian gdyż wykorzystuje wszystkie funkcjonalności
    public class ProductService : Service<ProductDto>, IService<ProductDto>
    {
        public override int Add(ProductDto dto)
        {
            if (dto == null) 
            {
                throw new ArgumentNullException(nameof(dto));
            };

            if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Description))
            {
                throw new InvalidOperationException("Invalid ProductDto");
            }

            return base.Add(dto);
        }

        public override void Update(ProductDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            };

            if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Description))
            {
                throw new InvalidOperationException("Invalid ProductDto");
            }

            base.Update(dto);
        }

        public override void Delete(ProductDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            };

            base.Delete(dto);
        }
    }
}
