using System.Collections.Generic;

public class AgentManager : UnitySingleton<AgentManager>
{
    private List<IAgent> allTheAgents = new();

    public void RegisterAgent(IAgent newAgent)
    {
        if(!allTheAgents.Contains(newAgent))
            allTheAgents.Add(newAgent);
    }

    public void UnregisterAgent(IAgent agent)
    {
        if(allTheAgents.Contains(agent))
            allTheAgents.Remove(agent);
    }

    public List<T> GetAgentsOfType<T>()
    {
        var newList = new List<T>();

        foreach (var agent in allTheAgents)
        {
            if(agent is T typeMatch)
                newList.Add(typeMatch);
        }

        return newList;
    }
}