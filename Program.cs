using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node
    {
        public List<Node> Parents { get; set; } = new List<Node>();
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Node()
            {
                Name = "1",
                Parents = new List<Node>()
                {
                    new Node
                    {
                        Name = "5",
                        Parents = new List<Node>()
                        {
                            new Node
                            {
                                Name = "6",
                                Parents = new List<Node>()
                                {
                                    new Node
                                    {
                                        Name = "7"
                                    }
                                }
                            },
                            new Node
                            {
                                Name = "9"
                            }
                        }
                    },
                    new Node
                    {
                        Name = "2",
                        Parents = new List<Node>()
                        {
                            new Node
                            {
                                Name = "3"
                            },
                            new Node
                            {
                                Name = "4"
                            }
                        }
                    }
                }
            };
            ShowTree(tree);
        }

        public static void ShowTree(Node tree) 
        {
            Stack<Node> st = new Stack<Node>();
            st.Push(tree);
            string res = "";
            Node last = new Node();
            while (st.Count != 0)
            {
                var temp = st.Pop();
                if (temp.Parents.Count == 0)
                    res = $" {temp.Name + " " + res}";
                else if (last.Parents.Contains(temp))
                    res = $"(__ {temp.Name + " " + res} __)";
                else
                    res = $"(__ {temp.Name} __)" + " " + res;


                foreach (var parent in temp.Parents)
                {
                    st.Push(parent);
                }
                if (temp.Parents.Count != 0)
                    last = temp;
            }

            res = $"(__ {res} __)";
            Console.WriteLine(res);
        }
    }
}
