using ConversationService.Contract.Enums;
using System;

namespace ConversationService.Contract
{
    public class UserSubscription
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public SubscriptionType? SubscriptionType { get; set; }

    }
}