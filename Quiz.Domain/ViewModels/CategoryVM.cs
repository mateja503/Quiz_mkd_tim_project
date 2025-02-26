using Quiz.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.ViewModels
{
    public class CategoryVM
    {
        public  Category? Category { get; set; }

        public bool isPartOfTheTable { get; set; }
    }
}
