namespace MOROPO.VIDERHE.Terminal.Player.Extensions
{
    internal static class StringExtensions
    {
        private const string ALPHABET = "0123456789abcdefghijklmnopqrstuvwxyz";

        internal static string ToBase36String(this long number)
        {
            var alphabetChars = ALPHABET.ToCharArray();

            var resultStack = new System.Collections.Generic.Stack<char>();

            while (number > 0)
            {
                resultStack.Push(alphabetChars[number % 36]);

                number /= 36;
            }

            return new string(resultStack.ToArray());
        }
    }
}
