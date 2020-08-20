using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp
{
    class Node
    {
        private int value;
        private Node left;
        private Node right;

        public Node(int val)
        {
            this.value = val;
            this.left = null;
            this.right = null;
        }

        public int Value
        {
            set { this.value = value; }
            get { return this.value; }
        }
        public Node Left
        {
            set { this.left = value; }
            get { return left; }
        }
        public Node Right
        {
            set { this.right = value; }
            get { return right; }
        }
        public void Add(int val)
        {
            if (val < this.value)
            {
                if (this.left != null)
                    this.left.Add(val);
                else
                {
                    Node newNode = new Node(val);
                    this.left = newNode;
                }
            }
            else
            {
                if (this.right != null)
                    this.right.Add(val);
                else
                {
                    Node newNode = new Node(val);
                    this.right = newNode;
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            if (left != null)
            {
                foreach (var element in left)
                    yield return element;
            }
            yield return this;
            if(right != null)
            {
                foreach (var element in right)
                    yield return element;
            }
        }
    }

    class BinaryTree
    {
        Node root;

        public BinaryTree(int[] array)
        {
            root = new Node(array[0]);
            for(int i=1; i< array.Length;i++)
            {
                if (array.Length==1)
                    break;
                else
                    root.Add(array[i]);
            }
        }

        public void Add(int val)
        {
            root.Add(val);
        }

        public void Search(int val)
        {
            int count = 0;
            foreach (Node curr in root)
            {
                if (curr.Value == val)
                    count++;
            }
            if (count > 0)
                Console.WriteLine("Value " + val +" is found " + count + " times");
            else
                Console.WriteLine("Value is not found");
        }

        public void Show()
        {
            foreach (Node curr in root)
                Console.Write(curr.Value + " ");
            Console.WriteLine();
        }
    }
}
