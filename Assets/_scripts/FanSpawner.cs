using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpawner : MonoBehaviour
{
    public MeshFilter spawnArea;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] vertices = spawnArea.mesh.vertices;
        Debug.Log(spawnArea.mesh.vertexCount);
        int spawnRate = 0;
        foreach (Vector3 point in vertices)
        {
            Vector3 transformedPoint = Vector3.Scale(point, spawnArea.transform.localScale) + spawnArea.transform.position;
            if (spawnRate++ % 3 == 0)
            {

                var fan = Instantiate(prefab, transformedPoint, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
