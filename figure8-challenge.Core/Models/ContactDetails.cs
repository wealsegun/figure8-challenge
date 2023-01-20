using System;
using System.Collections.Generic;
using System.Text;

namespace Figure8Challenge.Core.Models
{
    public class ContactDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
