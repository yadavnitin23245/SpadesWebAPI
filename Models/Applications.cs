using System;
using System.ComponentModel.DataAnnotations;

namespace ContactApi.Models
{
    public class Applications
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string ApplyFor { get; set; }

        public DateTime? InterviewDate { get; set; }

        public string LinkedInLink { get; set; }

        public string AdditionalInformation { get; set; }

        public string FilePath { get; set; }

        public bool? IsContacted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? Deletedby { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool? IsActive { get; set; }
    }
}