using System.Collections;

namespace Collections;

public class GenericMyStack<T> : GenericCollectionBase<T>
{
    public void Push(T item)
    {
        AddItem(item);
    }

    public T Pop()
    {
        if(_count == 0)
            throw new InvalidOperationException("Couldn't pop! There are no elements in the array.");
        
        T item = _items[_count - 1];
        _items[_count - 1] = default(T);
        
        _count--;

        return item;
    }

    public T Peek()
    {
        if(_count == 0)
            throw new InvalidOperationException("Couldn't peek! There are no elements in the array.");
        
        return _items[_count - 1];
    }

    public override IEnumerator<T> GetEnumerator()
    {
        return new GenericStackEnumerator<T>(_items);
    }
}