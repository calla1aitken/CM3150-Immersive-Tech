using NUnit.Framework.Constraints;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class CorrectImage : MonoBehaviour
{

    [SerializeField] MeshRenderer correctImageRenderer;
    [SerializeField] MeshRenderer thisRenderer;
    Material correctImage;
    Material thisImage;
    public Material blank;

    public Boolean isCorrect;


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

        }
    }

    public void makeBlank()
    {
        thisRenderer.material = blank;
    }
}
