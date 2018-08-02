using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private GameObject level;
    private GameObject ui;
    // Use this for initialization
    void Start () {
		
	}
    private void OnEnable()
    {
        level = GameObject.FindGameObjectWithTag("Level");
        level.SetActive(false);
        ui = GameObject.FindGameObjectWithTag("UI");
        ui.SetActive(false);
    }
    public void Resume()
    {
        level.SetActive(true);
        ui.SetActive(true);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
