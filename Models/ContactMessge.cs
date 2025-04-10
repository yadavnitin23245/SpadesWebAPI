using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApi.Models
{
    public class ContactMessge
    {
        public int Id { get; set; }

        
        public string Message { get; set; }


        public bool IsContacted { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }
        public int Deletedby { get; set; }

        public DateTime DeletedDate { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public int orderCount { get; set; }
    }
}