namespace SpaceBattle.Lib;

public class ThreadsDomainStrategy : IStrategy
{
    public ConcurrentDictionary<String, ServerThread> ThreadsDomain;

    public ThreadsDomainStrategy() => ThreadsDomain = new ConcurrentDictionary<String, ServerThread>();

    public object Execute(object[] args)
    {
       return ThreadsDomain;
    }
}

public class ThreadsDomainGetStrategy : IStrategy
{
    public object Execute(params object[] args)
    {
        string id = (string) args[0];

        var dict = IoC.Resolve<ConcurrentDictionary<string, ServerThread>>("Game.Threads.Domain");
        return dict[id];
    }
}

public class ThreadsDomainSetStrategy : IStrategy
{
    public object Execute(params object[] args)
    {
        string id = (string) args[0];
        ServerThread thread = (ServerThread) args[1];

        var SetCommand = new ThreadsDomainSetCommand(id, thread);
        return SetCommand;
    }
}
