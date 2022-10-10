using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class PathChecker
{
    AiAgent agent;
    NavMeshAgent navAgent;
    public PathChecker(AiAgent agent)
    {
        this.agent = agent;
        navAgent = agent.navAgent;
    }

    public bool checkPath(Vector3 target)
    {
        NavMeshPath path = new NavMeshPath();

        navAgent.CalculatePath(target, path);

        if (path.status != NavMeshPathStatus.PathComplete)
        {
            agent.hasPath = false;
            return false;
        }

        else
        {
            agent.hasPath = true;
            return true;
        }


    }

    public void checkPath()
    {
        NavMeshPath path = new NavMeshPath();

        navAgent.CalculatePath(navAgent.destination, path);

        if (path.status != NavMeshPathStatus.PathComplete)
        {
            agent.hasPath = false;
        }

        else
        {
            agent.hasPath = true;
        }


    }
}
