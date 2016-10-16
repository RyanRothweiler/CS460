using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

/**
 * A singly linked stack implementation.
 */
public class LinkedStack : StackADT
{
	private Node top;

	public LinkedStack()
	{
		top = null;	// Empty stack condition
	}

	public Object Push(Object newItem)
	{
		if ( newItem == null )
		{
			return null;
		}
		Node newNode = new Node(newItem, top);
		top = newNode;
		return newItem;
	}

	public Object Pop()
	{
		if ( IsEmpty() )
		{
			return null;
		}
		Object topItem = top.data;
		top = top.next;
		return topItem;
	}

	public Object Peek()
	{
		if ( IsEmpty() )
		{
			return null;
		}
		return top.data;
	}

	public bool IsEmpty()
	{
		return top == null;
	}

	public void Clear()
	{
		top = null;
	}

}
