using System.Reflection;

namespace Solution.WebAPI.Configurations;

public static class DomainAssemblyReference
{
    public static readonly Assembly Assembly = typeof(DomainAssemblyReference).Assembly;
}
