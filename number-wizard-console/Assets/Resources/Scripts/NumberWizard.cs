using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private int minNumber = 1;
    private int maxNumber = 1000;
    private int guess = 500;

    private void Start ()
    {
        StartGame ();
    }

    private void Update ()
    {
        // Inputs
        if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            minNumber = guess;
            NextGuess ();
        }
        else if (Input.GetKeyDown (KeyCode.DownArrow))
        {
            maxNumber = guess;
            NextGuess ();
        }
        else if (Input.GetKeyDown (KeyCode.Return))
        {
            Debug.Log ("I'm a genius. You're not.");
            StartGame ();
        }
    }

    private void StartGame ()
    {
        minNumber = 1;
        maxNumber = 1000;
        guess = 500;

        // Prints
        Debug.Log ("Welcome to Number Wizard");
        Debug.Log ("Pick a number, but don't tell what is...");
        Debug.Log ("The lowest number you can pick is " + minNumber);
        Debug.Log ("The highest number you can pick is " + maxNumber);
        Debug.Log ("Tell me if you number is higher or lower than " + guess);
        Debug.Log ("Push UP = Higher, Push Down = Lower, Push Enter = Correct");

        maxNumber = (maxNumber + 1);
    }

    private void NextGuess ()
    {
        guess = (maxNumber + minNumber) / 2;
        Debug.Log ("It's higher or lower than..." + guess + " ?");
    }
}