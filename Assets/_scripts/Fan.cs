﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fan : MonoBehaviour
{
    private static float EVENT_COOLDOWN_DURATION = 10F;
    public Transform target;
    internal List<Vector3> waypoints;
    internal Transform circlepitRoot;
    internal MainLogic mainLogic;
    public GameObject circlepitPrefab;
    public GameObject ragePrefab;

    private NavMeshAgent agent;
    private float eventCooldown = EVENT_COOLDOWN_DURATION;
    private float chillTimer = 0;
    private float speed = 0;

    private GameObject rage;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = Random.Range(1F, 3F);
    }

    void Update()
    {
        if (!agent.isActiveAndEnabled)
        {
            return;
        }
        if (target != null)
        {
            agent.SetDestination(target.position);
            agent.speed = speed * 2;
        }
        else
        {
            agent.speed = speed;
            eventCooldown -= Time.deltaTime;
            if (chillTimer > 0)
            {
                chillTimer -= Time.deltaTime;
            }
            else if (eventCooldown < 0)
            {
                // Wenn die Qualität des Konzerts niedriger wird, soll es wahrscheinlicher sein, dass ein Fan eskaliert
                if (Random.Range(0F, 1F) < Mathf.Pow(1.0f - mainLogic.concertQuality, 32F))
                {
                    target = mainLogic.musicians[UnityEngine.Random.Range(0, mainLogic.musicians.Length)].gameObject.transform;
                    rage = Instantiate(ragePrefab, transform.position, Quaternion.identity, transform);
                    return;
                }
                if (circlepitRoot != null)
                {
                    StartCoroutine(RunCirlePit());
                }
            }
            else if (agent.remainingDistance <= agent.stoppingDistance)
            {
                chillTimer = Random.Range(0F, 20F);
                agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)]);
            }
        }
    }

    public void kick(Transform kicker)
    {
        Debug.Log("kick");
        target = null;

        Vector3 origin = transform.position - kicker.position;
        origin.Normalize();
        origin.y = 1;
        Debug.Log(origin);
        Rigidbody body = this.GetComponent<Rigidbody>();
        body.isKinematic = false;
        GetComponent<NavMeshAgent>().enabled = false;
        float force = Random.Range(1F, 5F);
        body.velocity = Vector3.Scale(origin, new Vector3(force, 10, force));
    }

    public IEnumerator RunCirlePit()
    {
        GameObject circlepitPoint = Instantiate(circlepitPrefab, circlepitRoot.transform.position, Quaternion.identity, circlepitRoot);
        target = circlepitPoint.transform;
        yield return new WaitForSeconds(Random.Range(10F, 15F));
        Destroy(circlepitPoint);
        eventCooldown = EVENT_COOLDOWN_DURATION;
    }
}
