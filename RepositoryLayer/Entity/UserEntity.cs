﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class UserEntity
    {
        [Key]//for primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //identity(1,1) genareted
        public int UserId { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public string Gender { get; set; }
        public string Email { get; set; }
         public string Password { get; set; }

    }
}
