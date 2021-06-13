//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Threading.Tasks;

//namespace EmployeeManagement.Infrastructure.Data
//{
//    public class SeedData
//    {
//        public static async Task Initialize(IServiceProvider serviceProvider, string approver, string requestor, string password)
//        {
//            using (var context = new ApplicationDbContext(
//                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
//            {
//                var approverId = await EnsureUser(serviceProvider, approver, password);
//                await EnsureRole(serviceProvider, approverId, "Approver");
//            }
//        }

//        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
//                                                    string UserName, string UserPw)
//        {
//            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

//            //var user = await userManager.FindByNameAsync(UserName);
//            //if (user == null)
//            //{
//                var user = new IdentityUser
//                {
//                    UserName = UserName,
//                    Email = UserName,
//                    EmailConfirmed = true
//                };
//                await userManager.CreateAsync(user, UserPw);
//            //}

//            if (user == null)
//            {
//                throw new Exception("The password is probably not strong enough!");
//            }

//            return user.Id;
//        }

//        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
//                                                                      string uid, string role)
//        {
//            IdentityResult IR = null;
//            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

//            if (roleManager == null)
//            {
//                throw new Exception("roleManager null");
//            }

//            if (!await roleManager.RoleExistsAsync(role))
//            {
//                IR = await roleManager.CreateAsync(new IdentityRole(role));
//            }

//            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

//            var user = await userManager.FindByIdAsync(uid);

//            if (user == null)
//            {
//                throw new Exception("The testUserPw password was probably not strong enough!");
//            }

//            IR = await userManager.AddToRoleAsync(user, role);

//            return IR;
//        }
//    }
//}
