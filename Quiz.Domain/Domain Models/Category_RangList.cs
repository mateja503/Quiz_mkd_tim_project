﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Category_RangList
    {
        [Key]
        public int Id { get; set; }

        public Category? Category { get; set; }

        public int? CategoryId { get; set; }

        public RangList? RangList  { get; set; }

        public int? RangListId { get; set; }

    }
}
