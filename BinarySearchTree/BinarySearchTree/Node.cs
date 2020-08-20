using System;
using System.Collections;
using System.Text;

namespace BinarySearchTree
{
    class Node
    {
        private Node parent, left, right;
        public int data { get; set; }

        public Node(Node parent, int data)
        {
            this.parent = parent;
            this.data = data;
        }

        public void Add(int data)
        {
            if (data < this.data)
            {
                if (left == null)
                {
                    left = new Node(this, data);
                }
                else if (left != null)
                {
                    left.Add(data);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new Node(this, data);
                }
                else if (right != null)
                {
                    right.Add(data);
                }
            }
        }

        public Node Search(int data)
        {
            if (this == null)
            {
                return null;
            }
            if (data == this.data)
            {
                return this;
            }
            if (data < this.data)
            {
                return left.Search(data);
            }

            return right.Search(data);
        }

        public IEnumerator GetEnumerator()
        {
            if (left != null)
            {
                foreach (var x in left)
                    yield return x;
            }

            yield return this;

            if (right != null)
            {
                foreach (var x in right)
                    yield return x;
            }
        }
    }
}
