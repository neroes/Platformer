using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    private GameObject pauseMenu;
    private GameObject saveMenu;
    private GameObject loadMenu;
    private GameObject optionsMenu;
    public enum Menus { PauseMenu, SaveMenu, LoadMenu, OptionsMenu};

    // Use this for initialization
    void Start () {
		foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "PauseMenu":
                    pauseMenu = child.gameObject;
                    break;
                case "SaveMenu":
                    saveMenu = child.gameObject;
                    break;
                case "LoadMenu":
                    loadMenu = child.gameObject;
                    break;
                case "OptionsMenu":
                    optionsMenu = child.gameObject;
                    break;
            }
        }
	}
    public void SetMenuActive(Menus menu,bool active)
    {
        switch (menu)
        {
            case Menus.PauseMenu:
                pauseMenu.SetActive(active);
                break;
            case Menus.SaveMenu:
                saveMenu.SetActive(active);
                break;
            case Menus.LoadMenu:
                loadMenu.SetActive(active);
                break;
            case Menus.OptionsMenu:
                optionsMenu.SetActive(active);
                break;
        }
    }
}