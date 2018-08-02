using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerWorldMap : MonoBehaviour
{
    private PlayerControllerWorldMap playerCtrl;

    // Use this for initialization
    void Awake()
    {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerWorldMap>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCtrl.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Menu"))
        {
            GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>().SetMenuActive(Menu.Menus.PauseMenu, true);
        }
    }
}