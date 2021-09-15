using malshetwi_Project3_SDA.LMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace malshetwi_Project3_SDA.LMS.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScop = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScop.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Items
                if (!context.Items.Any())
                {
                    context.Items.AddRange(new List<Item>() {
                    new Item()
                    {
                        ItemPicURL = "001",
                        ItemName = "Microsoft",
                        ItemBio="Microsoft surface laptop 4",
                        Price=5000 },
                    new Item()
                    {
                        ItemPicURL = "002",
                        ItemName = "MacBook",
                        ItemBio="MacBook Air 13M",
                        Price=4800 },
                    new Item()
                    {
                        ItemPicURL = "003",
                        ItemName = "Huawei",
                        ItemBio="Huawei Matebook",
                        Price=3500 },
                    new Item()
                    {
                        ItemPicURL = "004",
                        ItemName = "Asus",
                        ItemBio="Asus ZenBook",
                        Price=2800 }


                    }) ;
                    context.SaveChanges();

                }


            }
        }
    }
}



                         










                                     
                        
                       
                    


   
    

