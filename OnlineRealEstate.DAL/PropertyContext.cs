using OnlineRealEstate.Entity;
using System.Data.Entity;

namespace OnlineRealEstate.DAL
{
    class PropertyContext:DbContext
    {
        public PropertyContext() : base("RealEstate")
        {
             //   this.Configuration.LazyLoadingEnabled = false;
        }
        //protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        //{
        //    dbModelBuilder.Entity<Property>().MapToStoredProcedures();
        //    dbModelBuilder.Entity
        //}
        public DbSet<User> User { get; set; }

        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<PropertyFeature> PropertyFeatures { get; set; }
        public DbSet<PropertyValues> PropertyValues { get; set; }
        public DbSet<BuyerProperty> BuyerProperty { get; set; }
        
    }
}
