using System;
using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        [DataType(DataType.Date)]
        public string DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }

        //Foreign Key Relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
