using System.Collections;
using System.Runtime.Serialization;

namespace GR11_2023_06_03
{
	public class MyLinkedList<T> : ICollection<T>
	{
		public MyLinkedListNode<T>? First { get; private set; }
		public MyLinkedListNode<T>? Last { get; private set; }

		public void AddFirst(MyLinkedListNode<T> node)
		{
			Count++;
			if (First == null)
			{
				First = Last = node;
				return;
			}

			First.Previous = node;
			node.Next = First;
			First = node;
		}

		public MyLinkedListNode<T> AddFirst(T value)
		{
			MyLinkedListNode<T> node = new(value);
			AddFirst(node);
			return node;
		}

		public void AddLast(MyLinkedListNode<T> node)
		{
			Count++;
			if (Last == null)
			{
				First = Last = node;
				return;
			}

			node.Previous = Last;
			Last.Next = node;
			Last = node;
		}

		public MyLinkedListNode<T> AddLast(T value)
		{
			MyLinkedListNode<T> node = new(value);
			AddLast(node);
			return node;
		}

		public void AddAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
		{
			Count++;
			if (node == Last)
			{
				AddLast(newNode);
				return;
			}
			
			newNode.Next = node.Next;
			newNode.Previous = node;
			node.Next = newNode;
			node.Next.Next.Previous = newNode;
		}

		public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
		{
			MyLinkedListNode<T> newNode = new(value);
			AddAfter(node, newNode);
			return newNode;
		}

		public void AddBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
		{
			Count++;
			if (node == First)
			{
				AddFirst(newNode);
				return;
			}

			newNode.Next = node;
			newNode.Previous = node.Previous;
			node.Previous = newNode;
			newNode.Previous.Next = newNode;
		}

		public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
		{
			MyLinkedListNode<T> newNode = new(value);
			AddBefore(node, newNode);
			return newNode;
		}

		public void Remove(MyLinkedListNode<T> node)
		{
			if (First == null)
			{
				return;
			}
			Count--;
			if (node == First)
			{
				RemoveFirst();
				return;
			}

			if (node == Last)
			{
				RemoveLast();
				return;
			}
			
			node.Previous.Next = node.Next;
			node.Next.Previous = node.Previous;
			node.Next = null;
			node.Previous = null;
			
		}

		public bool Remove(T value)
		{
			if (First == null)
			{
				return false;
			}

			MyLinkedListEnumerator<T> e = new(First);
			while (e.MoveNext())
			{
				if (e.CurrentNode.Value.Equals(value))
				{
					Remove(e.CurrentNode);
					return true;
				}
			}

			Console.WriteLine("test");
			return false;
		}

		public void RemoveFirst()
		{
			if (First == Last == null)
			{
				return;
			}
			
			Count--;
			
			if (First == Last)
			{
				First = Last = null;
				return;
			}

			First = First.Next;
			First.Previous = null;
		}

		public void RemoveLast()
		{
			if (First == Last == null)
			{
				return;
			}
			
			Count--;
			
			if (First == Last)
			{
				First = Last = null;
				return;
			}

			Last = Last.Previous;
			Last.Next = null;
		}

		public bool Contains(T value)
		{
			foreach (T element in this)
			{
				if (element.Equals(value))
				{
					return true;
				}
			}

			return false;
		}

		public MyLinkedListNode<T>? Find(T value)
		{
			MyLinkedListEnumerator<T> e = new(First);
			while (e.MoveNext())
			{
				if (e.CurrentNode.Value.Equals(value))
				{
					return e.CurrentNode;
				}
			}

			return null;
		}

		public MyLinkedListNode<T>? FindLast(T value)
		{
			MyLinkedListEnumerator<T> e = new(First);
			MyLinkedListNode<T>? temp = null;
			while (e.MoveNext())
			{ 
				if (e.CurrentNode.Value.Equals(value))
				{
					temp = e.CurrentNode;
				}
			}

			return temp;
		}

		public void Clear()
		{
			MyLinkedListEnumerator<T> e = new MyLinkedListEnumerator<T>(First);

			while (e.MoveNext())
			{
				RemoveFirst();
			}

			Count = 0;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			int temp = arrayIndex;
			Array.Resize(ref array, array.Length * 2 - arrayIndex - 1 + Count);
			foreach (T element in this)
			{
				array[temp] = element;
				temp++;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new MyLinkedListEnumerator<T>(First);
		}

		public int Count { get; private set; }

		public bool IsReadOnly { get; }

		void ICollection<T>.Add(T item)
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
