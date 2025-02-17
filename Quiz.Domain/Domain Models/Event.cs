using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Domain_Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Име на настан")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Дескрипција на настан")]
        [Required]
        public string? Description { get; set; }

        [Display(Name = "Почетен Датум")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "Завршен Датум")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }

        [Display(Name = "Корисници")]
        [ValidateNever]
        public ICollection<Event_User>? Event_User { get; set; }

        [Display(Name = "Квиз")]
        [ValidateNever]
        public Quiz? Quiz { get; set; }

        public int? QuizId { get; set; }

        [ValidateNever]
        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }


    }
}
