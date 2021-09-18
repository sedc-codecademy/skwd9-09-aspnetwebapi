using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.MovieWorkshop.WebApi.Models.DTOs
{
    public class ResultDTO
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
