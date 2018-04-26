using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Support : Base
    {
        public String Email { get; set; }
        public String CellNumber { get; set; }
        public String Message { get; set; }
        public int SubjectId { get; set; }
    }
}
