using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolMatching : MonoBehaviour
{
    [SerializeField] private GameObject[] symbols;
    [SerializeField] private GameObject canvas;
    public void CorrectAnswer()
    {
        //insert Green Checkmark 

    }
    public void IncorrectAnswer()
    {
        //inset Red X image instatiation here
    }

    private void Start()
    {
        //1st hardcoded symbol -> X pos to left

        GameObject Symbol1 = Instantiate(symbols[0], new Vector3(symbols[0].transform.position.x - .2f, symbols[0].transform.position.y, symbols[0].transform.position.z), Quaternion.identity) as GameObject;
        //2nd hardcoded symbol -> center
        GameObject Symbol2 = Instantiate(symbols[1]) as GameObject;
        //3rd hardcoded symbol -> X pos to right
        GameObject Symbol3 = Instantiate(symbols[2], new Vector3(symbols[2].transform.position.x + .2f, symbols[2].transform.position.y, symbols[2].transform.position.z), Quaternion.identity) as GameObject;

        Symbol1.transform.SetParent(canvas.transform, false);
        Symbol2.transform.SetParent(canvas.transform, false);
        Symbol3.transform.SetParent(canvas.transform, false);
    }
}
