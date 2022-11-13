
namespace ConversationService.Api.Models
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