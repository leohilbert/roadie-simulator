using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    public Musician[] musicians;

    public Text statusText;

    public float concertQuality;

    GameObject bandometer;
    GameObject camera1, camera2;
    //ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        // bandometer = GameObject.Find("bandometer");
        camera1 = GameObject.Find("Camera 1");
        camera2 = GameObject.Find("Camera 2");
        //ps = camera1.transform.GetChild(4).transform.GetComponent<ParticleSystem>();
    }

    void SetShakeLevel(ShakeLevel level)
    {
        camera1.GetComponent<CameraControl>().ChangeShakeLevel(level);
        camera2.GetComponent<CameraControl>().ChangeShakeLevel(level);
    }

    // Update is called once per frame
    void Update()
    {
        concertQuality = 0;
        foreach (Musician m in musicians)
        {
            concertQuality += m.GetStatus();
        }

        concertQuality /= musicians.Length;

        //Debug.Log(statusText.SetT);
        //statusText.text = $"{avg}";
        //statusText.text = "Hallo";

        if (concertQuality > 0.9)
        {
            statusText.text = "The Band is rocking!";
            SetShakeLevel(ShakeLevel.none);
            //camera1.GetComponent<CameraControl>().pointer.SetActive(false);
        }
        else if (concertQuality > 0.7)
        {
            statusText.text = "The Band is doing okay!";
            SetShakeLevel(ShakeLevel.small);
            //camera1.GetComponent<CameraControl>().pointer.SetActive(true);
        }
        else if (concertQuality > 0.4)
        {
            statusText.text = "The Band is struggeling!";
            SetShakeLevel(ShakeLevel.medium);

        }
        else if (concertQuality > 0.1)
        {
            statusText.text = "The Band is in a bad shape!!";
            SetShakeLevel(ShakeLevel.strong);
        }
        else
        {
            statusText.text = "Game Over!";
            SetShakeLevel(ShakeLevel.strong);
        }

        // rotate the pointer on the bandometer
        //float angle = Mathf.Min(-59, -50f + (concertQuality - 1) * 80f);
        //bandometer.transform.GetChild(0).transform.localRotation = Quaternion.RotateTowards(bandometer.transform.GetChild(0).transform.localRotation, Quaternion.Euler(angle, 0f, 0f), 1f);
    }
}
