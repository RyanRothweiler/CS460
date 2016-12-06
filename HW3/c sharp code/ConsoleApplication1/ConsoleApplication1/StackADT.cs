using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

/** Java Interface defining a Stack. */
public interface IStackADT
{

	/// <summary>
    /// Adds a node onto the stack
    /// </summary>
    /// <param name="newItem">The node to add</param>
    /// <returns>The node which was added</returns>
    object Push(object newItem);

	/// <summary>
    /// Returns the node at the top of the stack and removes it
    /// </summary>
    /// <returns>The node at the top of the stack</returns>
    object Pop();

	/// <summary>
    /// Returns the node at the top of the stack without removing it
    /// </summary>
    /// <returns>The node at the top of the stack</returns>
    object Peek();

	/// <summary>
    /// Returns if the stack is empty
    /// </summary>
    /// <returns>If the stack is empty</returns>
    bool IsEmpty();

	/// <summary>
    /// Remove all node data
    /// </summary>
    void Clear();
}