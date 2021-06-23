using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class EspecieModel
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public string Kingdom { get; set; }
        public string ScientificName { get; set; }
        public string CanonicalName { get; set; }
        public string NameType { get; set; }
        public string Origin { get; set; }
        public int NumDescendants { get; set; }
    }
}
