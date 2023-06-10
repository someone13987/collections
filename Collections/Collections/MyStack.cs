using System.Collections;

namespace Collections;

public class MyStack : CollectionBase
{
    public void Push(object? item)
    {
        AddItem(item);
    }
    
    public object? Pop()
    {
        if(_count == 0) 
            throw new InvalidOperationException("Couldn't pop! There are no elements in the array.");
        
        object? item = _items[_count - 1];
        _items[_count - 1] = null;
        
        _count--;

        return item;
    }
    
    public object? Peek()
    {
        if(_count == 0) 
            throw new InvalidOperationException("Couldn't peek! There are no elements in the array.");
        
        return _items[_count - 1];
    }

    public override IEnumerator GetEnumerator()
    {
        return new StackEnumerator(_items);
    }
}