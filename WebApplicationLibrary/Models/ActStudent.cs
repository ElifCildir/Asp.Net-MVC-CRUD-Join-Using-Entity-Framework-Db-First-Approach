using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography.Xml;
using System.Web;

namespace WebApplicationLibrary.Models
{
    public class ActStudent
    {
        public int BookID { get; set; }
        public DateTime Duedate { get; set; }
        public string NameSurname { get; set; }
        public string BookTitle { get; set; }
        public int StudentID { get; set; }  
        public string Class { get; set; }
        public string Phone { get; set; }


    }
}





                         