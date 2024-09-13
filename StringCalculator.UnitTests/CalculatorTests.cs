using FluentAssertions;
using StringCalculator.Exceptions;

namespace StringCalculator.UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnNumber()
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(null!);

            // Assert
            result.Should<int>();
        }

        [Fact]
        public void Add_ShouldReturn_0_OnEmptyInput()
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(string.Empty);

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        public void Add_ShouldReturn_Correct_OnValid_One_NumberInput(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("1,1", 2)]
        [InlineData("2,3", 5)]
        [InlineData("3,4", 7)]
        public void Add_ShouldReturn_Correct_OnValid_Two_NumberInput(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("2,3,5", 10)]
        public void Add_ShouldReturn_Correct_OnValid_Any_NumberInput(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("2\n3,5", 10)]
        public void Add_ShouldReturn_Correct_With_Newlines_InMiddle(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"2\n3,5", 10)]
        [InlineData(@"2\n,3\n,5", 10)]
        public void Add_ShouldReturn_Correct_With_NewlinesString_InMiddle(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"\n3,5", 8)]
        [InlineData("\n3\n,5", 8)]
        public void Add_ShouldReturn_Correct_With_NewlinesString_InStart(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"//;\n3;5", 8)]
        [InlineData(@"//;3;5", 8)] // optional new line
        [InlineData("//;\n3;5", 8)]
        public void Add_ShouldReturn_Correct_With_Custom_Delimiter(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"//;3;5", 8)]
        public void Add_ShouldReturn_Correct_With_Custom_Delimiter_No_NewLine(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"//", 0)]
        [InlineData(@"//;", 0)]
        public void Add_ShouldReturn_Zero_With_Incomplete_Delimiter_Input(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"//;\n-3;5", "negatives not allowed (-3)")]
        [InlineData("-3,-8", "negatives not allowed (-3,-8)")]
        public void Add_Should_Throw_Error_With_Negative_Numbers(string input, string exceptionMessage)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            Action act = () => calculator.Add(input);

            // Assert
            act.Should().Throw<NegativesNotAllowedException>()
                .WithMessage(exceptionMessage);
        }

        [Theory]
        [InlineData("3,4,10,30,10001", 47)]
        [InlineData("3,4,10,30,1001", 47)]
        [InlineData("3,4,10,30,1000", 1047)]
        [InlineData("1001", 0)]
        public void Add_ShouldReturn_Correct_With_Ignoring_Numbers_BiggerThan1000(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"//[***]\n1***2***3", 6)]
        //[InlineData(@"//[,,,]\n1,,,2,,,3", 6)]
        public void Add_ShouldReturn_Correct_With_Long_Custom_Delimiter(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"//[\n1***2***3", "[ is not a valid delimiter")]
        [InlineData(@"//]\n1***2***3", "] is not a valid delimiter")]
        public void Add_Should_Throw_Error_With_Invalid_Custom_Delimiter(string input, string expectedError)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            Action act = () => calculator.Add(input);

            // Assert
            act.Should().Throw<InvalidDelimiterException>()
                .WithMessage(expectedError);
        }

        [Theory]
        [InlineData(@"//[*][%]\n1*2%3", 6)]
        [InlineData(@"//[*]\n1*2*3", 6)]
        public void Add_ShouldReturn_Correct_With_Multiple_Custom_Delimiter(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(@"//[*][]\n1*2%3", "invalid delimiter")]
        [InlineData(@"//[*][\n1*2%3", "[ is not a valid delimiter")]
        [InlineData(@"//[*]]\n1*2%3", "] is not a valid delimiter")]
        public void Add_Should_Throw_Error_With_Invalid_Multiple_Custom_Delimiter(string input, string expectedError)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            Action act = () => calculator.Add(input);

            // Assert
            act.Should().Throw<InvalidDelimiterException>()
                .WithMessage(expectedError);
        }

        [Theory]
        [InlineData(@"//[***][%]\n1***2%3", 6)]
        [InlineData(@"//[*][,,,]\n1*2,,,3", 6)]
        [InlineData(@"//[***][%%]\n1%%2***3", 6)]
        public void Add_ShouldReturn_Correct_With_Multiple_Long_Custom_Delimiter(string input, int expectedResult)
        {
            // Arrange
            var calculator = new Core.StringCalculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}