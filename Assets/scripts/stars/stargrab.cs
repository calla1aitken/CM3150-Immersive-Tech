using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class stargrab : MonoBehaviour
{
   
    public XRGrabInteractable starGrab;
    public Rigidbody starbody;
    public GameObject star;
    public DrawCircle rock;
    Vector3 starlocation;
    Quaternion starrotation;
    private void Start()
    {
        starlocation = star.transform.position;
        starrotation = star.transform.rotation;

    }
    private void Awake()
    {
        starGrab.selectEntered.AddListener(OnGrab);
        starGrab.selectExited.AddListener(OnRelease);
        
    }
    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Selected");
        
        StartCoroutine(DelayedGrab());
    }
    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Selected");

        
        StartCoroutine(DelayedRelease());



    }

    private IEnumerator DelayedGrab()
    {
        yield return new WaitForSeconds(1);
        starbody.isKinematic = false;
        rock.MakeCircle();
    }

    private IEnumerator DelayedRelease()
    {
        yield return new WaitForSeconds(30);
        star.transform.position = starlocation;
        star.transform.rotation = starrotation;
        
        starbody.isKinematic = true;
        rock.gameObject.SetActive(false);

    }

    
    }
