namespace Exercise1.Services
{
    // klasy Cart i User posiadają wspólne pole Id dlatego wykorzystano dziedziczenie aby nie powielać tego samego pola
    public class BaseObject
    {
        public int Id { get; set; }
    }
}
