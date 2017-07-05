using ContactsApp.Contact_Access;
using ContactsApp.Data.Intefaces;
using ContactsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ContactsApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CreateData();
        }

        private void CreateData()
        {
            IContactRepository contactRepository = new ContactRepository();

            contactRepository.AddContact(new Contact() { FirstName = "Jonas", LastName = "Motiejauskas", Email = "jonas.motiejauskas@gmail.com", Phone = "867894569" });
            contactRepository.AddContact(new Contact() { FirstName = "Benas", LastName = "Orlovas", Email = "benas.orlovas@yahoo.com", Phone = "+37061148987" });
            contactRepository.AddContact(new Contact() { FirstName = "Povilas", LastName = "Zvirblis", Email = "povilas.zvirblis@inbox.com", Phone = "+37065478968" });

        }
    }
}
