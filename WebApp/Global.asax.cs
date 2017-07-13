using ContactsApp.Data.Contact_Repository;
using ContactsApp.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Http.Cors;
using ContactsApp.Data;

namespace WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //CreateData();
        }

        //private void CreateData()
        //{
        //    IContactRepository contactRepository = new ContactRepository();

        //    contactRepository.AddContact(new Contact() { FirstName = "Jonas", LastName = "Motiejauskas", Email = "jonas.motiejauskas@gmail.com", Phone = "867894569" });
        //    contactRepository.AddContact(new Contact() { FirstName = "Benas", LastName = "Orlovas", Email = "benas.orlovas@yahoo.com", Phone = "+37061148987" });
        //    contactRepository.AddContact(new Contact() { FirstName = "Povilas", LastName = "Zvirblis", Email = "povilas.zvirblis@inbox.com", Phone = "+37065478968" });

        //}
    }
}
