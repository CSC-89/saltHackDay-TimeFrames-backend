using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeFrames.Api.Models;

    public class TimeFrameContext : DbContext
    {
        public TimeFrameContext (DbContextOptions<TimeFrameContext> options)
            : base(options)
        {
        }

        public DbSet<TimeFrames.Api.Models.ToDo>? ToDo { get; set; }
    }
