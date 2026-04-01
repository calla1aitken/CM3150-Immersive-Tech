 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    //Time that the button is set inactive after release
    public float deadTime = 1.0f;
    //Bool used to lock down button during its set dead time
    private bool _deadTimeActive = false;

    //public Unity Events we can use in the editor and tie other functions to.
    public UnityEvent onPressed, onReleased;

    public bool buttonPress = false;
    public LightAnimator lanterns;

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

    //Checks if the current collider exiting is the Button and sets off OnReleased event.
    //It will also call a Coroutine to make the button inactive for however long deadTime is set to.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BUTTON" && !_deadTimeActive)
        {

            onReleased.Invoke();
            Debug.Log("I have been released");
            StartCoroutine(WaitForDeadTime());
         
            Debug.Log(buttonPress);
        }
    }

    //Locks button activity until deadTime has passed and reactivates button activity.
    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
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
            iscorrectbutton = false;
        } else
        {
            Debug.Log("This is the wrong button. Press the Start button to try again.");
            lanterns.pressedWrongButton();
           
        }
        
      
    }

    public void isNotPressed()
    {
        this.buttonPress = false;
    
    }




}