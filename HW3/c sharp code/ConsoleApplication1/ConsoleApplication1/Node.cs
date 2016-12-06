using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

/**
 * A simple singly linked node class.  This implementation comes from
 * before Java had Generics.
 */
public class Node
{
	public object data;	// The payload
	public Node next;	// Reference to the next Node in the chain

	/// <summary>
    /// Null node constructor
    /// </summary>
    public Node()
	{
		data = null;
		next = null;
	}

	/// <summary>
    /// Node constructor given obj data and the next node
    /// </summary>
    /// <param name="data">data which does in this node</param>
    /// <param name="next">the next linked node</param>
    public Node(object data, Node next)
	{
		this.data = data;
		this.next = next;
	}
}
