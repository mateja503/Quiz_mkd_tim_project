﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Име на квиз")]
        public string? Name { get; set; }

        [ValidateNever]

        public TypeQuiz? TypeQuize { get; set; }
        [ValidateNever]
        public int TypeQuizeId { get; set; }


        [Display(Name = "Прашања")]
        
        public ICollection<Question>? QuestionList { get; set; }

        
        public Event? Event { get; set; }
    }
}
