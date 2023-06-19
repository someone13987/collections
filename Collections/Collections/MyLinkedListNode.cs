using System.Collections;

namespace GR11_2023_06_03
{
	public sealed class MyLinkedListNode<T> : IEnumerable<T>
	{
		public MyLinkedListNode(T? value)
		{
			Value = value;
		}

		public T? Value { get; set; }
		public MyLinkedListNode<T>? Next { get; set; }
		public MyLinkedListNode<T>? Previous { get; set; }
		public IEnumerator<T> GetEnumerator()
		{
			return new MyLinkedListEnumerator<T>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
