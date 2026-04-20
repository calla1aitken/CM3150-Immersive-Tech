using UnityEngine;

public class Barrier : MonoBehaviour
{
     public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Wall collided with");
        }
    }
}
