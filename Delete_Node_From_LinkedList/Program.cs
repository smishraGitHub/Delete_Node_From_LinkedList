using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete_Node_From_LinkedList
{
    class Program
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node(int data)
            {
                val = data;
                next = null;
            }
        }

        public class LinkedList
        {
            Node root;

            public LinkedList()
            {
                root = null;
            }

            public void insertRoot(int data)
            {
                Node newNode = new Node(data);
                if (this.root !=null)
                {
                    newNode.next = root; 
                }
                this.root = newNode;
            }

            public void showList()
            {
                showList_func(root);
            }

            private void showList_func(Node root)
            {
                Node temp = root;
                while(temp !=null)
                {
                    Console.Write(temp.val + " ");
                    temp = temp.next;
                }
            }

            //Reverse Linked List
            public void ReveseList()
            {
                Node temp = root;
                temp = ReveseList_func(temp);
                showList_func(temp);
            }

            public Node ReveseList_func(Node root)
            {
                if (root == null || root.next == null)
                    return root;

                Node newNode = ReveseList_func(root.next);
                root.next.next = root;
                root.next = null;
                return newNode;
            }
            ////Delete Node Linked List
            public void DeleteNode(int position)
            {
                if (position <= 0)
                {
                    Console.WriteLine("Delete Node position should not be less than or equal 0");
                }
                else
                {
                    int Length = getLength(root);

                    if (position > Length)
                    {
                        Console.WriteLine("Delete Node position should not be grater than List Length!");
                    }
                    else
                    {
                        root = DeleteNode_func(root,position);
                    }
                }
               
            }

            private Node DeleteNode_func(Node root, int n)
            {
                if (root == null)
                {
                    return root;
                }
                else
                {
                 
                    int Length = getLength(root);
                    n = Length - n;
                    
                    if (Length == 1 && n==0)
                    {
                        root = root.next;
                        return root;
                    }
                    else
                    {
                        Node p = root;
                        Node q = root.next;
                        
                        if (n == 0)
                        {
                            p = p.next;
                            q = q.next;
                        }
                        else
                        {
                            int counter = 1;

                            while (q != null && counter < n)
                            {
                                counter++;
                                p = p.next;
                                q = q.next;
                            }
                        }
                        if (q.next != null)
                        {
                            p.next = q.next;
                        }
                        else
                        {
                            p.next = null;
                        }

                        return root;
                    }
                }
            }
            public int getLength(Node root)
            {
                Node temp = root;
                int count = 0;
                while (temp != null)
                {
                    count++;
                    temp = temp.next;
                }
                return count;
            }
        }
        static void Main(string[] args)
        {
            LinkedList ls = new LinkedList();
            ls.insertRoot(1);
            ls.insertRoot(2);
            ls.insertRoot(3);
            ls.insertRoot(4);
            ls.insertRoot(5);


            ls.showList();
            Console.WriteLine("");
            //ls.ReveseList();
            ls.DeleteNode(5);
            ls.showList();
            Console.ReadLine();

        }
    }
}
