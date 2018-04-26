using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL.Models;

namespace DAL.Migrations
{
    [DbContext(typeof(PersonelContext))]
    [Migration("20180418170259_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.AccountType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.ToTable("AccountType");
                });

            modelBuilder.Entity("DAL.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<string>("Apartment");

                    b.Property<string>("City");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Email");

                    b.Property<int?>("PersonId");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<string>("Suburb");

                    b.HasKey("id");

                    b.HasIndex("CountryId");

                    b.HasIndex("PersonId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DAL.Models.Bank", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("DAL.Models.BankAccount", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber");

                    b.Property<int?>("AccountTypeId");

                    b.Property<bool?>("Active");

                    b.Property<int?>("BankId");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("PersonId");

                    b.HasKey("id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("BankId");

                    b.HasIndex("PersonId");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("DAL.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DAL.Models.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("DAL.Models.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("MapLocation");

                    b.Property<int?>("UserId");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("DAL.Models.MessageType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Type");

                    b.HasKey("id");

                    b.ToTable("MessageType");
                });

            modelBuilder.Entity("DAL.Models.Notification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("NotificationTypeId");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("UserId");

                    b.HasKey("id");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("PersonId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("DAL.Models.NotificationContent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<string>("Body");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Subject");

                    b.HasKey("id");

                    b.ToTable("NotificationContent");
                });

            modelBuilder.Entity("DAL.Models.NotificationType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<int?>("ContentTypeId");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("MessageTypeId");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.HasIndex("ContentTypeId");

                    b.HasIndex("MessageTypeId");

                    b.ToTable("NotificationType");
                });

            modelBuilder.Entity("DAL.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("FirstName");

                    b.Property<string>("IdNumber");

                    b.Property<string>("LastName");

                    b.Property<string>("PassportNumber");

                    b.Property<byte[]>("Photo");

                    b.HasKey("id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("DAL.Models.PersonSkill", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("SkillId");

                    b.HasKey("PersonId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("PersonSkill");
                });

            modelBuilder.Entity("DAL.Models.Request", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Note");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("UserId");

                    b.HasKey("id");

                    b.HasIndex("PersonId");

                    b.HasIndex("UserId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("DAL.Models.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("Level");

                    b.Property<int>("PersonId");

                    b.Property<string>("Remark");

                    b.Property<int>("SkillId");

                    b.Property<int>("UserId");

                    b.HasKey("id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("DAL.Models.Skill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("DAL.Models.Support", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<string>("CellNumber");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Email");

                    b.Property<string>("Message");

                    b.Property<int>("SubjectId");

                    b.HasKey("id");

                    b.ToTable("Support");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<string>("ClearPassword");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("ForgottenPasswordToken");

                    b.Property<string>("HashedPassword");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("ProfilePic");

                    b.Property<string>("TelephoneNumber");

                    b.Property<string>("VerifyAccountToken");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DAL.Models.Address", b =>
                {
                    b.HasOne("DAL.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("DAL.Models.BankAccount", b =>
                {
                    b.HasOne("DAL.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId");

                    b.HasOne("DAL.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("DAL.Models.Location", b =>
                {
                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DAL.Models.Notification", b =>
                {
                    b.HasOne("DAL.Models.Notification", "NotificationType")
                        .WithMany()
                        .HasForeignKey("NotificationTypeId");

                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DAL.Models.NotificationType", b =>
                {
                    b.HasOne("DAL.Models.NotificationContent", "NotificationContent")
                        .WithMany()
                        .HasForeignKey("ContentTypeId");

                    b.HasOne("DAL.Models.MessageType", "MessageType")
                        .WithMany()
                        .HasForeignKey("MessageTypeId");
                });

            modelBuilder.Entity("DAL.Models.PersonSkill", b =>
                {
                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany("PersonSkill")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Skill", "Skill")
                        .WithMany("PersonSkill")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Request", b =>
                {
                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DAL.Models.Review", b =>
                {
                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Skill", b =>
                {
                    b.HasOne("DAL.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
