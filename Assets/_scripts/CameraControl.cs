using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Cameras")]
    public GameObject camNormal;
    public GameObject camshakesmall;
    public GameObject camshakemedium;
    public GameObject camshakestrong;

    [Header("Player")]
    public GameObject player1;
    public GameObject player2;

    [Header("Boxes")]
    public GameObject boxStage;
    public GameObject boxCrowd;

    Vector3 camPosBoth = new Vector3(12.74f, 3.72f, -6.51f);
    Quaternion camRotBoth = Quaternion.Euler(0, 0, 0);

    Vector3 camPosStage = new Vector3(12.8f, 2.1f, -14.5f);
    Quaternion camRotStage = Quaternion.Euler(-3.64f, 0, 0);

    Vector3 camPosCrowd = new Vector3(12.2f, -1.2f, -0.6f);
    Quaternion camRotCrowd = Quaternion.Euler(-18.85f, 0, 0);

    [Header("ShakeLevel")]
    [SerializeField] ShakeLevel shakeLevel = ShakeLevel.none;

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

        if (player1.GetComponent<PlayerParams>().OnStage() && player2.GetComponent<PlayerParams>().OnStage())
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, camPosStage, 0.1f);
        }
        else if ((player1.GetComponent<PlayerParams>().OnStage() && player2.GetComponent<PlayerParams>().InCrowd()) ||
            player1.GetComponent<PlayerParams>().InCrowd() && player2.GetComponent<PlayerParams>().OnStage())
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, camPosBoth, 0.1f);
        }
        else if(player1.GetComponent<PlayerParams>().InCrowd() && player2.GetComponent<PlayerParams>().InCrowd())
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, camPosCrowd, 0.1f);
        }

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
