using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain; 

namespace Persistence
{
    /// <summary>
    /// DbContext is from Entity Framework core 
    /// DbContext is an abstraction from our database
    /// i.e. Unit of work and Repository patterns - see info over DbContext
    /// We will use this class as service - want to be able to 
    /// insert data context into other classes
    /// </summary>
    public class DataContext : DbContext //this give us access to our database 
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Will generate our activities table which will have
        /// the property names of activity as columns
        /// </summary>
        public DbSet<Activity> Activities { get; set; }
    }
}
