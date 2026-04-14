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

    public Boolean isCorrect;


    [SerializeField] GameObject star;

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
