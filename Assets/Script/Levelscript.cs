using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelscript : MonoBehaviour {
    void Start()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().SetLevelScript(this);
        
    }
    public void CleanLevel()
    {
        Destroy(gameObject);
    }
}
