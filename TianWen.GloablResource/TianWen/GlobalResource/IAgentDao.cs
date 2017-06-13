namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.Generic;
    using TianWen.Plus4MEF;

    public interface IAgentDao : ITianWenComponent
    {
        Agent GetAgent(string agentId);
        IList<AgentRight> GetAgentRightById(string agentId);
        IList<Agent> GetAllAgent();
        IList<AgentRight> GetAllAgentRight();
    }
}

