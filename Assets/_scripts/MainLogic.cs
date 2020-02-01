using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    public Musician[] musicians;

    public Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double avg = 0;
        foreach(Musician m in musicians) 
        {
            avg += m.GetStatus();
        }

        avg /= musicians.Length;

        //Debug.Log(statusText.SetT);
        //statusText.text = $"{avg}";
        //statusText.text = "Hallo";

        if (avg > 0.9)
        {
            statusText.text = "The Band is rocking!";
        }
        else if (avg > 0.7)
        {
            statusText.text = "The Band is doing okay!";
        }
        else if (avg > 0.4)
        {
            statusText.text = "The Band is struggeling!";
        }
        else if (avg > 0.1)
        {
            statusText.text = "The Band is in a bad shape!!";
        } else {
            statusText.text = "Game Over!";
        }
    }
}
