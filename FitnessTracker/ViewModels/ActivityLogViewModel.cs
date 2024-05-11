using System.ComponentModel.DataAnnotations;
using System;
namespace FitnessTracker.ViewModels
{
  
    public class ActivityLogViewModel
    {

        [Required]
        public string ActivityType { get; set; }

        [Required]
        [Display(Name = "Duration (minutes)")]
        public int DurationInMinutes { get; set; }

        [Required]
        [Display(Name = "Distance (miles/km)")]
        public double Distance { get; set; }

        [Required]
        public string Intensity { get; set; }

        [Display(Name = "Calories Burned")]
        public int CaloriesBurned { get; set; }
    }
}




