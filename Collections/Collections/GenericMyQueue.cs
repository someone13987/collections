using System.Collections;

namespace Collections;

public class GenericMyQueue<T> : GenericCollectionBase<T>
{
    public void Enqueue(T item)
    {
        AddItem(item);
    }

    public T Dequeue()
    {
        if (_count == 0)
            throw new InvalidOperationException("Couldn't dequeue! There are no elements in the queue.");
        
        T item = _items[0];
        _count--;

        for (int i = 0; i < _count; i++)
        {
            _items[i] = _items[i + 1];
        }

        return item;
    }

    public T? Peek()
    {
        if (_count == 0)
            throw new InvalidOperationException("Couldn't peek! There are no elements in the queue.");

        return _items[_items.Length - 1];
    }

    public override IEnumerator<T> GetEnumerator()
    {
        return new GenericQueueEnumerator<T>(_items);
    }
}