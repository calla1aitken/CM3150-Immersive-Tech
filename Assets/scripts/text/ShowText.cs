using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{

    public RawImage Image1;
    public RawImage Image2;
    public RawImage Image3;
    public Canvas canvas;
    float delaytime = 2;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
            Debug.Log("SHJF");
            StartCoroutine("Delay");

        }
            
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Image1.gameObject.SetActive(false);
            Image2.gameObject.SetActive(false);
            Image3.gameObject.SetActive(false);

        }

    }

    private IEnumerator Delay()
    {
        Image1.gameObject.SetActive(true);
        yield return new WaitForSeconds(delaytime);
        Image1.gameObject.SetActive(false);

        if(Image2 != null && Image3 != null)
        {
            Image2.gameObject.SetActive(true);
            yield return new WaitForSeconds(delaytime);
            Image2.gameObject.SetActive(false);
            Image3.gameObject.SetActive(true);
            yield return new WaitForSeconds(delaytime);
            Image3.gameObject.SetActive(false);
        } else if(Image2 != null)
        {
            Image2.gameObject.SetActive(true);
            yield return new WaitForSeconds(delaytime);
            Image2.gameObject.SetActive(false);
        }
    }
}
