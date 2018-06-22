using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    private Transform player;
    public Text scoreText;
    public Text highscoreText;
    private float score;
    private float highScore;

    // Use this for initialization
    void Start () {
        score = 0;
        player = GameObject.Find("Player").transform;
        highScore = PlayerPrefs.GetFloat("highScoreKey", 0);
        highscoreText.text = "Hi:" + string.Format("{0:000000}", highScore * 10);
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameController.isPlaying) return;
        score = player.position.x;

        scoreText.text = string.Format("{0:000000}", score * 10);
    }

    public void Save() {
        if (highScore < score) {
            highScore = score;
            highscoreText.text = "Hi:" + string.Format("{0:000000}", highScore * 10);
            PlayerPrefs.SetFloat("highScoreKey", highScore);
            PlayerPrefs.Save();
        }
    }

    public void Reset() {
        highScore = 0f;
        highscoreText.text = "Hi:" + string.Format("{0:000000}", highScore * 10);
        PlayerPrefs.DeleteKey("highScoreKey");
    }
}
