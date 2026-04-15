using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] GameObject door;
    [SerializeField] BoxCollider handle;
    private bool locked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        locked = true;
        door.GetComponent<Rigidbody>().isKinematic = true;
        handle.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "key" && locked)
        {
            Debug.Log("FR");
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        door.GetComponent<Rigidbody>().isKinematic = false;
        handle.enabled = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        locked = false;
    }
}
