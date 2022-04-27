using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolMatching : MonoBehaviour
{
    [SerializeField] private GameObject symbol1;
    [SerializeField] private GameObject symbol2;
    [SerializeField] private GameObject symbol3;
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
        Instantiate(symbol1, new Vector3(symbol1.transform.position.x - 15, symbol1.transform.position.y, symbol1.transform.position.z), symbol1.transform.rotation);
        //2nd hardcoded symbol -> center
        Instantiate(symbol2);
        //3rd hardcoded symbol -> X pos to right
        Instantiate(symbol3, new Vector3(symbol3.transform.position.x + 15, symbol3.transform.position.y, symbol3.transform.position.z), symbol3.transform.rotation);
    }

}
