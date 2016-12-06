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
public class LinkedStack : IStackADT
{
	private Node top;

	/// <summary>
    /// Stack constructor
    /// </summary>
    public LinkedStack()
	{
		top = null;	// Empty stack condition
	}

	/// <summary>
    /// Adds a node onto the stack
    /// </summary>
    /// <param name="newItem">The item to add to the stack</param>
    /// <returns>The new node which was added</returns>
    public object Push(object newItem)
	{
		if ( newItem == null )
		{
			return null;
		}
		Node newNode = new Node(newItem, top);
		top = newNode;
		return newItem;
	}

	/// <summary>
    /// Removes the top node and returns it.
    /// </summary>
    /// <returns>The top node</returns>
    public object Pop()
	{
		if ( IsEmpty() )
		{
			return null;
		}
		object topItem = top.data;
		top = top.next;
		return topItem;
	}

    /// <summary>
    /// Returns the top node without removing it
    /// </summary>
    /// <returns>Returns the top node</returns>
    public object Peek()
	{
		if ( IsEmpty() )
		{
			return null;
		}
		return top.data;
	}

	/// <summary>
    /// Returns if this stack is empty
    /// </summary>
    /// <returns>If the stack is empty</returns>
    public bool IsEmpty()
	{
		return top == null;
	}

	/// <summary>
    /// Clear away all nodes
    /// </summary>
    public void Clear()
	{
		top = null;
	}

}
