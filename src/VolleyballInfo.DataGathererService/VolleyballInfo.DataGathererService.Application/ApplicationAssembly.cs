using System.Reflection;

namespace VolleyballInfo.DataGathererService.Application;

public class ApplicationAssembly
{
    public static readonly Assembly Instance = typeof(ApplicationAssembly).Assembly;
}