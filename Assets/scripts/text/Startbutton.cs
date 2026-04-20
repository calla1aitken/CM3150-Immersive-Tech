using UnityEngine;
using UnityEngine.SceneManagement;

public class Startbutton: MonoBehaviour
{

    public GameObject newScreen;
    public string newScene;

    public void sceneChange()
    {
        SceneManager.LoadScene(newScene);
        ChangeUI();
    }

    public void ChangeUI()
    {
        this.gameObject.SetActive(false);
        newScreen.SetActive(true);
    }
}
