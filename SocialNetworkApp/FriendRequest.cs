namespace SocialNetworkApp
{
    public enum RequestStatus { Sent, Accepted, Rejected }

    public class FriendRequest
    {
        public User Sender { get; }
        public User Receiver { get; }
        public RequestStatus Status { get; set; }

        public FriendRequest(User sender, User receiver)
        {
            Sender = sender;
            Receiver = receiver;
            Status = RequestStatus.Sent;
        }
    }
}
