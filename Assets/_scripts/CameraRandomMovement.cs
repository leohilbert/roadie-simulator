using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRandomMovement : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 direction;

    public GameObject camNormal, camShake;

    float speed = 0.0005f;
    public bool shaking = false;
    public float normalSpeed = 0.5f;
    public float shakeSpeed;

    public Cinemachine.CinemachineVirtualCamera cam;
    Cinemachine.CinemachineVirtualCamera defaultCamSettings;
    Cinemachine.CinemachineVirtualCamera shakeCamSettings;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        direction = Random.insideUnitSphere;

        shakeSpeed = normalSpeed * 10f;

        defaultCamSettings = cam;

        gameObject.transform.GetComponent<Rigidbody>().velocity = direction * normalSpeed;
    }

    private void Update()
    {
        if(shaking)
        {
            speed = shakeSpeed;
            camShake.SetActive(true);
            camNormal.SetActive(false);
        }
        else
        {
            speed = normalSpeed;
            camShake.SetActive(false);
            camNormal.SetActive(true);
        }
        gameObject.transform.GetComponent<Rigidbody>().velocity = gameObject.transform.GetComponent<Rigidbody>().velocity.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 new_direction = Vector3.zero;
        if(collision.gameObject.tag == "FollowBox")
        {
            if(collision.gameObject.name == "Left")
            {
                new_direction = new Vector3(-Random.Range(0.1f, 1), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
            }
            else if(collision.gameObject.name == "Right")
            {
                new_direction = new Vector3(Random.Range(0.1f, 1), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
            }
            else if(collision.gameObject.name == "Top")
            {
                new_direction = new Vector3(Random.Range(-1f, 1f), -Random.Range(0.1f, 1), Random.Range(-1f, 1f)).normalized * speed;
            }
            else if (collision.gameObject.name == "Bottom")
            {
                new_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(0.1f, 1), Random.Range(-1f, 1f)).normalized * speed;
            }
            else if (collision.gameObject.name == "Front")
            {
                new_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -Random.Range(0.1f, 1)).normalized * speed;
            }
            else if (collision.gameObject.name == "Back")
            {
                new_direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(0.1f, 1)).normalized * speed;
            }
            gameObject.transform.GetComponent<Rigidbody>().velocity = new_direction;
        }
    }
}
