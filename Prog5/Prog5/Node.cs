using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog5
{
    public class Node
    {
        public object Value { get; set; }

        public Node(object Data)
        {
            this.Value = Data;
        }
        public Node Next { get; set; }

        public Node Prev { get; set; }
    }
}
