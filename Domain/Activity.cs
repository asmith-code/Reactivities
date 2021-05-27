using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// We will be returning an object with all of these activities
    /// the properties will form columns in a table called "Activities" in a Db
    /// we will use Entity Framework to create Db based on this code 
    /// Entity framework is an object relational mapper (ORM) 
    /// creates a layer of abstraction between C# and Db which listens to SQL 
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Gets or sets the Id 
        /// Guid because if we create the Id on the client side 
        /// Db doesn't have to generate Id for us it can be done on client side
        /// </summary>
        public Guid Id { get; set; } //Entity framework will know to make this the primary key

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string City { get; set; }

        public string Venue { get; set; }

    }
}
