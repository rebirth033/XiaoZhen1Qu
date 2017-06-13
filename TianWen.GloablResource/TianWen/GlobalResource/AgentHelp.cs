using TianWen.Interface;

namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;

    [Obsolete("该类已过期，请使用ComponentFactory.Get<IAgentDao>()来进行数据访问")]
    public class AgentHelp
    {
        private static IAgentDao iagentDao_0 = ComponentFactory.Get<IAgentDao>("AgentDao");

        public static Agent GetAgent(string agentId)
        {
            return iagentDao_0.GetAgent(agentId);
        }

        public static List<AgentRight> GetAgentRight(DataView rightView)
        {
            List<AgentRight> list2;
            try
            {
                List<AgentRight> list = new List<AgentRight>();
                if (rightView.Count > 0)
                {
                    foreach (DataRow row in rightView.Table.Rows)
                    {
                        AgentRight item = new AgentRight {
                            AgentRightID = row["AGENTRIGHTID"].ToString(),
                            UserID = row["USERID"].ToString(),
                            AgentUID = row["AGENTUID"].ToString(),
                            RightType = row["RIGHTTYPE"].ToString(),
                            RightID = row["RIGHTID"].ToString(),
                            RightValue = row["RIGHTVALUE"].ToString()
                        };
                        list.Add(item);
                    }
                }
                list2 = list;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return list2;
        }

        public Collection<AgentRight> GetAgentRightByID(string agentId)
        {
            return new Collection<AgentRight>(iagentDao_0.GetAgentRightById(agentId));
        }

        public static Collection<Agent> GetAllAgent()
        {
            return new Collection<Agent>(iagentDao_0.GetAllAgent());
        }

        public static Collection<AgentRight> GetAllAgentRight()
        {
            return new Collection<AgentRight>(iagentDao_0.GetAllAgentRight());
        }
    }
}

