using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Comment OnCommentAdded([EventMessage] Comment comment) => comment;
    }
}