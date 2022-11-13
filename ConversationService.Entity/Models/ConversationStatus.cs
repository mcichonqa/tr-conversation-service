
namespace ConversationService.Entity.Models
{
    public enum ConversationStatus
    {
        WaitingForApprove,
        NoSubscription,
        Approved,
        WaitingToJoin,
        DuringConversation,
        Closed
    }
}