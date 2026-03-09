using UnityEngine;

public class Light_Switch : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;
    public Light greenLight;
    public Light yellowLight;
    public Light redButton;
    public Light blueButton;
    public Light greenButton;
    public Light yellowButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchOn()
    {
        redLight.intensity = 50;
        Debug.Log("erwrewr");
    }
}
