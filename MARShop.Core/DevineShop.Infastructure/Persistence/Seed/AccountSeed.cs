﻿using DevineShop.Core.Entities;
using DevineShop.Core.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DevineShop.Infastructure.Persistence.Seed
{
    public static class AccountSeed
    {
        public static void SeedAccount(this ModelBuilder modelBuilder)
        {
            IList<Account> accounts = new List<Account>();

            var superAdmin = new Account()
            {
                Id = 1,
                Created = DateTime.Now,
                IsDelete = false,
                LastModified = DateTime.Now,
                UserName = "superadmin",
                Password = BCrypt.Net.BCrypt.HashPassword("admin@123"),
                Email = "kieuminhduc02@gmail.com",
                Role = nameof(Role.Admin),

            };
            accounts.Add(superAdmin);

            modelBuilder.Entity<Account>().HasData(accounts);
        }


    }
}
