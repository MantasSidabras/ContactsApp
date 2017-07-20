using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EsendexModel
    {
        public string accountreference { get; set; }
        public EsendexMessage[] messages { get; set; }

    }
}