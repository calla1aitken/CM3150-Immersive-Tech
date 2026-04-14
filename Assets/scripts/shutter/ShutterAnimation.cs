using System.Collections;
using Unity.VisualScripting;

using UnityEngine;

public class ShutterAnimation : MonoBehaviour
{
   
    [SerializeField] Collider lever;
    [SerializeField] Animator shutteranimator;

    [SerializeField] GameObject image;
    public Material[] materials = new Material[5];
    int counter = 0;
    float timetowait = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if (collision == lever)
        {
            StartCoroutine("PlayAnimation");
        }
        

    }

    IEnumerator PlayAnimation()
    {
        Debug.Log("lol");
        shutteranimator.SetTrigger("OnLeverPull");
        yield return new WaitForSeconds(timetowait);
        image.GetComponent<MeshRenderer>().material = materials[counter];
        if (counter == 4)
        {
            counter = 0;
        } else
        {
            counter++;
        }

    }
}
