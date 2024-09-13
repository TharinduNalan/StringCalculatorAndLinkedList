using CustomLinkList.Core;
using CustomLinkList.UnitTests.Fake;
using FluentAssertions;

namespace CustomLinkList.UnitTests
{
    public class LinkListPrintTests
    {
        [Fact]
        public void PrintList_Success_Display()
        {
            // Arrange
            var fakeOutput = new FakeOutputPrinter();
            var linkedList = new GenericLinkedList<string>(fakeOutput);
            linkedList.Insert(1, "hello");

            // Act
            linkedList.PrintList();

            // Assert
            fakeOutput.Output.Should().NotBeEmpty();
        }

        [Fact]
        public void PrintList_Success_DisplayRoot()
        {
            // Arrange
            var fakeOutput = new FakeOutputPrinter();
            var linkedList = new GenericLinkedList<string>(fakeOutput);
            linkedList.Insert(1, "hello");

            // Act
            linkedList.PrintList();

            // Assert
            fakeOutput.Output[0].Should().BeSameAs("hello");
        }

        [Fact]
        public void PrintList_Success_WhenNoItems()
        {
            // Arrange
            var fakeOutput = new FakeOutputPrinter();
            var linkedList = new GenericLinkedList<string>(fakeOutput);

            // Act
            linkedList.PrintList();

            // Assert
            fakeOutput.Output.Should().BeEmpty();
        }

        [Fact]
        public void PrintList_Success_DisplayWhenMoreThan_1_Items()
        {
            // Arrange
            var fakeOutput = new FakeOutputPrinter();
            var linkedList = new GenericLinkedList<string>(fakeOutput);
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            linkedList.PrintList();

            // Assert
            fakeOutput.Output[0].Should().BeSameAs("hello");
            fakeOutput.Output[1].Should().BeSameAs("world");
        }

        [Fact]
        public void PrintList_Success_DisplayWhenMore_Items()
        {
            // Arrange
            var fakeOutput = new FakeOutputPrinter();
            var linkedList = new GenericLinkedList<string>(fakeOutput);
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "brave");
            linkedList.Insert(3, "new");
            linkedList.Insert(4, "world");
            linkedList.Insert(2, ",");

            // Act
            linkedList.PrintList();

            // Assert
            fakeOutput.Output[0].Should().BeSameAs("hello");
            fakeOutput.Output[1].Should().BeSameAs(",");
            fakeOutput.Output[2].Should().BeSameAs("brave");
            fakeOutput.Output[3].Should().BeSameAs("new");
            fakeOutput.Output[4].Should().BeSameAs("world");
        }
    }
}
