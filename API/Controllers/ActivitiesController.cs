using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController //inheriting all properties - therefore http request can also include Activities 
    {
        private readonly DataContext context;

        public ActivitiesController(DataContext context)//inject datacontext into controller so we can edit it inside the controller
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await this.context.Activities.ToListAsync();
        }
        
        [HttpGet("{id}")] //activities/id - 
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await this.context.Activities.FindAsync(id);
        }

    }
}
