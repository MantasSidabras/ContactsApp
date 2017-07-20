using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.SendGridModels
{
    public class Personalization
{
    public List<To> to { get; set; }
    public string subject { get; set; }
}
}