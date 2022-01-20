﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.DataBase
{
    public class AccountDbContext : IdentityDbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options) { }
    }
}
