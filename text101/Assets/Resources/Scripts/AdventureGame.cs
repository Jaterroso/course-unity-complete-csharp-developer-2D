using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventureGame : MonoBehaviour
{
    // [SerializeField] = Permite deixar a variavel visivel no Inspector
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private State startingState;

    private State state;

    // Start is called before the first frame update
    private void Start ()
    {
        state = startingState;
        textComponent.text = state.GetStateStory ();
    }

    // Update is called once per frame
    private void Update ()
    {
        MenageState ();

        if (Input.GetKeyDown (KeyCode.Q))
        {
            Application.Quit ();
        }
    }

    //-------------------------------------------------------------------------------------//
    // HELPER FUNCTIONS

    // Changes actual state and update the text
    private void MenageState ()
    {
        var nextStates = state.GetNextStates ();

        // Eliminates IndexOutOfBounds...
        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown (KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
        }

        textComponent.text = state.GetStateStory ();
    }
}