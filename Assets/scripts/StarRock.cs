using UnityEngine;

public class StarRock : MonoBehaviour
{

    public GameObject puzzlestar;
    public GameObject thisstar;

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
        if (collisioninfo.gameObject == puzzlestar)
        {
            Debug.Log("heh");
            thisstar.SetActive(true);
            puzzlestar.SetActive(false);
        }
    }
}
