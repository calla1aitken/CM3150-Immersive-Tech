using System.Threading;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Audio;


public class Light_Switch : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;
    public Light greenLight;
    public Light yellowLight;



    public bool sequenceNotComplete = true;
    public float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.001f;


    }
    public void SwitchOn()
    {
        redLight.intensity = 50;
        Debug.Log("erwrewr");
    }

    public void StartSequence()
    {

        timer = 0;

        while (sequenceNotComplete)
        {
            if (timer > 20f)
            {
                Debug.Log("sequne");
                redLight.intensity = 50;
            }
        }
        

        
    }
}

