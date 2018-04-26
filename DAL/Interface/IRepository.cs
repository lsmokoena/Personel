using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Interface
{
    public interface IUserRepository: IGenericDataRepository<User> { }
    public interface IBankRepository : IGenericDataRepository<Bank> { }
    public interface IAccountTypeRepository : IGenericDataRepository<AccountType> { }
    public interface IBankAccountRepository : IGenericDataRepository<BankAccount> { }
    public interface ISupportRepository : IGenericDataRepository<Support> { }
    public interface IAddressRepository : IGenericDataRepository<Address> { }
    public interface ICountryRepository : IGenericDataRepository<Country> { }
    public interface INotificationRepository : IGenericDataRepository<Notification> { }
    public interface IPersonRepository : IGenericDataRepository<Person> { }
    public interface IReviewRepository : IGenericDataRepository<Review> { }
    public interface ISkillRepository : IGenericDataRepository<Skill> { }
    public interface ICategoryRepository : IGenericDataRepository<Category> { }
    public interface ILocationRepository : IGenericDataRepository<Location> { }
    public interface IRequestRepository : IGenericDataRepository<Request> { }
    public interface INotificationContentRepository : IGenericDataRepository<NotificationContent> { }
    public interface INotificationTypeRepository : IGenericDataRepository<NotificationType> { }
    public interface IMessageTypeRepository : IGenericDataRepository<MessageType> { }
}
