using AdessoWorldLeague.Controllers.Requests;
using FluentValidation;

namespace AdessoWorldLeague.Controllers.Validators;

public class GroupsRequestValidator :AbstractValidator<CreateGroupsRequest>
{
    public GroupsRequestValidator()
    {
        CascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.RequesterName)
            .NotEmpty();
        
        RuleFor(x => x.RequesterSurname)
            .NotEmpty();

        RuleFor(x => x.GroupType)
            .IsInEnum();
    }
    
}