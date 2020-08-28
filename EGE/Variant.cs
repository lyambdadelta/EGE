using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE
{
    public class Variant
    {
        public int Id { get; set; }
        public int Subject { get; set; }
        public int Sum { get; set; }
        public int Status { get; set; }
        public List<Task> Phones { get; set; }
    }
}
