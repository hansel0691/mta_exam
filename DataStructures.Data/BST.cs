using System;

public class BST<T> where T: IComparable
{
    public BST()
    {
    }

    public BinaryTreeNode<T> Root { get; set; }
    public int Count { get; set; }

    public void Add (T value)
    {
        var node = this.Root;

        while (node.Left != null && node.Right != null)
            if (value.CompareTo(node.Value) <= 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                    break;
                }
                node = node.Left;
            }
            else 
            {
                if (node.Right == null)
                {
                    node.Right =  new BinaryTreeNode<T>(value);
                    break;
                }
                node = node.Right;
            }
        
            
    }
}

public class BinaryTreeNode<T> where T: IComparable
{
    public BinaryTreeNode(T value)
    {
    }

    public T Value { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }
}