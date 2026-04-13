using System;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzle2StarSpawn : MonoBehaviour
{

    public CorrectImage machine1;
    public CorrectImage machine2;
    public CorrectImage machine3;

    public GameObject Star;

    void Update()
    {
        
        if (machine1.isCorrect == true && machine2.isCorrect == true && machine3.isCorrect == true)
        {
            Debug.Log("Puzzle 2 solved");
            Star.SetActive(true);
        }
    }
}
