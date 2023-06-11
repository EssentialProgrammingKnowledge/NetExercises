using System.Text.RegularExpressions;

namespace Exercise1
{

    // W klasie License definiowany jest stały ciąg znaków PATTERN, który reprezentuje wzorzec poprawnej licencji.
    // Wzorzec ten składa się z czterech grup cyfr oddzielonych znakiem ukośnika
    public class License
    {
        // wzorzec składa się z 4 cyfr, następnie ukośnik, dwie cyfry, ukośnik i przynajmniej 
        // 1 cyfra aby został dany wzorzec spełniony np 2023/06/11/1
        private const string PATTERN = "^(\\d{4})\\/(\\d{2})\\/(\\d{2})\\/(\\d{1,})";

        public License(string value)
        {
            ValidLicense(value);
            Value = value;
        }

        public string Value { get; }

        private static void ValidLicense(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("License is invalid");
            }

            if (value.Length < 11)
            {
                throw new ArgumentException("License is invalid");
            }

            // wyrażenie regularne (klasa Regex) sprawdza, czy podana wartość (value) pasuje do wzorca PATTERN
            if (!new Regex(PATTERN).IsMatch(value))
            {
                throw new ArgumentException("License is invalid");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
