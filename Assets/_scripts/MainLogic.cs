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
    GameObject camera;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        bandometer = GameObject.Find("bandometer");
        camera = GameObject.Find("Camera");
        ps = camera.transform.GetChild(4).transform.GetComponent<ParticleSystem>();
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
            camera.GetComponent<CameraControl>().ChangeShakeLevel(ShakeLevel.none);
            camera.GetComponent<CameraControl>().pointer.SetActive(false);
        }
        else if (concertQuality > 0.7)
        {
            statusText.text = "The Band is doing okay!";
            camera.GetComponent<CameraControl>().ChangeShakeLevel(ShakeLevel.small);
            camera.GetComponent<CameraControl>().pointer.SetActive(true);
        }
        else if (concertQuality > 0.4)
        {
            statusText.text = "The Band is struggeling!";
            camera.GetComponent<CameraControl>().ChangeShakeLevel(ShakeLevel.medium);

        }
        else if (concertQuality > 0.1)
        {
            statusText.text = "The Band is in a bad shape!!";
            camera.GetComponent<CameraControl>().ChangeShakeLevel(ShakeLevel.strong);
        }
        else
        {
            statusText.text = "Game Over!";
        }

        // rotate the pointer on the bandometer
        float angle = Mathf.Min(-59, -50f + (concertQuality - 1) * 80f);
        bandometer.transform.GetChild(0).transform.localRotation = Quaternion.RotateTowards(bandometer.transform.GetChild(0).transform.localRotation, Quaternion.Euler(angle, 0f, 0f), 1f);
    }
}
