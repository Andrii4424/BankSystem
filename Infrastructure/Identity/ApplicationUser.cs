﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities.Identity
{
    public class ApplicationUser :IdentityUser<Guid>
    {
        public string FullName {  get; set; }
    }
}
