using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// idle state for when enemy is not doing anything (can be used between states or when it's not in any other state)
public class IdleState : EnemyAiState
{

    float time, idleTime;

    public void Enter(AiAgent agent)
    {
        time = 0;
        idleTime = agent.config.idleTime; // idle time can be changed in config file
        agent.agentAudio.Stop();

        // sets destination to current position of nav agent so it doesn't move
        agent.navAgent.SetDestination(agent.navAgent.transform.position);
    }

    public void Exit(AiAgent agent)
    {
      
    }

    public StateId GetId()
    {
        return StateId.Idle;
    }

    public void Update(AiAgent agent)
    {
        time += Time.deltaTime;
        if (time > idleTime)
        {
            if (!agent.config.isStaticEnemy) {
                agent.statemachine.updateCurrentState(StateId.Patrol);
            } 
            else{
                agent.statemachine.updateCurrentState(StateId.GoToStartingPoint);
            }

        }
    }


}
