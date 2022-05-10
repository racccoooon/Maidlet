namespace Maidlet;

public class MaidletRouterBuilder
{
    private readonly List<RouteGroup> _routeGroups = new List<RouteGroup>();
    
    public RouteGroup AddGroup(string segment)
    {
        var routeGroup = new RouteGroup(segment);
        _routeGroups.Add(routeGroup);
        return routeGroup;
    }

    public RouteGroup AddRoot()
    {
        return AddGroup("");
    }

    public MaidletRouter Build()
    {
        return new MaidletRouter(_routeGroups);
    }   
}

public class MaidletRouter
{
    internal MaidletRouter(List<RouteGroup> routeGroups)
    {
        // todo
    }
}

public class RouteGroup
{
    private readonly string _segment;
    private readonly List<RouteGroup> _routeGroups = new ();
    private readonly List<Type> _controllers = new ();

    public RouteGroup(string segment)
    {
        _segment = segment;
    }
    
    public RouteGroup AddGroup(string segment)
    {
        var routeGroup = new RouteGroup(segment);
        _routeGroups.Add(routeGroup);
        return routeGroup;
    }

    public void AddController(Type controllerType)
    {
        if (!controllerType.IsAssignableTo(typeof(MaidletControllerBase)))
        {
            throw new ArgumentException($"Type {controllerType.FullName} has to extend from MaidletControllerBase.");
        }

        _controllers.Add(controllerType);
    }

    public void AddController<TController>() where TController : MaidletControllerBase
    {
        AddController(typeof(TController));
    }
}