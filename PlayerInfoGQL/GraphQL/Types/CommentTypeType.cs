
namespace PlayerInfoGQL.GraphQL.Types{
    public class CommentTypeType: ObjectType<Models.CommentType>
    {
        protected override void Configure(IObjectTypeDescriptor<Models.CommentType> descriptor)
        {
            descriptor.Description("Holds all possible comment type values.");
            descriptor.Field(c => c.Description).Description("Represents a type of a comment i.e. positive, negative, neutral.");
        }
    }
}