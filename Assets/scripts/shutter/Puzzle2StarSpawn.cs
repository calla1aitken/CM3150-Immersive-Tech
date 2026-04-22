using System;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzle2StarSpawn : MonoBehaviour
{

    [SerializeField] CorrectImage machine1;
    [SerializeField] CorrectImage machine2;
    [SerializeField] CorrectImage machine3;

    [SerializeField] GameObject Star;
    [SerializeField] AudioSource audioData;

    void Update()
    {
        
        if (machine1.isCorrect == true && machine2.isCorrect == true && machine3.isCorrect == true)
        {
            Debug.Log("Puzzle 2 solved");
            Star.SetActive(true);
            audioData.Play(0);
            machine1.makeBlank();
            machine2.makeBlank();
            machine3.makeBlank();
            machine1.isCorrect = false;
            machine2.isCorrect = false;
            machine3.isCorrect = false;
        }
    }
}
