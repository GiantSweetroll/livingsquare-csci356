using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateState : EnemyAiState
{

    Vector3 playerLastPosition; // gets players last known position
    float time = 0.0f; // tracks time
    float timeToWait = 2.0f; // controls the time it takes for AI to walk to players last known position
    bool soundPlaying = false;

    public void Enter(AiAgent agent)
    {
        // if statement determines if it was just chasing the player or not
        // if it wasn't chasing the player then it stops before moving to the players position
        if (!agent.chasingPlayer)
        {
            agent.navAgent.SetDestination(agent.navAgent.transform.position); // makes navmesh agent stop if not chasing player
        }
 
        playerLastPosition = GameObject.FindWithTag("Player").transform.position; // gets last position player was spotted
        
        // script rotates the agent towards where it spotted the player
        var turnTowardTarget = agent.navAgent.steeringTarget;
        Vector3 direction = (turnTowardTarget - agent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(turnTowardTarget);
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * 5);



    }

    public void Exit(AiAgent agent)
    {
        // sets walking to false
        // if was chasing the player but can no longer see the player then it will 
        // set running to false and set chasing player to false
        agent.anim.SetBool("walking", false);
        if (agent.chasingPlayer && !agent.playerSeen)
        {
            agent.anim.SetBool("running", false);
            agent.chasingPlayer = false;
        }

        
    }

    public StateId GetId()
    {
        return StateId.Investigate;
    }

    public void Update(AiAgent agent)
    {
        
       
        // first if statement is if the enemy spots the player but is not currently chasing the player
        time += Time.deltaTime;
        if(time > timeToWait && !agent.chasingPlayer) // has agent wait before moving towards player position
        {

            // only plays audio if it currently isnt
            if (!agent.agentAudio.audioSource.isPlaying)
            {
                agent.agentAudio.Walk();
            }

            agent.anim.SetBool("walking", true);
            
            agent.navAgent.SetDestination(playerLastPosition);


            // checks if nav agent has reached destination (new code which may need to be implemented in other scripts)
            // waits for agent to finish it's path before going back to idle state
            if (!agent.navAgent.pathPending)
            {
                if (agent.navAgent.remainingDistance <= agent.navAgent.stoppingDistance)
                {
                    if (!agent.navAgent.hasPath || agent.navAgent.velocity.sqrMagnitude == 0f)
                    {
                        agent.statemachine.updateCurrentState(StateId.Idle);
                    }
                }
            }
        } 
        // if statement for if the enemy is currently chasing the player but can no longer see the player
        else if (agent.chasingPlayer)
        {
            agent.navAgent.SetDestination(playerLastPosition); // goes to last known position

            // only plays audio if it currently isnt
            if (!agent.agentAudio.audioSource.isPlaying)
            {
                agent.agentAudio.Run();
            }

            if (!agent.navAgent.pathPending) // checks if a path is pending
            {
                if (agent.navAgent.remainingDistance <= agent.navAgent.stoppingDistance) // checks if it's within stopping distance of the destination
                {
                    if (!agent.navAgent.hasPath || agent.navAgent.velocity.sqrMagnitude == 0f) // checks if it still has a path to follow
                    {
                        agent.statemachine.updateCurrentState(StateId.Idle);
                    }
                }
            }

        }

        
    }

}
