 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{

 
    private bool _deadTimeActive = false;

  
    public UnityEvent onPressed, onReleased;

    public bool buttonPress = false;
    public LightAnimator lanterns;
    public GameObject incorrectimage;
    public GameObject correctimage;

    public bool iscorrectbutton = false;

    //Checks if the current collider entering is the Button and sets off OnPressed event.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BUTTON" && !_deadTimeActive)
        {
            onPressed.Invoke();
            Debug.Log("I have been pressed");
            
            Debug.Log(buttonPress);
            //lanterns.GetButtonPress(other);

        }
    }


    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(HideImage());

        if (other.tag == "BUTTON" && !_deadTimeActive)
        {

            onReleased.Invoke();
            Debug.Log("I have been released");
            StartCoroutine(WaitForDeadTime(1));
         
            Debug.Log(buttonPress);
            
            
        }
    }

    IEnumerator HideImage()
    {
        yield return new WaitForSeconds(2);
        if (incorrectimage != null && correctimage != null)
        {
            incorrectimage.SetActive(false);
            correctimage.SetActive(false);
        }
        
    }


    IEnumerator WaitForDeadTime(float deadtime)
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadtime);
        _deadTimeActive = false;
    }

    public void isCorrectButton()
    {
        iscorrectbutton = true;
    }



    public void isPressed()
    {
        if (iscorrectbutton == true)
        {
            this.buttonPress = true;
            Debug.Log("this is the correct button");
            if (correctimage != null)
            {
                correctimage.SetActive(true);
            }
            iscorrectbutton = false;
        } else
        {
            
            Debug.Log("This is the wrong button. Press the Start button to try again.");
            if (incorrectimage != null)
            {
                incorrectimage.SetActive(true);
            }
            lanterns.pressedWrongButton();


        }
        
      
    }

    public void isNotPressed()
    {
        this.buttonPress = false;
    
    }


    


}