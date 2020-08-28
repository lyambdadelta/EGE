using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGE
{
    public class Task
    {
        public int Id { get; set; }
        public int Subject { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public int ImageQuest { get; set; }
        public int ImageAnswer { get; set; }
        public string Answer { get; set; }
        public string Solution { get; set; }
        public int Status { get; set; }
        public int Result { get; set; }
        public int VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}
