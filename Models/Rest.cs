using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace restApi.Models
{
    public class Rest
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Platfrom { get; set; }
        public string CommandLine { get; set; }
    }
}