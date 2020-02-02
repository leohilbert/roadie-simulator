using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject camNormal;
    public GameObject camshakesmall;
    public GameObject camshakemedium;
    public GameObject camshakestrong;
    
    public GameObject boxStage;
    public GameObject boxCrowd;

    public GameObject pointer;

    [Header("Set dynamically")]
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    
    /*
    Vector3 camPosBoth = new Vector3(13.3f, 8.4f, 2.6f);
    Quaternion camRotBoth = Quaternion.identity;

    Vector3 camPosStage = new Vector3(12.8f, 2.1f, -14.5f);
    Quaternion camRotStage = Quaternion.Euler(356.36f, 0, 0);

    Vector3 camPosCrowd = new Vector3(13.3f, 3.4f, -0.3f);
    Quaternion camRotCrowd = Quaternion.Euler(344.75f, 0, 0);
    */

    [Header("ShakeLevel")]
    [SerializeField] ShakeLevel shakeLevel = ShakeLevel.none;

    private void Start()
    {
        player1 = GameObject.Find("Player_1");
        player2 = GameObject.Find("Player_2");
    }

    // Update is called once per frame
    void Update()
    {
        switch(shakeLevel)
        {
            case ShakeLevel.none:
                camNormal.SetActive(true);
                camshakesmall.SetActive(false);
                camshakemedium.SetActive(false);
                camshakestrong.SetActive(false);
                break;
            case ShakeLevel.small:
                camNormal.SetActive(false);
                camshakesmall.SetActive(true);
                camshakemedium.SetActive(false);
                camshakestrong.SetActive(false);
                break;
            case ShakeLevel.medium:
                camNormal.SetActive(false);
                camshakesmall.SetActive(false);
                camshakemedium.SetActive(true);
                camshakestrong.SetActive(false);
                break;
            case ShakeLevel.strong:
                camNormal.SetActive(false);
                camshakesmall.SetActive(false);
                camshakemedium.SetActive(false);
                camshakestrong.SetActive(true);
                break;
            default:
                break;
        }

        /*
        if (player1.GetComponent<PlayerParams>().OnStage() && player2.GetComponent<PlayerParams>().OnStage())
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, camPosStage, 0.1f);
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, camRotStage, 0.1f);
        }
        else if ((player1.GetComponent<PlayerParams>().OnStage() && player2.GetComponent<PlayerParams>().InCrowd()) ||
            player1.GetComponent<PlayerParams>().InCrowd() && player2.GetComponent<PlayerParams>().OnStage())
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, camPosBoth, 0.1f);
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, camRotBoth, 0.1f);

        }
        else if(player1.GetComponent<PlayerParams>().InCrowd() && player2.GetComponent<PlayerParams>().InCrowd())
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, camPosCrowd, 0.1f);
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, camRotCrowd, 0.1f);
        }
        */
    }



    public void ChangeShakeLevel(ShakeLevel _shakeLevel)
    {
        shakeLevel = _shakeLevel;
    }
}

public enum ShakeLevel
{
    none, small, medium, strong
}
