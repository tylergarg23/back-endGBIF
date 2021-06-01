using System;
using System.Collections.Generic;

namespace back_end.Data
{
    public partial class Especie
    {
        public int Id { get; set; }
        public string Kingdom { get; set; }
        public string ScientificName { get; set; }
        public string CanonicalName { get; set; }
        public string Origin { get; set; }
        public string NameType { get; set; }
        public int? NumDescendants { get; set; }
        public int KeyEspecie { get; set; }
    }
}
