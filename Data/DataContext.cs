using DanilaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DanilaWebApp.Data
{
    public class DataContext :  DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneCharacteristic> PhoneCharacteristics { get; set; }
        public DbSet<SupportedCommunicationType> SupportedCommunicationTypes { get; set; }
        public DbSet<CommunicationType> CommunicationTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasOne(m => m.User).WithOne(u => u.Profile)
                .HasForeignKey<Profile>(j => j.UserId);

            modelBuilder.Entity<Order>().HasOne(m => m.Address).WithOne(n => n.Order)
                .HasForeignKey<Order>(k => k.AddressId);

            modelBuilder.Entity<SupportedCommunicationType>()
                .HasKey(m => new {m.CommunicationTypeId, m.PhoneCharacteristicId});

            modelBuilder.Entity<SupportedCommunicationType>().HasOne(m => m.CommunicationType)
                .WithMany(n => n.SupportedCommunicationTypes)
                .HasForeignKey(k => k.CommunicationTypeId);
            
            modelBuilder.Entity<SupportedCommunicationType>().HasOne(m => m.PhoneCharacteristic)
                .WithMany(n => n.SupportedCommunicationTypes)
                .HasForeignKey(k => k.PhoneCharacteristicId);

            modelBuilder.Entity<Phone>().HasOne(m => m.Order).WithMany(n => n.Phones)
                .HasForeignKey(k => k.OrderId);

            modelBuilder.Entity<Phone>().HasOne(m => m.Characteristic).WithOne(n => n.Phone)
                .HasForeignKey<Phone>(k => k.CharacteristicId);

            modelBuilder.Entity<Order>().HasOne(m => m.Profile).WithOne(n => n.Order)
                .HasForeignKey<Order>(k => k.ProfileId);

            modelBuilder.Entity<CommunicationType>().HasData(new CommunicationType()
                {
                    Id = 1,
                    CommunicationName = "4G",
                    CommunicationSubType = "IMT Advanced",
                    SupportedCommunicationTypes = null
                },
                new CommunicationType()
                {
                    Id = 2,
                    CommunicationName = "4G",
                    CommunicationSubType = "LTE Advanced Pro",
                    SupportedCommunicationTypes = null
                },
                new CommunicationType()
                {
                    Id = 3,
                    CommunicationName = "3G",
                    CommunicationSubType = "LTE",
                    SupportedCommunicationTypes = null
                });
        }
    }
}