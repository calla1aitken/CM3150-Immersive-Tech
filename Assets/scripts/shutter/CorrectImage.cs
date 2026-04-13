using NUnit.Framework.Constraints;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class CorrectImage : MonoBehaviour
{

    public MeshRenderer correctImageRenderer;
    public MeshRenderer thisRenderer;
    Material correctImage;
    Material thisImage;

    public Boolean isCorrect;


    public GameObject star;

    void Start()
    {
        correctImage = correctImageRenderer.material;
        isCorrect = false;
    }

    // Update is called once per frame
    void Update()
    {
        thisImage = thisRenderer.material;
       
        if (thisImage.name == correctImage.name)
        {
            Debug.Log("Correct Image");
            isCorrect = true;
            star.SetActive(true);
        }
    }
}
