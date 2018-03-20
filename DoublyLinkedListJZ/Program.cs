using System;

namespace DoublyLinkedListJZ
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList DLL = new DoublyLinkedList();
            DLL.Insert(45);
            DLL.Insert(49);
            DLL.Insert(42);
            DLL.Insert(48);
            DLL.Insert(52);
            DLL.Insert(12);
            DLL.Insert(100);
            Console.WriteLine(DLL.ToString());
            //Prints "12->42->45->48->49->52->100"
            Console.WriteLine(DLL.ToStringReverse());
            //Prints "100->52->49->48->45->42->12"
            DLL.Insert(49);
            Console.WriteLine(DLL.ToString());
            //Prints "12->42->45->48->49->49->52->100"
            Console.WriteLine(DLL.ToStringReverse());
            DLL.Remove(42);
            DLL.Remove(49);
            DLL.Remove(100);
            DLL.Remove(52);
            Console.WriteLine(DLL.ToString());
            Console.WriteLine(DLL.ToStringReverse());


            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
