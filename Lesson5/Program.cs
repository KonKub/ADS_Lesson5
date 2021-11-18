using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
        }

        static Random rnd = new Random();

        // Построение идеально сбалансированного дерева с n узлами со случайными значениями
        public static Node<int> Tree(int n)
        {
            Node<int> newNode = null;
            if (n == 0)
                return null;
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new Node<int>();
                newNode.Data = rnd.Next(100);
                newNode.Left = Tree(nl);
                newNode.Right = Tree(nr);
            }
            return newNode;
        }

        public static void PreOrderTravers(Node<int> root, string gap = "")
        {
            if (root != null)
            {
                PreOrderTravers(root.Left, gap + "   ");
                Console.WriteLine($"{gap}{root.Data}");
                PreOrderTravers(root.Right, gap + "   ");
            }
        }

        public static void BFS(Node<int> TreeHead)
        {
            var stack = new Stack<Node<int>>();
            stack.Push(TreeHead);
            Console.WriteLine("BFS:");
            Console.WriteLine($"->   {TreeHead.Data}");
            while (stack.Count > 0)
            {
                var gn = stack.Pop();
                Console.WriteLine($"  <- {gn.Data}");
                if (gn.Left != null) { stack.Push(gn.Left); Console.WriteLine($"->   {gn.Left.Data}"); }
                if (gn.Right != null) { stack.Push(gn.Right); Console.WriteLine($"->   {gn.Right.Data}"); }
            }
        }

        public static void DFS(Node<int> TreeHead)
        {
            var queue = new Queue<Node<int>>();
            queue.Enqueue(TreeHead);
            Console.WriteLine("DFS:");
            Console.WriteLine($"->   {TreeHead.Data}");
            while (queue.Count > 0)
            {
                var gn = queue.Dequeue();
                Console.WriteLine($"  <- {gn.Data}");
                if (gn.Left != null) { queue.Enqueue(gn.Left); Console.WriteLine($"->   {gn.Left.Data}"); }
                if (gn.Right != null) { queue.Enqueue(gn.Right); Console.WriteLine($"->   {gn.Right.Data}"); }
            }
        }

        static void Main(string[] args)
        {
            var head = Tree(10);
            PreOrderTravers(head, "");

            Console.WriteLine("==================================");

            BFS(head);

            Console.WriteLine("==================================");

            DFS(head);

            Console.ReadKey();

        }
    }
}

