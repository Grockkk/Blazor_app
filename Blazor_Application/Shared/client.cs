using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Application.Shared
{
    public class client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int VAT_ID_number { get; set; }
        public DateTime Current_Date { get; set; }
        public string Address { get; set; }

        public static implicit operator List<object>(client v)
        {
            throw new NotImplementedException();
        }
    }
}
