using UnityEngine;

// CreateAssetMenu = Permite criar um objeto desse script
[CreateAssetMenu (menuName = "State")]
public class State : ScriptableObject
{
    // TextArea (min, max) = Permite criar um "textarea" com numero minimo e maximo de linhas
    [SerializeField] [TextArea (14, 10)] 
    private string storyText;

    [SerializeField] 
    private State[] nextStates;

    public string GetStateStory ()
    {
        return storyText;
    }

    public State[] GetNextStates ()
    {
        return nextStates;
    }
}