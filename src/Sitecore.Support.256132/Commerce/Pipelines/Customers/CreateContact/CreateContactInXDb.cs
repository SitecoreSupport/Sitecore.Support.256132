using Sitecore.Commerce.Data.Customers;
using Sitecore.Commerce.Entities;
using Sitecore.Commerce.Pipelines;
using Sitecore.Commerce.Services.Customers;
using Sitecore.Xdb.Configuration;

namespace Sitecore.Support.Commerce.Pipelines.Customers.CreateContact
{
  public class CreateContactInXDb : Sitecore.Commerce.Pipelines.Customers.CreateContact.CreateContactInXDb
  {
    public CreateContactInXDb(IUserRepository userRepository, IEntityFactory entityFactory) : base(userRepository, entityFactory) { }

    public override void Process(ServicePipelineArgs args)
    {
      CreateUserRequest request = (CreateUserRequest)args.Request;
      CreateUserResult result = (CreateUserResult)args.Result;
      if (XdbSettings.Enabled)
      {
        string userIdentifier = this.GetUserIdentifier(result);
        this.CreateContact(userIdentifier, result);
      }

    }
  }
}

