using System.Text;

namespace StringCalculator.Exceptions
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(List<int> negativeNumbers) : base(GetExceptionMessage(negativeNumbers))
        {

        }

        private static string GetExceptionMessage(List<int> negativeNumbers)
        {
            var stringBuilder = new StringBuilder("negatives not allowed (");

            for (int i = 0; i < negativeNumbers.Count - 1; i++)
            {
                stringBuilder.Append(negativeNumbers[i].ToString());
                stringBuilder.Append(",");
            }

            stringBuilder.Append(negativeNumbers[negativeNumbers.Count - 1].ToString());
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }
    }
}
