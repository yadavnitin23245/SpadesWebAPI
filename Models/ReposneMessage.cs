using System;
using System.ComponentModel.DataAnnotations;

namespace ContactApi.Models
{
    public class ReposneMessage
    {
        public int Id { get; set; }


        public string Message { get; set; }


        public bool IsContacted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
        public int? Deletedby { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
    }
}