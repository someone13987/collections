using System.Collections;

namespace Collections;

public unsafe class MyList : CollectionBase, IList
{
    private object[] _tools = new object[4];

    public override IEnumerator GetEnumerator()
    { 
        return new ArrayEnumerator(_items);
    }
    
    public int Add(object value)
    {
        AddItem(value);
        return _count - 1;
    }
    
    public void AddRange(object?[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            Add(values[i]);
        }
    }

    public void Insert(int index, object? value)
    {
        if (index < 0)
            throw new IndexOutOfRangeException("Couldn't insert the value to the array! The index is less than 0.");

        if (index > _count - 1)
            throw new IndexOutOfRangeException("Couldn't insert the value to the array! The index is greater than the amount of elements in the array.");

        Array.Resize(ref _items, _items.Length + 1);

        for (int i = _items.Length - 1; i > index; i--)
        { 
            _items[i] = _items[i - 1];
        }

        _items[index] = value;
    }

    public void InsertRange(object?[] values, int index)
    {
        if (index < 0)
            throw new IndexOutOfRangeException("Couldn't insert values to the array! The index is lower than 0.");

        if (index > _count - 1)
            throw new IndexOutOfRangeException("Couldn't insert values to the array! The index is greater than the amount of elements in the array.");

        for (int i = 0; i < values.Length; i++)
        {
            Insert(index + i, values[i]);
        }
    }

    public void Remove(object value)
    {
        if (IndexOf(value) != -1)
            RemoveAt(IndexOf(value));
    }

    public void RemoveAll(object value)
    {
        while (Contains(value))
        {
            Remove(value);
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0)
            throw new IndexOutOfRangeException("Couldn't remove at the index! The index is lower than 0.");

        if (index > _count - 1)
            throw new IndexOutOfRangeException("Couldn't remove at the index! The index is greater than the amount of elements in the array.");

        for (int i = index; i < _items.Length - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[_count - 1] = null;
        _count--;
    }

    public void Clear()
    {
        _items = new object?[4];
        _count = 0;
    }

    public bool Contains(object value)
    {
        return IndexOf(value, 0) != -1;
    }

    public int IndexOf(object value)
    {
        return IndexOf(value, 0);
    }

    public int IndexOf(object value, int startIndex)
    {
        if (startIndex >= _count)
            throw new IndexOutOfRangeException("Couldn't return the value at the index! The startIndex is greater than the amount of elements that are in the array.");
            
        if (startIndex < 0)
            throw new IndexOutOfRangeException("Couldn't return the value at the index! The startIndex is lower than 0.");

        for (int i = startIndex; i < _items.Length; i++)
        { 
            if (_items[i].Equals(value)) 
            {
                return i;
            }
        }
        
        return -1;
    }

    public int ElementAmount(object value)
    { 
        int amount = 0;
            
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i].Equals(value))
            {
                amount++;
            }
        }
            
        return amount;
    }

    public int ElementAmount(object value, int index)
    {
        int amount = 0;

        for (int i = index; i < _items.Length; i++)
        {
            if (_items[i].Equals(value))
            {
                amount++;
            }
        }

        return amount;
    }

    public int[] IndexesOf(object value)
    {
        return IndexesOf(value, 0);
    }

    public int[] IndexesOf(object value, int startIndex)
    {
        if (startIndex >= _count)
            throw new IndexOutOfRangeException("Couldn't return the indexes! The startIndex is greater than the amount of elements that are in the array.");

        if (startIndex < 0)
            throw new IndexOutOfRangeException("Couldn't return the indexes! The startIndex is lower than 0.");

        if (ElementAmount(value, startIndex) == 0)
            return new int[0];
            
        int[] temp = new int[ElementAmount(value, startIndex)];
        int x = 0;

        for (int i = startIndex; i < _items.Length; i++)
        {
            if (_items[i].Equals(value))
            {
                temp[x] = i;
                x++;
            }
        }
        
        return temp;
    }
        
    public void TrimToSize()
    {
        Array.Resize(ref _items, _count);
    }

    public bool IsFixedSize { get; }
    public bool IsReadOnly { get; }

    public object this[int index]
    { 
        get { return _items[index]; }
        set { _items[index] = value; }
    }
}