using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    [SerializeField] private InputField userInput;
    private string enteredText;
    private string[] usernames;
    // Update is called once per frame
    private void Start()
    {
        
    }
    public void EnterText()
    {
        enteredText = userInput.text;
    }
}
