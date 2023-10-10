using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Common.Mapping;
using Users.Application.Interfaces;
using Users.Persistence;
using Xunit;

namespace Users.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public UsersDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = UsersContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IUsersDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            UsersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
