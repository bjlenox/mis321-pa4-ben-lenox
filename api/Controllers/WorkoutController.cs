using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using api.Models;
// using static api.WorkoutUtility;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        // GET: api/Workout
        [HttpGet]
        public List<Workout> Get()
        {
            return WorkoutUtility.GetAllWorkouts();
        }

        // GET: api/Workout/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Workout
        [HttpPost]
        public void Post([FromBody] Workout value)
        {
            WorkoutUtility.AddWorkout(value);
        }

        // PUT: api/Workout
        [HttpPut]
        public void Put([FromBody] Workout value)
        {
            WorkoutUtility.PinWorkout(value);
        }

        // DELETE: api/Workout
        [HttpDelete]
        public void Delete([FromBody] Workout value)
        {
            WorkoutUtility.DeleteWorkout(value);
        }
    }
}
