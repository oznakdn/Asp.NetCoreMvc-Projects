using eTickets.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Web.Models.ViewModels
{
    public class NewMovieVM
    {
        [Required(ErrorMessage ="{0} is required!")]
        [Display(Name ="Movie name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Movie description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Price in TL")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Movie poster url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Start date is required!")]
        [Display(Name = "Movie start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required!")]
        [Display(Name = "Movie end date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Select a category")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Movie Producer is required!")]
        [Display(Name = "Select a producer")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "Movie Cinema is required!")]
        [Display(Name = "Select a cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Movie actor(s) is required!")]
        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }

    }
}
