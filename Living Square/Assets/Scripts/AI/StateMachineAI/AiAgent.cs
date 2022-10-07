using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// AiAgent script is the main brain for the AI, it holds references to all the components required for the statemachine
// The state machine uses the agent as an argument so it can access the variables within the agent
public class AiAgent : MonoBehaviour
{

    // variables to manage state machine, nav mesh and animator
    public StateMachine statemachine; // variable to hold statemachine for AiAgent
    public StateId entryState = StateId.Idle; // sets entry state for statemachine use
    public NavMeshAgent navAgent; // variable to hold navAgent
    public AiAgentConfig config; // variable which holds config
    public Animator anim; // variable to hold the animator
    public StateId currentState;
    public FieldOfView fov;

    // variables for AI to access player information
    public bool playerSeen = false;
    public bool chasingPlayer = false;
    public Transform playerLocation;

    // Start is called before the first frame update
    void Start()
    {
        // instantiates statemachine using agent and assigns components to variables for easy access
        statemachine = new StateMachine(this); // AIAgent sends itself as an arg to statemachine so statemachine can access variables
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        fov = GetComponent<FieldOfView>();

        // registers different states
        statemachine.RegisterState(new PatrolState());
        statemachine.RegisterState(new IdleState());
        statemachine.RegisterState(new InvestigateState());
        statemachine.RegisterState(new ChasePlayerState());

        statemachine.updateCurrentState(entryState); // sets the entry state for the statemachine

        // checks if it's a non-patrolling static enemy and instantiates respective variables
        if (config.isStaticEnemy)
        {
            config.spawnPos = transform.position; // gets the spawn/start position of enemy if it's static (non-patrolling)
            config.spawnRot = transform.rotation; // gets spawn/start rotation of enemy if it's static (non-patrolling)
            statemachine.RegisterState(new GoToStartingPosState());
        }


        //instantiates playerSeen default to false and gets player location for later use
        playerSeen = false;
        playerLocation = GameObject.FindWithTag("Player").transform;


    }

    // Update is called once per frame
    // As AiAgent is a monoscript the update function is called automatically by unity
    // and because the statemachine is no a monoscript, we call the update function within the AiScript for the statemachine
    void Update()
    {
        statemachine.Update(); // used to call the update method of the current state
        currentState = statemachine.currentState; // for debugging purposes (to keep track of the current state when testing)
    }
}
