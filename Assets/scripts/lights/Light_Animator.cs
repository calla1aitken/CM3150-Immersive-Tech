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
    float lightTime = 2;

//used for referncing items in arrays
    int currentLight;
    int currentButton;
    VRButton thisbutton;

//arrays
    public Light[] lights;
    public VRButton[] buttons = new VRButton[4];
    int[] sequence = new int[8];

//counters for light/button sequences
     int lightscounter = 0;
     int buttonscounter = 0;
    String bsequenceFull = "";

    //if wrong button is pressed 
     bool pressedwrongbutton;

    public GameObject Star;
    
    public void Begin()
    {
        
        pressedwrongbutton = false;
        buttonscounter = 0;
        lightscounter = 0;
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
        
        
        if (lightscounter <7)
        { 
            //Adds the current light's number to an array
            sequence[lightscounter] = currentLight;
            lightscounter++;
            StartCoroutine("ChangeLight");
        }
        else
        {
            sequence[lightscounter] = currentLight;
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
        if (pressedwrongbutton == false)
        {
            lights[currentLight].intensity = 0;

            currentButton = sequence[buttonscounter];

            thisbutton = buttons[currentButton];

            thisbutton.isCorrectButton();
            
            bsequenceFull = bsequenceFull + currentButton + ","; 

            
            yield return new WaitWhile(() => thisbutton.buttonPress == false);
            buttonscounter++;

            if (buttonscounter < 8){
                StartCoroutine("ButtonInputs");
            }
            else{
                Debug.Log("You did it. The button sequence is " + bsequenceFull);
                Star.SetActive(true);
            };
        }
        else
        {
            Debug.Log("You pressed the wrong button. Press start to try sgain");
        }
    
    } 

    public void pressedWrongButton()
    {
        pressedwrongbutton = true;
    }
}
