using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : MonoBehaviour
{
    bool on_stage = false;
    bool in_crowd = false;

    public GameObject camObj;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BoxStage")
        {
            SetOnStage(true);
        }

        if(other.tag == "BoxCrowd")
        {
            SetInCrowd(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "BoxStage")
        {
            SetOnStage(false);
        }

        if(other.tag == "BoxCrowd")
        {
            SetInCrowd(false);
        }
    }

    public bool OnStage()
    {
        return on_stage;
    }

    public bool InCrowd()
    {
        return in_crowd;
    } 

    public void SetOnStage(bool _onStage)
    {
        on_stage = _onStage;
        Debug.Log(gameObject.name + " on stage: " + _onStage);
    }

    public void SetInCrowd(bool _inCrowd)
    {
        in_crowd = _inCrowd;
        Debug.Log(gameObject.name + " in crowd: " + _inCrowd);
    }
}
