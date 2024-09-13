using CustomLinkList.Core;
using CustomLinkList.Services;

var linkList = new GenericLinkedList<string>(new ConsoleOutputPrinter());
linkList.Insert(1, "Hello");
linkList.Insert(2, "World");

linkList.PrintList();

