using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallthrough : MonoBehaviour {

    private float timer;
    public float resetTime;

    private void OnEnable()
    {
        gameObject.layer = 12;
    }
    private void OnDisable()
    {
        gameObject.layer = 10;
    }
    public void ResetTimer () {
        timer = resetTime;
	}

	
	// Update is called once per frame
	void Update () {
		if(timer < 0f) { this.enabled = false; }
        else { timer -= Time.deltaTime; }
	}
}
