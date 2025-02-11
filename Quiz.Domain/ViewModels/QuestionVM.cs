using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.ViewModels
{
    public class QuestionVM
    {
        public Question Question { get; set; }

        public IEnumerable<Answer> Answers { get; set; }

        public Domain_Models.Quiz Quiz { get; set; }
    }
}
