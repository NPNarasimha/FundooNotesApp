﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class ResetPasswordModel
    {
        public string NewPassword { get; set; }
        public string ConformPassword { get; set; }
    }
}
