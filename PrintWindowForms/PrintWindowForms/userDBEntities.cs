using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrintWindowForms
{
    internal class userDBEntities : DbContext, IDisposable
    {
        public DbSet<Userdbmodel> Product_Master { get; set; }

        // Add a method to retrieve the data for the report
        public List<Userdbmodel> GetProduct_Master()
        {
            return Product_Master.ToList();
        }
    }

    public class Userdbmodel
    {
        public string Product_name { get; set; }
        public string Product_description { get; set; }
        public int Cost { get; set; }
        public int Stock { get; set; }
        // Add other properties as needed
    }
}