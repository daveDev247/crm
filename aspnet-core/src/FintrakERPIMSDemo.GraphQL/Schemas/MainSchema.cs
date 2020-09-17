using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using FintrakERPIMSDemo.Queries.Container;

namespace FintrakERPIMSDemo.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}