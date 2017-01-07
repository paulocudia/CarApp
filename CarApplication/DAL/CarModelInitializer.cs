using CarApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarApplication.DAL
{
    public class CarModelInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CarModelContext>
    {
        protected override void Seed(CarModelContext context)
        {
            var manufacturer = new List<Manufacturer>
            {
            new Manufacturer{BrandName="Carson"},
            new Manufacturer{BrandName="Meredith"},
            new Manufacturer{BrandName="Arturo"},
            new Manufacturer{BrandName="Gytis"},
            new Manufacturer{BrandName="Yan"},
            new Manufacturer{BrandName="Peggy"},
            new Manufacturer{BrandName="Laura"},
            new Manufacturer{BrandName="Nino"}
            };

            manufacturer.ForEach(s => context.Manufacturer.Add(s));
            context.SaveChanges();
            var brandModel = new List<BrandModel>
            {
            new BrandModel{ModelName="Wigo",ModelPrice="Chemistry"},
            new BrandModel{ModelName="Avansa",ModelPrice="Microeconomics"},
            new BrandModel{ModelName="Altis",ModelPrice="Macroeconomics"},
            new BrandModel{ModelName="Vios",ModelPrice="Calculus"},
            new BrandModel{ModelName="Hiace",ModelPrice="Trigonometry"},
            new BrandModel{ModelName="Yaris",ModelPrice="Composition"},
            new BrandModel{ModelName="Innova",ModelPrice="Literature"}
            };
            brandModel.ForEach(s => context.BrandModel.Add(s));
            context.SaveChanges();
        }
    }
}