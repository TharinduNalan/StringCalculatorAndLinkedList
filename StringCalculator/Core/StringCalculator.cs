using StringCalculator.Exceptions;

namespace StringCalculator.Core
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            // As of assessment rules no input validation adding here
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            char delimiter = ',';
            if (numbers.StartsWith("//"))
            {
                // total 3 for including delimiter and + 1 for a number
                if (numbers.Length < 4)
                {
                    return 0;
                }

                // if delimiter starts with //[ means multi char delimiter
                if (numbers[2].Equals('['))
                {
                    // to figure out if incomplete brackets
                    bool delimiterFound = false;
                    // loop string until reach the closing bracket from the next index 2+1 = 3
                    int indexer = 3;
                    // keep the startIndex in order to get the length once we find the ]
                    int startIndex = 3;
                    while (indexer < numbers.Length)
                    {
                        if (numbers[indexer].Equals(']'))
                        {
                            delimiterFound = true;
                            // get the delimiter which support more than single char delimiter
                            string longDelimiter = numbers.Substring(startIndex, indexer - startIndex);
                            if (string.IsNullOrEmpty(longDelimiter))
                            {
                                throw new InvalidDelimiterException("invalid delimiter");
                            }

                            // get the next string after the ]
                            numbers = numbers.Substring(indexer + 1);
                            // replace the newly found delimiter with , so the final opertations stays the same
                            numbers = numbers.Replace(longDelimiter, ",");

                            // assign startIndex to 1 since the numbers string first [] with delimiter removed from the start
                            // indexer is assigned to 0 since it's going to increment by 1 before next iteration in the loop
                            startIndex = 1;
                            indexer = 0;

                            // check if there more custom delimiters
                            if (numbers[indexer].Equals('['))
                            {
                                delimiterFound = false;
                            }
                            else
                            {
                                break;
                            }
                        }

                        indexer++;
                    }

                    if (!delimiterFound)
                    {
                        throw new InvalidDelimiterException('[');
                    }
                }
                else
                {
                    delimiter = numbers[2];

                    numbers = numbers.Substring(3);
                }
            }

            if (delimiter.Equals('[') || delimiter.Equals(']') || numbers.Contains(']'))
            {
                throw new InvalidDelimiterException(']');
            }

            string cleanString = numbers.Replace(@"\n", delimiter.ToString());
            // can use regex as alternative approach
            string[] singleNumbers = cleanString.Split(delimiter, '\n');

            int output = 0;
            List<int> negativeNumbers = new List<int>();
            foreach (string number in singleNumbers)
            {
                int intNumber = CleanAndReturnNumber(number);
                if (intNumber < 0)
                {
                    negativeNumbers.Add(intNumber);
                    continue;
                }
                else if (intNumber > 1000)
                {
                    // ignore numbers higher than 1000
                    continue;
                }

                output = output + CleanAndReturnNumber(number);
            }

            if (negativeNumbers.Any())
            {
                throw new NegativesNotAllowedException(negativeNumbers);
            }

            return output;
        }

        private int CleanAndReturnNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            return int.Parse(number);
        }
    }
}
