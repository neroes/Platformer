using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smush : MonoBehaviour {
    EnermyController parrent;
	// Use this for initialization
	void Awake () {
        parrent = transform.parent.gameObject.GetComponent<EnermyController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parrent.Smush(collision);
        }
        GetComponent<Collider2D>().enabled = false;
    }
}
