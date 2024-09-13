using CustomLinkList.Core;
using CustomLinkList.Services;
using FluentAssertions;

namespace CustomLinkList.UnitTests
{
    public class LinkListDeleteTests
    {
        [Fact]
        public void Delete_Success_Return_Correct()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");

            // Act
            string? deletedNodeData = linkedList.Delete(1);

            // Assert
            deletedNodeData.Should().BeSameAs("hello");
        }

        [Fact]
        public void Delete_Success_Delete_Node()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");

            // Act
            string? deletedNodeData = linkedList.Delete(1);

            // Assert
            linkedList.Root.Should().BeNull();
        }

        [Fact]
        public void Delete_ReturnsNull_When_Root_Null()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());

            // Act
            string? deletedNodeData = linkedList.Delete(1);

            // Assert
            deletedNodeData.Should().BeNull();
        }

        [Fact]
        public void Delete_Success_Delete_Node_InPosition()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            string? deletedNodeData = linkedList.Delete(2);

            // Assert
            linkedList.Root.Should().NotBeNull();
            linkedList.Root!.Next.Should().BeNull();
        }

        [Fact]
        public void Delete_Success_Delete_Node_InPosition_With_Correct_NextLinks()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");
            linkedList.Insert(3, "!");

            // Act
            string? deletedNodeData = linkedList.Delete(3);

            // Assert
            linkedList.Root.Should().NotBeNull();
            linkedList.Root!.Next!.Next!.Should().BeNull();
        }

        [Fact]
        public void Delete_Success_Delete_Node_In_MiddlePosition_With_Correct_NextLinks()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");
            linkedList.Insert(3, "!");

            // Act
            string? deletedNodeData = linkedList.Delete(2);

            // Assert
            linkedList.Root.Should().NotBeNull();
            linkedList.Root!.Next!.Next!.Should().BeNull();
            linkedList.Root!.Next!.Data.Should().BeSameAs("!");
        }

        [Fact]
        public void Delete_Success_Delete_Root()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            string? deletedNodeData = linkedList.Delete(1);

            // Assert
            linkedList.Root.Should().NotBeNull();
            linkedList.Root!.Next.Should().BeNull();
        }

        [Fact]
        public void Delete_Success_NewRoot_Previous_Correct()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            string? deletedNodeData = linkedList.Delete(1);

            // Assert
            linkedList.Root.Should().NotBeNull();
            linkedList.Root!.Previous.Should().BeNull();
        }

        [Fact]
        public void Delete_Success_Too_Large_Position()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");

            // Act
            string? deletedNodeData = linkedList.Delete(3);

            // Assert
            deletedNodeData.Should().BeNull();
            linkedList.Root!.Next!.Data.Should().BeSameAs("world");
        }

        [Fact]
        public void Delete_Success_Too_Large_Position_OnlyWithRoot()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");

            // Act
            string? deletedNodeData = linkedList.Delete(2);

            // Assert
            deletedNodeData.Should().BeNull();
            linkedList.Root.Should().NotBeNull();
        }

        [Fact]
        public void Delete_Success_Delete_Node_In_MiddlePosition_With_Correct_PreviousLinks()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, "world");
            linkedList.Insert(3, "!");

            // Act
            string? deletedNodeData = linkedList.Delete(2);

            // Assert
            linkedList.Root!.Next!.Previous!.Data.Should().BeSameAs("hello");
        }

        [Fact]
        public void Delete_Success_Delete_Node_InLastPosition_With_Correct_NextLinks()
        {
            // Arrange
            var linkedList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
            linkedList.Insert(1, "hello");
            linkedList.Insert(2, ",");
            linkedList.Insert(3, "brave");
            linkedList.Insert(4, "new");
            linkedList.Insert(5, "world");

            // Act
            string? deletedNodeData = linkedList.Delete(5);

            // Assert
            linkedList.Root.Should().NotBeNull();
            linkedList.Root!.Next!.Next!.Next!.Next.Should().BeNull();
            linkedList.Root!.Next!.Next!.Next!.Data.Should().BeSameAs("new");
        }
    }
}
