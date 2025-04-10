using System;
using System.ComponentModel.DataAnnotations;

namespace ContactApi.Models
{
    public class Contact
    {
        public int Id { get; set; }

        
        public string FullName { get; set; }

       
        [EmailAddress]
        public string Email { get; set; }

        
        public string Subject { get; set; }
        public string Comments { get; set; }

        public bool IsContacted { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }
        public int Deletedby { get; set; }

        public DateTime DeletedDate { get; set; }

        public bool IsActive { get; set; }
    }
}