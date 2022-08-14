﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicensePlateNumber { get; set; }
        public UserRole Role { get; set; }
        public UserPassword Password { get; set; }
        public IEnumerable<Bill> Bill { get; set; }

        //Bir kullanıcının birden fazla yetkisi olacağı için ICollection olarak verildi
        public ICollection<UserPermission> Permissions { get; set; }
    }
}
