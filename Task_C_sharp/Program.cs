using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    private List<(T, int)> items = new List<(T, int)>();

    public bool Empty => items.Count == 0;
    public void Enqueue(T item, int priority)
    {
        items.Add((item, priority));
    }

    public T Dequeue()
    {
        if (Empty)
            throw new InvalidOperationException("Queue is empty");

        int maxPriorityIndex = 0;
        for (int i = 1; i < items.Count; i++)
        {
            if (items[i].Item2 > items[maxPriorityIndex].Item2)
                maxPriorityIndex = i;
        }

        T item = items[maxPriorityIndex].Item1;
        items.RemoveAt(maxPriorityIndex);
        return item;
    }
}

public class Program
{
    static void Main()
    {
        PriorityQueue<string> queue = new PriorityQueue<string>();
        queue.Enqueue("a", 2);
        queue.Enqueue("y", 1);
        queue.Enqueue("y", 3);
        string isempty = queue.Dequeue();
        Console.WriteLine(isempty);
        while (!queue.Empty)
        {
            string item = queue.Dequeue();
            Console.WriteLine(item);
        }
    }

}