namespace Exercise1
{
    public class License
    {
        public License(string value)
        {
            // Walidacja przy tworzeniu obiektu License
            ValidLicense(value);
            Value = value;
        }

        public string Value { get; }

        private static void ValidLicense(string value)
        {
            // Sprawdzenie, czy wartość jest pusta lub zawiera mniej niż 11 znaków
            if (string.IsNullOrWhiteSpace(value) || value.Length < 11)
            {
                throw new ArgumentException("License is invalid");
            }

            // Podzielenie wartości na części, używając '/' jako separatora
            string[] parts = value.Split('/');

            // Sprawdzenie, czy otrzymano dokładnie cztery części
            if (parts.Length != 4)
            {
                throw new ArgumentException("License is invalid");
            }

            // Próba konwersji każdej części na liczbę
            if (!int.TryParse(parts[0], out int year) ||
                !int.TryParse(parts[1], out int month) ||
                !int.TryParse(parts[2], out int day) ||
                !int.TryParse(parts[3], out int additionalDigit))
            {
                throw new ArgumentException("License is invalid");
            }

            if (IsValidDayOrMonth(day, parts[2]) || IsValidDayOrMonth(month, parts[1]))
            {
                throw new ArgumentException("License is invalid");
            }

            // Dodatkowe warunki zgodnie z wzorcem
            if (year < 1000 || month < 1 || month > 12 || day < 1 || day > 31 || additionalDigit < 1)
            {
                throw new ArgumentException("License is invalid");
            }
        }

        private static bool IsValidDayOrMonth(int value, string stringValue)
        {
            return value < 10 && stringValue.Length < 2;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
