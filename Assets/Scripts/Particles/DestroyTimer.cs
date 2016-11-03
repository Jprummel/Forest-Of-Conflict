using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
    private float   timeStamp;
    public  float   destroy;

	void Start () {
        timeStamp = Time.time + destroy;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeStamp <= Time.time)
        {
            Destroy(this.gameObject);
        }
	}
}
