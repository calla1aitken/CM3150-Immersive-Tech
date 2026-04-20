using UnityEngine;
using UnityEngine.SceneManagement;

public class AllStarsCollected : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public string newScene;

    // Update is called once per frame
    void Update()
    {
         if (star1.activeSelf && star2.activeSelf && star3.activeSelf)
        {
            Debug.Log("All stars collected");
            SceneManager.LoadScene(newScene);
        }
    }
}
