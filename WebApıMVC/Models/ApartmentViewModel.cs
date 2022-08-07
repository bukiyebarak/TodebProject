using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApıMVC.Models
{
    public class ApartmentViewModel
    {
        public int Id { get; set; }
        public int No { get; set; }
        public int UserId { get; set; }
        public char Block { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }

    }
}