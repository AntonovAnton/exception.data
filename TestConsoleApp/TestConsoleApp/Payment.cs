using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public record Invoice
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Status { get; set; }
    }
}