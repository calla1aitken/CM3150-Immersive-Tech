using UnityEngine;

public class Startbutton: MonoBehaviour
{

    public GameObject newScreen;

    public void ChangeUI()
    {
        this.gameObject.SetActive(true);
        newScreen.SetActive(true);
    }
}
