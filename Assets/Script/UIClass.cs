using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIClass : MonoBehaviour {

    private float mapTime;

    public Text lives;
    public Text time;
    public Text coins;
    public Text score;
    // Use this for initialization
    void Start () {
        ResetTime();
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().SetUI(this);

    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ResetTime() { mapTime = 0.0f; }

    // Update is called once per frame
    void Update () {
        
        time.text = mapTime.ToString("0");
        mapTime += Time.deltaTime;
	}
    public void UpdateLives(int value) { lives.text = value.ToString(); }
    public void UpdateCoins(int value) { coins.text = value.ToString(); }
    public void UpdateScore(int value) { score.text = value.ToString(); }
}
