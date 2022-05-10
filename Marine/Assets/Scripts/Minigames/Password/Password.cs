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
    private string enteredPassword;
    private string[] passwords = new string[] { "password", "wordpass", "number", "derulo", "davinci" };
    private string[] usernames = new string[] {"Henk Dirksen","George Nashid","Leonard Davinci","Rapheal Turtle"};
    private int puzzleInt;
    // Update is called once per frame
    private void Start()
    {
        puzzleInt = Random.Range(0, usernames.Length);
        usernamefield.text = usernames[puzzleInt];
        correctPassword = passwords[puzzleInt];    


    }

    public void CheckPassword()
    {
        enteredPassword = passwordfield.text;
        if (enteredPassword == correctPassword)
        {
            //Display Green Checkmark - Image

        }

    }

}