using Microsoft.AspNetCore.Authorization;

namespace AAASamples.Requirmens;

public class AgePolicyRequirement:IAuthorizationRequirement
{
    public int Age { get; set; }
	public AgePolicyRequirement(int age)
	{
		Age = age;
	}
}
public class AgePolicyRequirementHandler : AuthorizationHandler<AgePolicyRequirement>
{

	protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgePolicyRequirement requirement)
	{
		var random = new Random();
		int userAge = random.Next(15, 20);
		if(userAge >= requirement.Age)
		{
			context.Succeed(requirement);
		}
		return Task.CompletedTask;
	}
}

//public class AppFeatureHandler : AuthorizationHandler<AppFeatureRequirement>
//{
//	private readonly ApplicaitonFeatures _applicaitonFeatures;

//	public AppFeatureHandler(ApplicaitonFeatures applicaitonFeatures)
//	{
//		_applicaitonFeatures = applicaitonFeatures;
//	}
//    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AppFeatureRequirement requirement)
//    {
//		context.User.Claims.Any(c=> c.Type=="AppFfeature" && _applicaitonFeatures.FeatureList.Any(d=>d == c.Value))
//        return Task.CompletedTask;
//    }
//}

//public class AppFeatureRequirement : IAuthorizationRequirement
//{
//}
//public class ApplicaitonFeatures
//{
//	public List<string> FeatureList { get; set; } = new List<string>
//	{
//		"CreateUser",
//		"UpdateUser",

//	};
//}