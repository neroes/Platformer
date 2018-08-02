using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {// handles controlls
    private PlayerController playerCtrl;

    // Use this for initialization
    void Awake()
    {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCtrl.Move(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            playerCtrl.Jump();
        }
        if (Input.GetAxis("Vertical") < -0.2)
        {
            playerCtrl.FallThrough();
        }
    }
}