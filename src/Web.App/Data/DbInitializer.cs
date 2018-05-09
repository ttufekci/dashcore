﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web.App.Models;

namespace Web.App.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly CustomConnectionContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            CustomConnectionContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //This example just creates an Administrator role and one Admin users
        public async void Initialize()
        {
            //create database schema if none exists
            _context.Database.EnsureCreated();

            //If there is already an Administrator role, abort
            if (_context.Roles.Any(r => r.Name == "Administrator")) return;

            string user = "admin@test.com";
            string password = "Admin+123";

            var identityResult = await _userManager.CreateAsync(new ApplicationUser { UserName = user, Email = user, EmailConfirmed = true }, password);

            //Create the Administartor Role
            await _roleManager.CreateAsync(new IdentityRole("Administrator"));

            //Create the default Admin account and apply the Administrator role

            var userCreated = await _userManager.FindByNameAsync(user);

            await _userManager.AddToRoleAsync(userCreated, "Administrator");
        }

        public static async void StaticInitialize(CustomConnectionContext paramContext,
            UserManager<ApplicationUser> paramUserManager,
            RoleManager<IdentityRole> paramRoleManager)
        {
            //create database schema if none exists
            paramContext.Database.EnsureCreated();

            //If there is already an Administrator role, abort
            if (paramContext.Roles.Any(r => r.Name == "Administrator")) return;

            string user = "admin@test.com";
            string password = "Admin+123";

            var identityResult = await paramUserManager.CreateAsync(new ApplicationUser { UserName = user, Email = user, EmailConfirmed = true }, password);

            //Create the Administartor Role
            await paramRoleManager.CreateAsync(new IdentityRole("Administrator"));

            //Create the default Admin account and apply the Administrator role

            var userCreated = await paramUserManager.FindByNameAsync(user);

            await paramUserManager.AddToRoleAsync(userCreated, "Administrator");
        }
    }
}
