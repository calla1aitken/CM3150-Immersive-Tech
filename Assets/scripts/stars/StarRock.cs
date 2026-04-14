using UnityEngine;

public class StarRock : MonoBehaviour
{

    [SerializeField] GameObject puzzlestar;
    [SerializeField] GameObject thisstar;

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
