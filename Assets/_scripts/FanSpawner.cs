using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpawner : MonoBehaviour
{
    public MeshFilter spawnArea;
    public GameObject fanPrefab;
    public Transform circlepitRoot;

    private float circlepitCooldown = 0f;

    private List<Fan> fans = new List<Fan>();

    void Start()
    {
        Vector3[] vertices = spawnArea.mesh.vertices;
        int spawnRate = 0;

        List<Vector3> transformed = new List<Vector3>();
        foreach (Vector3 point in vertices)
        {
            transformed.Add(spawnArea.transform.TransformPoint(point));
        }

        foreach (Vector3 point in transformed)
        {
            var go = Instantiate(fanPrefab, point, Quaternion.identity, transform);
            Fan fan = go.GetComponent<Fan>();
            fan.waypoints = transformed;
            fans.Add(fan);
            if (spawnRate++ % 1.5F == 0)
            {
                fan.circlepitRoot = circlepitRoot;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
