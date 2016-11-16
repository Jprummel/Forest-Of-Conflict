using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    private Animator _anim;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
	}

    public void SetAnimBool(string ID, bool value)
    {
        _anim.SetBool(ID, value);
    }

    public void SetAnimInt(string ID, int value)
    {
        _anim.SetInteger(ID, value);
    }
}
