using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEntity : MonoBehaviour
{
    private NavMeshAgent agent;

    internal void ProceedToCoordinates(Vector3 target)
    {
        agent.SetDestination(target);
    }

    internal virtual void Idle() { }
}
