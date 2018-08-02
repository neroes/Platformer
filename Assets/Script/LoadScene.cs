using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public string sceneTarget;
    public string fieldText;
	// Use this for initialization
	void Start () {
        GetComponentInChildren<TextMesh>().text = fieldText;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButtonDown("Use"))
            {
                GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
                gameManager.LoadLevel(sceneTarget);
            }
        }
    }
}
