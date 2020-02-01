using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject camNormal, camshakesmall, camshakemedium, camshakestrong;

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
