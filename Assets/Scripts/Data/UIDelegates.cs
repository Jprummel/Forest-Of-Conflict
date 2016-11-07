using UnityEngine;
using System.Collections;

public class UIDelegates : MonoBehaviour {

    public delegate void UIDelegate();
    public static event UIDelegate CooldownEvent;
    public static event UIDelegate TextEvent;
    
	void Update () 
    {
        if (CooldownEvent != null)
        {
            CooldownEvent();
        }

        if (TextEvent != null)
        {
            TextEvent();
        }
	}
}
