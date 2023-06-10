namespace Collections;

internal class Program
{
    static void Main(string[] args)
    {
        MyQueue queue = new();
        
        queue.Enqueue(1);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(1);

        foreach (var elements in queue)
        {
            Console.WriteLine(elements);
        }
    }
}