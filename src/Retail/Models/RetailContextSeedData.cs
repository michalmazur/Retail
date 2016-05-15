using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.Models
{
    public class RetailContextSeedData
    {
        private RetailContext context;
        private UserManager<RetailUser> userManager;

        public RetailContextSeedData(RetailContext context, UserManager<RetailUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await userManager.FindByEmailAsync("user@example.com") == null) {
                var newUser = new RetailUser()
                {
                    UserName = "user",
                    Email = "user@example.com"
                };
                var ru = await userManager.CreateAsync(newUser, "password");
            }

            if (!context.Stores.Any())
            {
                context.Add(new Store()
                {
                    Label = "TestStore"
                });
                context.SaveChanges();
            }

            if (!context.Units.Any())
            {
                context.Add(new Unit() { Label = "ct" });
                context.Add(new Unit() { Label = "oz" });
                context.Add(new Unit() { Label = "fl oz" });
                context.Add(new Unit() { Label = "g" });
                context.Add(new Unit() { Label = "ml" });
                context.Add(new Unit() { Label = "lb" });
                context.Add(new Unit() { Label = "unknown" });
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Add(new Product()
                {
                    Barcode="123",
                    Comments="my comment",
                    Label = "Pizza",
                    UnitId = 1,
                    Amount = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Prices = new List<Price>
                    {
                        new Price()
                        {
                            Bogo = false,
                            Sale = false,
                            Cost = 5.00m,
                            StoreId = 1
                        }
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
