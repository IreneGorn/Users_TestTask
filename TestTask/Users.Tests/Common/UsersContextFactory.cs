using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Users.Domain;
using Users.Persistence;

namespace Users.Tests.Common
{
    public class UsersContextFactory
    {
        public static Guid RoleAId = Guid.NewGuid();
        public static Guid RoleBId = Guid.NewGuid();

        public static Guid UserIdForDelete = Guid.NewGuid();
        public static Guid UserIdForUpdate = Guid.NewGuid();

        public static UsersDbContext Create()
        {
            var options = new DbContextOptionsBuilder<UsersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new UsersDbContext(options);
            context.Database.EnsureCreated();
            context.Users.AddRange(
                new User
                {
                    UserName = "Name1",
                    Age = 10,
                    Email = "Email1",
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    RoleId = RoleAId
                },
                new User
                {
                    UserName = "Name2",
                    Age = 20,
                    Email = "Email2",
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    RoleId = RoleBId
                },
                new User
                {
                    UserName = "Name3",
                    Age = 30,
                    Email = "Email3",
                    Id = UserIdForDelete,
                    RoleId = RoleAId
                },
                new User
                {
                    UserName = "Name4",
                    Age = 40,
                    Email = "Email4",
                    Id = UserIdForUpdate,
                    RoleId = RoleBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(UsersDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
