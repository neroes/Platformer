using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyPlayerCollision : MonoBehaviour {
    private void Awake()
    {
        transform.parent.GetComponent<EnermyController>().SetPlayerCollider = gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().Die();
        }
    }
}
