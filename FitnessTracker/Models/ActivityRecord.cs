// Models/ActivityRecord.cs

using System;

namespace FitnessTracker.Models
{
    public class ActivityRecord
    {
        public int Id { get; set; }
        public string ActivityType { get; set; }
        public int DurationInMinutes { get; set; }
        public double Distance { get; set; }
        public string Intensity { get; set; }
        public int CaloriesBurned { get; set; }
        public DateTime DateLogged { get; set; }
    }
}
