using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class CorrectImage : MonoBehaviour
{ 
    public Material correctImage;
    
   
    public GameObject thisLeverCollider;
 

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Material>() == correctImage)
        {
            Debug.Log("hfjh");
        }
    }
}
