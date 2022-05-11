using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ImageOnClick : MonoBehaviour
{
    /// <summary>
    /// Script is made in a singular hour, along with the connections.
    /// Normally you'd enter the correct or incorrect function in this one or attach it so it's accesable.
    /// lazy lol
    /// </summary>
    [SerializeField] bool correctAnswer;
    SymbolMatching manager;

    private void Start()
    {
       
        manager = GameObject.Find("MinigameManager").GetComponent<SymbolMatching>();
    }
    private void OnMouseDown()
    {
        if (correctAnswer)
        {
            manager.CorrectAnswer();
        }
        else
        {
            manager.IncorrectAnswer();
        }
    }
}
