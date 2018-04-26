using System;
using System.Linq;
using DAL.Models;

namespace DAL.Data
{
    public class DSM_DbInitializer
    {
        private static PersonelContext context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (PersonelContext)serviceProvider.GetService(typeof(PersonelContext));

            InitializeUsers();
        }

        private static void InitializeUsers()
        {
            context.CreateAndMigrateDatabase();
            using (var tran = context.Database.BeginTransaction())
            {
                if (!context.User.Any())
                {
                    var email = new MessageType() { Type = "Email", Active = true };
                    var sms = new MessageType() { Type = "SMS", Active = true };

                    var nContent1 = new NotificationContent() { Subject = "Welcome", Body = "Welcome to our new platform.", Active = true };
                    var nContent2 = new NotificationContent() { Subject = "Confirm Email", Body = "Please click link to confirm email.", Active = true };
                    var nContent3 = new NotificationContent() { Subject = "Reset Password", Body = "Please click link to reset your password.", Active = true };

                    var nType1 = new NotificationType() { Name = "Welcome", NotificationContent = nContent1, MessageType = email, Active = true };
                    var nType2 = new NotificationType() { Name = "Confirm Email", NotificationContent = nContent2, MessageType = email, Active = true };
                    var nType3 = new NotificationType() { Name = "Reset Password", NotificationContent = nContent3, MessageType = email, Active = true };

                    var current = new AccountType() { Name = "Current", Active = true };
                    var savings = new AccountType() { Name = "Savings", Active = true };
                    var transmission = new AccountType() { Name = "Transmission", Active = true };

                    var fnb = new Bank() { Name = "FNB", DateCreated = DateTime.Now, Active = true };
                    var absa = new Bank() { Name = "ABSA", DateCreated = DateTime.Now, Active = true };
                    var capitec = new Bank() { Name = "Capitec", DateCreated = DateTime.Now, Active = true };
                    var nedbank = new Bank() { Name = "Nedbank", DateCreated = DateTime.Now, Active = true };
                    var standardBank = new Bank() { Name = "Standard Bank", DateCreated = DateTime.Now, Active = true };

                    var category = new Category() { Name = "House keeping", Active = true };

                    var skill1 = new Skill() { Name = "Nanny", Category = category, Active = true };

                    var nanny1 = new Person() { FirstName = "Mavis", LastName = "Mazibuko", IdNumber = "6301028564085",  Active = true};
                    var nanny2 = new Person() { FirstName = "Peggy", LastName = "Mofokeng", IdNumber = "7705078574085", Active = true };
                    var nanny3 = new Person() { FirstName = "Rejoyce", LastName = "Mkhize", IdNumber = "7005058544085", Active = true };

                    var bankA1 = new BankAccount() { AccountNumber = "9653225844", AccountType = savings, Bank = absa, Person = nanny1, Active = true };
                    var bankA2 = new BankAccount() { AccountNumber = "9653225844", AccountType = savings, Bank = absa, Person = nanny2, Active = true };
                    var bankA3 = new BankAccount() { AccountNumber = "9653225844", AccountType = savings, Bank = absa, Person = nanny3, Active = true };

                    var southAfrica = new Country() { Name = "South Africa", Active = true };
                    var lesotho = new Country() { Name = "Lesotho", Active = true };
                    var swaziland = new Country() { Name = "Swaziland", Active = true };
                    var mozambique = new Country() { Name = "Mozambique", Active = true };
                    var zimbabwe = new Country() { Name = "Zimbabwe", Active = true };
                    var namibia = new Country() { Name = "Namibia", Active = true };
                    
                    var address1 = new Address() {Apartment = "15928",  Street = "Inqoba", Suburb = "Vosloorus", City = "Joburg", Country = southAfrica, PostalCode = "3625", Email = "mavis@mailinator.com", Person = nanny1, Active = true };
                    var address2 = new Address() { Apartment = "45262", Street = "Igwalagwala", Suburb = "Vosloorus", City = "Joburg", Country = southAfrica, PostalCode = "7452", Email = "peggy@mailinator.com", Person = nanny1, Active = true };
                    var address3 = new Address() { Apartment = "86532", Street = "Bierman", Suburb = "Vosloorus", City = "Joburg", Country = southAfrica, PostalCode = "5652", Email = "rejoys@mailinator.com", Person = nanny1, Active = true };

                    var user_01 = new User { Name = "John Maduna", Email = "jmaduna@mailinator.com", FirstName = "John", LastName = "Maduna", TelephoneNumber = "0721548653", ClearPassword = "Password123!", HashedPassword = Util.PasswordHelper.GetStringHash("Password123!"), Active = true };

                    context.MessageType.Add(email);
                    context.MessageType.Add(sms);

                    context.NotificationContent.Add(nContent1);
                    context.NotificationContent.Add(nContent2);
                    context.NotificationContent.Add(nContent3);

                    context.NotificationType.Add(nType1);
                    context.NotificationType.Add(nType2);
                    context.NotificationType.Add(nType3);
                    
                    context.AccountType.Add(current);
                    context.AccountType.Add(savings);
                    context.AccountType.Add(transmission);

                    context.Bank.Add(fnb);
                    context.Bank.Add(absa);
                    context.Bank.Add(capitec);
                    context.Bank.Add(nedbank);
                    context.Bank.Add(standardBank);
                    
                    context.Category.Add(category);

                    context.Skill.Add(skill1);

                    context.Person.Add(nanny1);
                    context.Person.Add(nanny2);
                    context.Person.Add(nanny3);

                    context.BankAccount.Add(bankA1);
                    context.BankAccount.Add(bankA2);
                    context.BankAccount.Add(bankA3);

                    context.Country.Add(southAfrica);
                    context.Country.Add(lesotho);
                    context.Country.Add(swaziland);
                    context.Country.Add(mozambique);
                    context.Country.Add(zimbabwe);
                    context.Country.Add(namibia);

                    context.Address.Add(address1);
                    context.Address.Add(address2);
                    context.Address.Add(address3);

                    context.User.Add(user_01);

                    context.SaveChanges();
                }

                tran.Commit();
            }
        }
    }
}
