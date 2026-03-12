using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class LightAnimator : MonoBehaviour
{


    public float lightTime = 3;

    int currentLight;

    public Light[] lights;
    int[] sequence = new int[8];
    public int counter = 0;

    public void Begin()
    {
        
        Debug.Log("Help");
        StartCoroutine("ChangeLight");
        
    }

    IEnumerator ChangeLight()
    {
        // change to the next random light
        int randomIndex = Random.Range(0, 4);
        currentLight = randomIndex;
        Debug.Log("the index is is" +randomIndex);
        Debug.Log("the curent is is" +currentLight);
        
        // disable the current light
       
        lights[currentLight].intensity = 50;

        //start again if 8 lights have not flashed
        
        yield return new WaitForSeconds(lightTime);
        lights[currentLight].intensity = 0;
        yield return new WaitForSeconds(lightTime);

        
        
        
        counter++;
        Debug.Log("this is counter" + counter);
        
            
       
        if (counter <8)
        {
            
            sequence[counter] = currentLight;
            StartCoroutine("ChangeLight");
       
        }
        else
        {
            lights[currentLight].intensity = 0;
            String sequenceFull = "";
            String sequenceToString = "";
            lights[currentLight].intensity = 0;
            for (int i = 0; i < 8; i++)
            {
                sequenceFull = sequenceFull + sequence[i] +","; 
                
            }
            Debug.Log(sequenceFull);
            

        }

    }
    public void Addtoarray(int currentLight){
        
    }
}