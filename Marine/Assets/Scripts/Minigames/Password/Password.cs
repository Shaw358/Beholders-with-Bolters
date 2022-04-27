using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernamefield;
    [SerializeField] private TextMeshProUGUI passwordfield;
    private string correctPassword;
    private string enteredText;
    private string[] usernames = new string[] {"Henk Dirksen","George Nashid","Leonard Davinci","Rapheal Turtle"};
    
    // Update is called once per frame
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

}
