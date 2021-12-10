using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMS.Domain;

namespace VMS.Services
{
    public class NotificationService : INotificationService
    {
        public async Task<IList<Interest>> ListAll()
        {
            return await Task.FromResult(InterestTestData.Interests);
        }
    }

    public interface INotificationService
    {
        Task<IList<Interest>> ListAll();
    }

    static class InterestTestData
    {
        public static List<Interest> Interests = new List<Interest>
        {
            new Interest
            {
                Id = 1,
                Name = "Sports",
                Selected = false
            },
            new Interest
            {
                Id = 2,
                Name = "Music",
                Selected = true
            },
            new Interest
            {
                Id = 3,
                Name = "Animals",
                Selected = false
            },

        };
    }

}
