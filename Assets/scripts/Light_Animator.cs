using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class LightAnimator : MonoBehaviour
{


    public float lightTime = 3;

    int currentLight = 0;

    public Light[] lights;
    int[] sequence = new int[8];
    public int counter = 0;

    public void Begin()
    {
        StartCoroutine("ChangeLight");
    }

    IEnumerator ChangeLight()
    {
        yield return new WaitForSeconds(lightTime);

        Debug.Log("Changing light to number " + currentLight);

        // disable the current light
        lights[currentLight].intensity = 0;

        // change to the next random light
        int randomIndex = Random.Range(0, 4);
        currentLight = randomIndex;
        
        lights[currentLight].intensity = 50;

        //start again if 8 lights have not flashed
        if (counter < 8)
        {
            counter++;
            StartCoroutine("ChangeLight");
            Addtoarray(currentLight);
        }
        else
        {
            lights[currentLight].intensity = 0;
            for (int i = 0; i < 8; i++)
            {
                Debug.Log(sequence[i]);
            }


        }

    }
    public void Addtoarray(int currentLight){
        sequence[counter] = currentLight;
    }
}