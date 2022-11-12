using ConversationService.Contract.Enums;
using System;

namespace ConversationService.Contract.Events
{
    public sealed class ConversationCreatedEvent
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; set; }
        public UserInfo UserInfo { get; init; }
        public Guid RoomId { get; init; }
        public ConversationType ConversationType { get; set; }
        public bool IsVideoReadyForProcessing { get; set; }
        public UserSubscription UserSubscription { get; init; }

        public ConversationCreatedEvent(Guid id, DateTime createdAt, UserInfo userInfo, ConversationInfo conversationInfo, UserSubscription userSubscription)
        {
            Id = id;
            CreatedAt = createdAt;
            UserInfo = userInfo;
            UserSubscription = userSubscription;
        }
    }
}