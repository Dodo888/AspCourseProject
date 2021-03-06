﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Web.Mvc;

namespace AspCourseProject.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        // [DataType(DataType.ImageUrl)]
        // public string Image { get; set; }

        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public PersonGender Gender { get; set; }
        public bool IsAlive { get; set; }

        public string Status() => IsAlive ? "alive" : "dead";
    }

    public enum PersonGender
    {
        [Display(Name = "Не задано")]
        Unknown = 0,
        [Display(Name = "М")]
        [Description("М")]
        Male = 1,
        [Display(Name = "Ж")]
        [Description("Ж")]
        Female = 2
    }
}
