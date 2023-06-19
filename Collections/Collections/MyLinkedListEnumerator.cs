using System.Collections;

namespace GR11_2023_06_03;

public class MyLinkedListEnumerator<T> : IEnumerator<T>
{
    private MyLinkedListNode<T>? _firstNode;
    private MyLinkedListNode<T>? _currentNode;

    public MyLinkedListEnumerator(MyLinkedListNode<T>? array)
    {
        _firstNode = array;
    }

    public bool MoveNext()
    {
        if (_firstNode == null)
        {
            return false;
        }
        
        if (_currentNode == null)
        {
            _currentNode = _firstNode;
            return true;
        }
        
        if(_currentNode.Next != null)
        {
            _currentNode = _currentNode.Next;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _currentNode = _firstNode;
    }

    public MyLinkedListNode<T> CurrentNode
    {
        get
        {
            return _currentNode;
        }
    }

    public T Current
    {
        get
        {
            return _currentNode.Value;
        }
        
    }

    object IEnumerator.Current => Current;

    public void Dispose() //do we call GC.Collect() here?
    {
        Reset();
        //GC.Collect();
    }
}