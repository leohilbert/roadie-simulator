using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fan : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target != null){
        agent.SetDestination(target.position);
        }else{
            
        }
    }
}
