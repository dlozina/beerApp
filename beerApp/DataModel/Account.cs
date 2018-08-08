using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beerApp.DataModel
{
    //class Account
    //{
    //    public string Email { get; set; }
    //    public bool Active { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public IList<string> Roles { get; set; }
    //}

    public class Roles
    {
        public string User { get; set; }
        public bool Admin { get; set; }
    }

    public class RootObject
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public Roles Roles { get; set; }
    }
}
