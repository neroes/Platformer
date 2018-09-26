using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform playerTransform;
	// Use this for initialization
	void OnEnable () {
        UpdateTransform();
    }
    
    public void UpdateTransform()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y,-10f);
	}
}
