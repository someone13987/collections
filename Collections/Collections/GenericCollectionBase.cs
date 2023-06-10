using System.Collections;

namespace Collections;

public abstract class GenericCollectionBase<T> : ICollection<T>
{
    protected T[] _items = new T[4];
    protected int _count = 0;

    protected void AddItem(T item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        _count++;
        _items[_count - 1] = item;
    }

    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    void ICollection<T>.Add(T item)
    {
        AddItem(item);
    }

    public void Clear()
    {
        _items = new T[4];
        _count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i].Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    bool ICollection<T>.Remove(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i].Equals(item))
            {
                for (int u = i; u < _count - 1; u++)
                {
                    _items[u] = _items[u + 1];
                }

                _items[_count - 1] = default(T);
                return true;
            }
        }

        return false;
    }

    public int Count => _count;
    public bool IsReadOnly { get; }
    public bool IsSynchronized { get; }
    public object SyncRoot { get; }
}

public class GenericStackEnumerator<T> : IEnumerator<T>
{
    private int _index = -1;
    protected T[] _items;
    private T _current;

    public GenericStackEnumerator(T[] array)
    {
        _items = array ?? throw new ArgumentNullException(nameof(array));
        _index = array.Length;
    }
    
    public bool MoveNext()
    {
        if (_items.Length == 0 || _index == 0)
            return false;

        _index--;
        _current = _items[_index];
        return true;
    }

    public void Reset()
    {
        _index = -1;
    }

    public T? Current => _current;
    //why was this not nullable at the start? i don't know, don't ask me.
    
    object? IEnumerator.Current => _current;
    //We don't need this, since we only use the T variable type of Current.
    
    public void Dispose()
    {
        Reset();
    }
}

public class GenericQueueEnumerator<T> : IEnumerator<T>
{
    protected T[] _items;
    protected int _index = 0;
    private T _current;

    public GenericQueueEnumerator(T[] array)
    {
        _items = array ?? throw new ArgumentNullException(nameof(array));
    }

    public bool MoveNext()
    {
        if (_items.Length == 0 || _index == _items.Length - 1)
            return false;

        _current = _items[0];
        return true;
    }

    public void Reset()
    {
        _index = 0;
    }

    public T? Current => _current;
    //why was this not nullable at the start? i don't know, don't ask me.
    
    object? IEnumerator.Current => _items[_index];
    //We don't need this, since we only use the T variable type of Current.
    
    public void Dispose()
    {
        Reset();
    }
}

public class GenericArrayEnumerator<T> : IEnumerator<T>
{
    private T[] _items;
    private int _index = -1;
    private T _current;

    public GenericArrayEnumerator(T[] array)
    {
        _items = array ?? throw new ArgumentNullException(nameof(array));
    }

    public bool MoveNext()
    {
        if (_index + 1 == _items.Length || _items[_index + 1].Equals(default(T)))
        {
            return false;
        }

        _index++;
        _current = _items[_index];
        return true;
    }

    public void Reset()
    {
        _current = default(T);
        _index = -1;
    }

    public T? Current => _current;
    //why was this not nullable at the start? i don't know, don't ask me.
    
    object? IEnumerator.Current => _current;
    //We don't need this, since we only use the T variable type of Current.
    
    public void Dispose()
    {
        Reset();
    }
}
