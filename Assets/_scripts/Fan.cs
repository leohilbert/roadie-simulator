using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fan : MonoBehaviour
{
    private static float EVENT_COOLDOWN_DURATION = 10F;
    public Transform target;
    public List<Vector3> waypoints;
    NavMeshAgent agent;
    private float normalSpeed;
    private GameObject circlepitPoint;
    public GameObject circlepitPrefab;

    private float eventCooldown = EVENT_COOLDOWN_DURATION;
    private float chillTimer = 0;

    internal Transform circlepitRoot;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        normalSpeed = Random.Range(1F, 3F);
        agent.speed = normalSpeed;
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.speed = normalSpeed;
            eventCooldown -= Time.deltaTime;
            if (chillTimer > 0)
            {
                chillTimer -= Time.deltaTime;
            }
            else if (circlepitRoot != null && eventCooldown < 0)
            {
                circlepitPoint = Instantiate(circlepitPrefab, circlepitRoot.transform.position, Quaternion.identity, circlepitRoot);
                Destroy(circlepitPoint, Random.Range(10F, 15F));
                target = circlepitPoint.transform;
                eventCooldown = EVENT_COOLDOWN_DURATION;
                agent.speed *= 2;
            }
            else if (agent.remainingDistance <= agent.stoppingDistance)
            {
                chillTimer = Random.Range(0F, 20F);
                agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)]);
            }
        }
    }
}
