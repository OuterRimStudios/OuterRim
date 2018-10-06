using UnityEngine;
using System.Collections;

public class InitialSelector : MonoBehaviour {

    public GameObject parentText;

    public void NextChar()
    {
        parentText.GetComponent<InitialWrangler>().NextCharacter();
    }

    public void PreviousChar()
    {
        parentText.GetComponent<InitialWrangler>().PreviousCharacter();
    }
}
