using UnityEngine;

public class StarRock : MonoBehaviour
{

    [SerializeField] GameObject puzzlestar;
    [SerializeField] GameObject thisstar;
    [SerializeField] GameObject circle;

    private void OnTriggerEnter(Collider collisioninfo)
    {
        if (collisioninfo.gameObject == puzzlestar)
        {
            Debug.Log("Star in place");
            thisstar.SetActive(true);
            puzzlestar.SetActive(false);
            circle.SetActive(false);
        }
    }
}
