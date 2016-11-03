using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    //Player number
    [SerializeField]private int _playerNumber;
    private string _playerNumString;

    //Input delegates/events
    public delegate void InputAction();
    public static event InputAction inputAction;
    public static event InputAction aPressed;
    public static event InputAction xPressed;
    public static event InputAction lbPressed;


	// Use this for initialization
	void Start () {
        _playerNumString = _playerNumber.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (inputAction != null)
        {
            //inputAction();
        }

        ButtonInputs();
	}

    void LeftStickInput()
    {

    }

    void ButtonInputs()
    {
        if (Input.GetButtonDown(InputAxes.a + _playerNumString) && aPressed != null)
        {
            Debug.Log("Jump");
            //aPressed();
        }

        if (Input.GetButtonDown(InputAxes.x + _playerNumString) && xPressed != null)
        {
            Debug.Log("Hit");
            xPressed();
        }

        if (Input.GetButtonDown(InputAxes.lb +_playerNumString) && lbPressed != null)
        {
            Debug.Log("Teleport");
            lbPressed();
        }
    }
}
