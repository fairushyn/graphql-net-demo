using HotChocolate.Types;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Api.ObjectTypes
{
    public class TimeSheetObjectType : ObjectType<TimeSheet>
    {
        protected override void Configure(IObjectTypeDescriptor<TimeSheet> descriptor)
        {
            descriptor.Field(x => x.ApprovedByEmployeeId).Ignore();

            descriptor.Field("customResolverField")
                .Description("Description for custom field")
                .Resolve((context, ct) =>
                {
                    // fetch value for a field
                    return "CustomValue";
                });
        }
    }
}
