using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.SendGridModels
{
    public class SendGridModel
    {
        public List<Personalization> personalizations { get; set; }
        public From from { get; set; }
        public List<Content> content { get; set; }
    }
}