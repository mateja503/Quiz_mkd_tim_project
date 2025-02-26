using Quiz.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.ViewModels
{
    public class RangListVM
    {
        public RangList? RangList { get; set; }

        public IEnumerable<Category>? Categories { get; set; }
    }
}
