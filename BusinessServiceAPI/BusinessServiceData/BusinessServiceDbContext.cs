using System;
using Microsoft.EntityFrameworkCore;
using BusinessServiceDomain;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace BusinessServiceData
{
    public class BusinessServiceDbContext: DbContext
    {
        public BusinessServiceDbContext(DbContextOptions<BusinessServiceDbContext> options) : base(options)
        { }
        public DbSet<SchoolViewModel> SchoolViewModels { get; set; }
        public DbSet<StudentViewModel> StudentViewModels { get; set; }
    }
}
