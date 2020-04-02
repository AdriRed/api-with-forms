using System.Collections.Generic;

namespace APIWithForms.Models
{
    public class UserColorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Alpha { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }
}
