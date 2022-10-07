﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script allows us to hold changable variables used throughout different states in one script
[CreateAssetMenu()]
public class AiAgentConfig : ScriptableObject
{
    public float idleTime = 10.0f; // used in idle state to determine how long agent is idle before patrolling.
    public GameObject waypointParent; // used in patrol state so agent knows waypoints it is patrolling on
    public bool isStaticEnemy; // set to true if enemy is not a patrolling enemy
    public Vector3 spawnPos; // to store spawn pos of ai agent
    public Quaternion spawnRot; // to store rotation of spawn
    
}
