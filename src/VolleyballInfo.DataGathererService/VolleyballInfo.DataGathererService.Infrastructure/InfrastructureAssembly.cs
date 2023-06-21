using System.Reflection;

namespace VolleyballInfo.DataGathererService.Infrastructure;

public class InfrastructureAssembly
{
    public static readonly Assembly Instance = typeof(InfrastructureAssembly).Assembly;
}