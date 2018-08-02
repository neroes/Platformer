using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {// contains game info
    public int lives;
    public int score;
    public int coins;
    public enum EasyLayers {
        GroundEvenLayer = 1<<8,
        GroundLayer = 1 << 8 | 1<<9,
        Playerlayer = 1 << 10,
        EntitiesLayer = 1 << 11,
        FallThroughLayer = 1 << 12
    }

    private Levelscript levelscript;
    private UIClass ui;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        lives = 3;
        score = 0;
        coins = 0;
    }
    public void SetLevelScript(Levelscript levelscript)
    {
        this.levelscript = levelscript;
    }
    public void SetUI(UIClass ui)
    {
        this.ui = ui;
        ui.UpdateCoins(coins);
        ui.UpdateLives(lives);
        ui.UpdateScore(score);
    }
    public void LoadLevel(string sceneTarget)
    {
        CleanLevel();
        ui.ResetTime();
        SceneManager.LoadScene(sceneTarget);
    }
    public void CleanLevel()
    {
        levelscript.CleanLevel();
    }
}
