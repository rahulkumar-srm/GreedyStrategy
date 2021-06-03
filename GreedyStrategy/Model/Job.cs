using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyStrategy.Model
{
    internal class Job
    {
        internal string Id { get; set; }
        internal int Deadline { get; set; }
        internal int Profit { get; set; }
    }
}
