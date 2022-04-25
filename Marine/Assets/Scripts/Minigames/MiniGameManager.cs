using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    private string puzzle;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    
    public void PuzzlePrep(int startPuzzle)
    {
        //start puzzle 1 = Grid, 2 = Symbols, 3 = Password, 4 = Lock
        switch (startPuzzle)
        {
            case 0:
                print("This is not a valid input to activate a puzzel");
                break;
            case 1:
                puzzle = "Grid";
                GridPuzzle();
                break;
            case 2:
                puzzle = "SymbolMatching";
                SymbolMatchingPuzzle();
                break;
            case 3:
                puzzle = "Password";
                PasswordPuzzle();
                break;
            case 4:
                puzzle = "Lock";
                LockPuzzle();
                break;
        }
    }

    private void LoadPuzzle()
    {
        SceneManager.LoadScene(puzzle);
    }

    private void GridPuzzle()
    {
        // this part will need to do 2 things: Set the solution to the puzzle and send back an image to the thief part to display or vise versa

    }

    private void SymbolMatchingPuzzle()
    {
        // this part will need to do 2 things: Set the question and solution to the puzzle and send back an image to the thief part to display or vise versa
        
    }

    private void PasswordPuzzle()
    {
        //This part will need to do 3 things: 1. Fill in the username with a random one from a list, 2. Set the puzzle (Question and solution), 3. Change enviroment of the thief that fits the puzzle
    }

    private void LockPuzzle()
    {
        //TBD --> NOTE: This puzzle will require the most time to create so it'll be postponed until after the testing has been completed
    }
}
