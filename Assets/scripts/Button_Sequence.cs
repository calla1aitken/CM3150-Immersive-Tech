using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Android;

public class Button_VR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    public Light redLight;
   public Light greenLight;
    public Light blueLight;
    public Light yellow;

    float timePassed = 0;
    bool puzzleSolved = false;
    bool waitingForInput = false;
    


    void Start()
    {
        timePassed = 0;
        sound = GetComponent<AudioSource>();
        isPressed = false;
        puzzleSolved = false;
        
    }

    void Update()
    {
        if (puzzleSolved == false && waitingForInput == false)
        {
            timePassed += Time.deltaTime;
            Debug.Log(timePassed);

        }
        StartSequence();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed) 
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser) {
            button.transform.localPosition = new Vector3(0, 0.15f, 0);
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

    public void StartSequence()
    {
        
        


       
        if (timePassed < 2)
        {
            redLight.intensity = 10;
            
            
        }else if (Mathf.Round(timePassed) == 2) { 
            redLight.intensity = 0;
            waitingForInput = true;
            button = GameObject.Find("redbutton");
        }
    }
}
