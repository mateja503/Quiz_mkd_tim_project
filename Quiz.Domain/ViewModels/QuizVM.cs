using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.ViewModels
{
    public class QuizVM

    {
        public Domain_Models.Quiz Quiz { get; set; }


        [ValidateNever]
        public IEnumerable<Question?> QuestionList { get; set; }
    }
}
