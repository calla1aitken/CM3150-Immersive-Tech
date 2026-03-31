using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using Random = UnityEngine.Random;

[System.Serializable]
public class LightAnimator : MonoBehaviour
{
    float lightTime = 3;

    int currentLight;
    int currentButton;

    public Light[] lights;
    public VRButton[] buttons = new VRButton[4];
    int[] sequence = new int[8];
    public int lightscounter = 0;
    public int buttonscounter = 0;
    String bsequenceFull = "";
    VRButton thisbutton;

    public void Begin()
    {
        StartCoroutine("ChangeLight");
    }
    IEnumerator ChangeLight()
    {
        // change to the next random light
        int randomIndex = Random.Range(0, 4);
        currentLight = randomIndex;
        lights[currentLight].intensity = 10;

        
        // disable the current light
        yield return new WaitForSeconds(lightTime);
        lights[currentLight].intensity = 0;
        yield return new WaitForSeconds(lightTime);

        //start again if 8 lights have not flashed
        
        
        if (lightscounter <8)
        { 
            //Adds the current light's number to an array
            sequence[lightscounter] = currentLight;
            lightscounter++;
            StartCoroutine("ChangeLight");
        }
        else
        {
            //Print full sequence to the console 
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

        lights[currentLight].intensity = 0;

        currentButton = sequence[buttonscounter];

        thisbutton = buttons[currentButton];
        
        bsequenceFull = bsequenceFull + currentButton + ","; 
            
        yield return new WaitWhile(() => thisbutton.buttonPress == false);
        buttonscounter++;

        if (buttonscounter < 8){
            Debug.Log("correct choice");
            StartCoroutine("ButtonInputs");
        }
        else{
            Debug.Log("You did ithbhcxbvhThe button sequence is " + bsequenceFull);
        };

    } 
}
