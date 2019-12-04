using System;
using Microsoft.AspNetCore.Identity;
using TestCreator.Areas.Identity.Data;

namespace TestCreator.Data
{
    public class IdentityDataInit
    {
        // calls SeedUsers and SeedRoles
        public static void SeedData(UserManager<TestUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);

        }
        public static void SeedUsers(UserManager<TestUser> userManager)
        {
            // seed Admin account
            if (userManager.FindByNameAsync ("admin").Result == null)
            {
                TestUser user = new TestUser();
                user.UserName = "admin";
                user.Email = "mm751@humboldt.edu";
                user.Name = "Mikel M";
                user.DOB = new DateTime(1960, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssw0rd!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }


            if (userManager.FindByNameAsync ("user1").Result == null)
            {
                TestUser user = new TestUser();
                user.UserName = "user1";
                user.Email = "user1@localhost";
                user.Name = "Mark Smith";
                user.DOB = new DateTime(1965, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "User1p@ssword").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Student").Wait();
                }
            }

            if (userManager.FindByNameAsync("user2").Result == null)
            {
                TestUser user = new TestUser();
                user.UserName = "user2";
                user.Email = "user2@localhost";
                user.Name = "Mark Smith";
                user.DOB = new DateTime(1965, 1, 1);

                IdentityResult result = userManager.CreateAsync
                (user, "User2p@assword").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Instructor").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync ("Student").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Student";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync ("Instructor").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Instructor";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync ("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
//        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)

//        {

//            //adding customs roles

//            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//            var UserManager = serviceProvider.GetRequiredService<UserManager<TestUser>>();

//            string[] roleNames = { "Admin", "Instructor", "Student" };

//            IdentityResult roleResult;

//​

//            foreach (var roleName in roleNames)

//            {

//                // creating the roles and seeding them to the database

//                var roleExist = await RoleManager.RoleExistsAsync(roleName);

//                if (!roleExist)

//                {

//                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));

//                }

//            }

//​

//            // creating a super user who could maintain the web app

//            var poweruser = new TestUser

//            {

//                UserName = Configuration.GetSection("UserSettings")["UserEmail"],

//                Email = Configuration.GetSection("UserSettings")["UserEmail"]

//            };

//​

//            string userPassword = Configuration.GetSection("UserSettings")["UserPassword"];

//            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);

//​

//            if (user == null)

//            {

//                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);

//                if (createPowerUser.Succeeded)

//                {

//                    // here we assign the new user the "Admin" role 

//                    await UserManager.AddToRoleAsync(poweruser, "Admin");

//                }

//            }

//        }

    }
}
