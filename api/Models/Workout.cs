using api.Models;
namespace api.Models
{
    public class Workout
    {
        public int Id {get; set;}
        public string? Type {get; set;}
        public double Distance{get; set;}
        public string? Date {get; set;}
        public bool Pinned {get; set;}
        public bool Deleted {get; set;}


    }
}