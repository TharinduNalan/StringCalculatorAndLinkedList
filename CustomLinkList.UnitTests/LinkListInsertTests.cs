using CustomLinkList.Core;
using CustomLinkList.Services;
using FluentAssertions;

namespace CustomLinkList.UnitTests
{
    public class LinkListInsertTests
    {
        [Fact]
        public void Insert_Success_Return_Number()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());

            // Act
            int position = linkedList.Insert(1, "hello");

            // Assert
            position.Should<int>();
        }

        [Fact]
        public void Insert_Success_AddRoot()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());

            // Act
            int position = linkedList.Insert(1, "hello");

            // Assert
            linkedList.Root.Should().NotBeNull();
        }

        [Fact]
        public void Insert_Success_AddRoot_With_ValidData()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());

            // Act
            linkedList.Insert(1, "hello");

            // Assert
            linkedList.Root!.Data.Should().BeSameAs("hello");
        }

        [Fact]
        public void Insert_Success_AddNode_With_ValidData()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");

            // Act
            linkedList.Insert(2, "world");

            // Assert
            linkedList.Root!.Next!.Data.Should().BeSameAs("world");
        }

        [Fact]
        public void Insert_Success_AddNode_To_ValidPosition()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            linkedList.Insert(3, "!");

            // Assert
            linkedList.Root!.Next!.Next!.Data.Should().BeSameAs("!");
        }

        [Fact]
        public void Insert_Success_AddNode_To_ValidPosition_With_CorrectLinks()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            linkedList.Insert(2, "!");

            // Assert
            linkedList.Root!.Next!.Next!.Data.Should().BeSameAs("world");
        }

        [Fact]
        public void Insert_Success_AddNode_To_ValidPosition_With_CorrectNextLinks()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");
            linkedList.Insert(3, "!");

            // Act
            linkedList.Insert(2, ",");

            // Assert
            linkedList.Root!.Next!.Next!.Next!.Data.Should().BeSameAs("!");
        }

        [Fact]
        public void Insert_Success_AddNode_To_ValidPosition_With_CorrectPreviousLinks()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");
            linkedList.Insert(3, "!");

            // Act
            linkedList.Insert(2, ",");

            // Assert
            linkedList.Root!.Next!.Next!.Next!.Previous!.Previous!.Data.Should().BeSameAs(",");
        }

        [Fact]
        public void Insert_Success_AddNode_With_TooLargePosition()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            int position = linkedList.Insert(10, "!");

            // Assert
            position.Should().Be(3);
            linkedList.Root!.Next!.Next!.Data.Should().BeSameAs("!");
        }

        [Fact]
        public void Insert_Success_AddNode_With_TooLargePosition_CorrectData()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            linkedList.Insert(10, "!");

            // Assert
            linkedList.Root!.Next!.Next!.Data.Should().BeSameAs("!");
        }
    }
}