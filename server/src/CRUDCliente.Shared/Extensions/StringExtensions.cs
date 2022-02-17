using System.Text.RegularExpressions;

namespace CRUDCliente.Shared.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidCpf(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (string.IsNullOrWhiteSpace(cpf)
                || cpf.ToCharArray().All(c => c == cpf[0])
                || cpf.Length != 11
                || !long.TryParse(cpf, out long x))
            {
                return false;
            }

            var cpfTemp = cpf.Substring(0, 9);

            var sum = 0;
            for (int i = 0; i < 9; i++)
                sum += int.Parse(cpfTemp[i].ToString()) * multiplicador1[i];

            var remainder = sum % 11;
            remainder = CalculateRemainder(remainder);

            var digito = remainder.ToString();
            cpfTemp += digito;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(cpfTemp[i].ToString()) * multiplicador2[i];
            remainder = sum % 11;
            remainder = CalculateRemainder(remainder);

            digito += remainder.ToString();

            return cpf.EndsWith(digito);
        }
        private static int CalculateRemainder(int remainder) =>
            remainder < 2 ? 0 : (11 - remainder);
        public static string OnlyWords(this string text) =>
            Regex.Replace(text, @"\w+", string.Empty);
        public static string OnlyDigits(this string text) =>
            Regex.Replace(text, @"[^0-9]", string.Empty);
        public static string OnlyAlphanumeric(this string text) =>
            string.Concat(text.Where(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)));
    }
}