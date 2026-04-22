using UnityEngine;
using System.Collections;


public class Barrier : MonoBehaviour
{
    [SerializeField] Canvas uiMessage;
    void Start()
    {
        uiMessage.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Wall collided with");
            StartCoroutine(delayMessage());
        }
    }

    IEnumerator delayMessage()
    {
        uiMessage.enabled = true;
        yield return new WaitForSeconds(5);
        uiMessage.enabled = false;
    }
}
