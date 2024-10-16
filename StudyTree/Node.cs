using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTree
{
    public class Node
    {
        public int Data { get; set; }
        public Node Lift { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
            Lift = null;
            Right = null;

        }
    }
}
