using UnityEngine;

public class StarRock : MonoBehaviour
{

    public GameObject star;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collisioninfo)
    {
        if (collisioninfo.gameObject == star)
        {
            Debug.Log("heh");
        }
    }
    }
