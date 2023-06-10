using System.Collections;

namespace Collections;

public class MyQueue : CollectionBase
{
    public void Enqueue(object? item)
    {
        AddItem(item);
    }
    
    public object? Dequeue()
    {
        if (_count == 0)
            throw new InvalidOperationException("Couldn't dequeue! There are no elements in the queue.");
        
        object? item = _items[0];
        _count--;

        for (int i = 0; i < _count; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[_count] = null;
        
        return item;
    }

    public object? Peek()
    {
        if (_count == 0)
            throw new InvalidOperationException("Couldn't peek! There are no elements in the queue.");

        return _items[_items.Length - 1];
    }

    public override IEnumerator GetEnumerator()
    {
        return new QueueEnumerator(_items);
    }
}