using PlayerInfoGQL.Models;

namespace PlayerInfoGQL.GraphQL.Types
{
    public class AnalysisResultType: ObjectType<AnalysisResult>
    {
        protected override void Configure(IObjectTypeDescriptor<AnalysisResult> descriptor)
        {
            descriptor.Description("Holds all possible overall analysis result values.");
            descriptor.Field(a => a.Description).Description("An analysis result value.");
        }
    }
}