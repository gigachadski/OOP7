using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var list = new DoublyLinkedList<double>();
        list.AddFirst(2.5);
        list.AddFirst(7.8);
        list.AddFirst(3.3);
        list.AddFirst(9.0);
        list.AddFirst(4.1);

       /* Console.WriteLine("Список:");
        foreach (var value in list)
        Console.Write($"{value:0.00} ");
        Console.WriteLine();

        Console.WriteLine("Середнє значення"+ list.Average());
        Console.WriteLine("Індекс першого елемента < середнього: " + list.IndexOfFirstLessThanAverage());
        Console.WriteLine("Максимальний елемент:" + list.Max());
        Console.WriteLine("Сума після максимуму: " + list.SumAfterMax());

        var greaterList = list.GetElementsGreaterThan(5.0);
        Console.WriteLine("Новий список з елементів > 5.0:");
        foreach (var value in greaterList)
        Console.Write($"{value:0.00} ");
        Console.WriteLine();
     list.RemoveAt(2);
        Console.WriteLine(list) ;

        list.RemoveBeforeMax();
        Console.WriteLine("Після видалення до максимуму:");
        foreach (var value in list)
        Console.Write($"{value:0.00} "); 
        Console.WriteLine();*/
       list.RemoveAt(3);
        
    }
}
