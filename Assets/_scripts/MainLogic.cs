using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    public Musician[] musicians;

    public Text statusText;

    public float concertQuality;

    // Start is called before the first frame update
    void Start()
    {

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
        }
        else if (concertQuality > 0.7)
        {
            statusText.text = "The Band is doing okay!";
        }
        else if (concertQuality > 0.4)
        {
            statusText.text = "The Band is struggeling!";
        }
        else if (concertQuality > 0.1)
        {
            statusText.text = "The Band is in a bad shape!!";
        }
        else
        {
            statusText.text = "Game Over!";
        }
    }
}
