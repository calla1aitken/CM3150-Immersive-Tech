using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Android;

public class Button_VR : MonoBehaviour
{
    public GameObject thisButton;
    //public Light thisLight;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    //AudioSource sound;
    bool isPressed;
    
  
   /* public Light redLight;
    public Light greenLight;
    public Light blueLight;
    public Light yellowLight;
   
    private int isRightButton;
    float timePassed = 0;
    bool puzzleSolved = false;
    bool waitingForInput = false;*/
    
    void Start()
    {
        
        //timePassed = 0;
        //sound = GetComponent<AudioSource>();
        isPressed = false;
        //puzzleSolved = false;

        /*if (thisLight == redLight){
            Debug.Log("This is the red button");
            thisButton = GameObject.Find("redbutton");
            Debug.Log(thisButton.name);
        }
        else if (thisLight == greenLight){
            Debug.Log("This is the green button");
            thisButton = GameObject.Find("greenbutton");
            Debug.Log(thisButton.name);
        }
        else if (thisLight == blueLight)
        {
            Debug.Log("This is the blue button");
            thisButton = GameObject.Find("bluebutton");
            Debug.Log(thisButton.name);
        }
        else if (thisLight == yellowLight)
        {
            Debug.Log("This is the yellow button");
            thisButton = GameObject.Find("yellowbutton");
            Debug.Log(thisButton.name);
        }
        */

    }

    /*void Update()
    {
        if (puzzleSolved == false && waitingForInput == false)
        {
            timePassed += Time.deltaTime;
            //Debug.Log(timePassed);

        }
        //StartSequence();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed) 
        {
            thisButton.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            //sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser) {
            thisButton.transform.localPosition = new Vector3(0, 0.15f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.AddComponent<Rigidbody>();
    }

    /*(public void StartSequence()
    {
        List pattern[]
        if (timePassed < 2)
        {
            redLight.intensity = 10;
          
            
        }else if (Mathf.Round(timePassed) == 2) { 
            redLight.intensity = 0;
            waitingForInput = true;
            
        }
    }*/
}
