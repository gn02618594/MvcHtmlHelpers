﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcHtmlHelpers.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public int City { get; set; }
        public string Commutermode { get; set; }
        public string Comment { get; set; }
        public bool Terms { get; set; }

    }
}