using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int max;
    [SerializeField] private int guess;
    [SerializeField] private TextMeshProUGUI guessText;

    private void Start ()
    {
        StartGame ();
    }

    private void StartGame ()
    {
        NextGuess ();
    }

    // Selects a random number between the min and max numbers
    private void NextGuess ()
    {
        guess = Random.Range (min, max + 1);
        guessText.text = guess.ToString ();
    }

    // Pass the guess number + 1 to min number
    public void OnPressHigher ()
    {
        min = (guess + 1);
        NextGuess ();
    }

    // Pass the guess number - 1 to max number
    public void OnPressLower ()
    {
        max = (guess - 1);
        NextGuess ();
    }
}