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


    public float lightTime = 3;

    int currentLight;
    int currentButton;

    public bool buttonPress;

    public Light[] lights;
    public VRButton[] buttons = new VRButton[4];
    int[] sequence = new int[8];
    public int lightscounter = 0;
    public int buttonscounter = 0;
    VRButton thisbutton;

    public void Begin()
    {

        StartCoroutine("ChangeLight");
    }


    public void GetButtonPress(Collider collider)
    {
        if (collider = thisbutton.GetComponent<Collider>())
        {
            Debug.Log("correct press");
            buttonPress = true;
        }
        else
        {
            Debug.Log("wrong press");
            buttonPress = false;

            
        }
        
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
        lightscounter++;
        
        if (lightscounter <8)
        { 
            //Adds the current light's number to an array
            sequence[lightscounter] = currentLight;
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
         lights[currentLight].intensity = 0;



            currentButton = sequence[buttonscounter];

            thisbutton = buttons[currentButton];
            Debug.Log("pRESS" + thisbutton);
            sequenceFull = sequenceFull + currentButton + ","; buttonscounter++;
            yield return new WaitUntil(() => buttonPress == true);


            if (buttonscounter < 8)
            {
                if (buttonPress == true) {
                    buttonPress = false;
                    StartCoroutine("ButtonInputs");
                } else
                {
                    Debug.Log("waiting");
                    yield return new WaitForSeconds(1);
                }

            }
            else
            {
                Debug.Log("You did ithbhcxbvhThe button sequence is " + sequenceFull);

            };

        } 



}
