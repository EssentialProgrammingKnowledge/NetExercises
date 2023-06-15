namespace Exercise2
{
    public static class Extensions
    {
        public static Headphones AsEntity(this HeadphonesDto dto)
        {
            return new Headphones
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }

        public static HeadphonesDto AsDto(this Headphones entity)
        {
            return new HeadphonesDto
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public static Consent AsEntity(this ConsentDto dto)
        {
            return new Consent
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }

        public static ConsentDto AsDto(this Consent entity)
        {
            return new ConsentDto
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}
