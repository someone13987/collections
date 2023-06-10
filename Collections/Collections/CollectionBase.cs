using System.Collections;

namespace Collections;

public abstract class CollectionBase : ICollection
{
    protected object?[] _items = new object?[4]; 
    protected int _count = 0;
    
    protected void AddItem(object? item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        _items[_count] = item;
        _count++;
    }

    public abstract IEnumerator GetEnumerator();

    public void CopyTo(Array array, int index)
    {
        //yeah i couldn't figure this one out
    }

    public int Count => _count;
    public bool IsSynchronized { get; }
    public object SyncRoot { get; }
}

public class StackEnumerator : IEnumerator
{
    private int _index = -1;
    protected object?[] _items;
    
    public StackEnumerator(object?[] array)
    {
        _items = array ?? throw new ArgumentNullException(nameof(array));
        _index = array.Length - 1;
    }
    
    public bool MoveNext()
    {
        if (_items.Length == 0 || _index == 0)
            return false;
        
        _index--;
        return true;
    }

    public void Reset() //do i call GC.Collect here?
    {
        _index = -1;
        //GC.Collect();
    }
    
    public object Current => _items[_index];
}

public class QueueEnumerator : IEnumerator
{
    protected object?[] _items;
    protected int _index = 0;
    public QueueEnumerator(object?[] array)
    {
        _items = array ?? throw new ArgumentNullException(nameof(array));
    }

    public bool MoveNext()
    {
        if (_index == _items.Length - 1)
            return false;

        _index++;
        return true;
    }

    public void Reset()
    {
        _index = 0;
    }

    public object Current => _items[_index];
}

public class ArrayEnumerator : IEnumerator
{
    private object?[] _items;
    private int _index = -1;

    
    public ArrayEnumerator(object?[] array)
    {
        _items = array ?? throw new ArgumentNullException(nameof(array));
    }
    
    public bool MoveNext()
    {
        if (_index == _items.Length - 1)
        {
            return false;
        }
        
        _index++;
        return true;
    }

    public void Reset()
    {
        _index = -1;
    }
    
    public object Current => _items[_index];
}
