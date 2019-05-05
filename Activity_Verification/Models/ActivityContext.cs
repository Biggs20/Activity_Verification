﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity_Verification.Models
{
    public class ActivityContext:DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options):base(options) 
        {

        }

        public DbSet<Activity> Activities { get; set; }
    }
}
