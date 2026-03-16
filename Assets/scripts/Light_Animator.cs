using System;
using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using Random = UnityEngine.Random;

[System.Serializable]
public class LightAnimator : MonoBehaviour
{


    public float lightTime = 3;

    int currentLight;
    int currentButton;

    public bool buttonPress;

    public Light[] lights;
    public GameObject[] buttons;
    int[] sequence = new int[8];
    public int counter = 0;

    public void Begin()
    {
        Debug.Log("Help");
        StartCoroutine("ChangeLight");
    }

    public void GetButtonPress()
    {
        Debug.Log("L");
        buttonPress = true;
    }


    IEnumerator ChangeLight()
    {
        // change to the next random light
        int randomIndex = Random.Range(0, 4);
        currentLight = randomIndex;
        lights[currentLight].intensity = 50;

        
        // disable the current light
        yield return new WaitForSeconds(lightTime);
        lights[currentLight].intensity = 0;
        yield return new WaitForSeconds(lightTime);

        //start again if 8 lights have not flashed
        counter++;
        
        if (counter <8)
        { 
            //Adds the current light's number to an array
            sequence[counter] = currentLight;
            StartCoroutine("ChangeLight");
        }
        else
        {
            //Print full sequence to the console 
            lights[currentLight].intensity = 0;
            String sequenceFull = "";
            lights[currentLight].intensity = 0;
            for (int i = 0; i < 8; i++)
            {
                sequenceFull =  sequenceFull + sequence[i] +",";
                
            }
            Debug.Log("The light sequence is " + sequenceFull);
            StartCoroutine("ButtonInputs");
        }

    }

    IEnumerator ButtonInputs()
    {
        String sequenceFull = "";
        for (int i = 0; i < 8; i++)
        {
            currentButton = sequence[i];
            sequenceFull =  sequenceFull + sequence[i] + ",";
            yield return new WaitUntil(() => buttonPress = true);
        }
        Debug.Log("The button sequence is " + sequenceFull);
    }


   
}