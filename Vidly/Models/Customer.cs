﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }
    }
}