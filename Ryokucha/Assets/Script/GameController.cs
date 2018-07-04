using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static bool isPlaying;
    public GameObject start;
    public GameObject gameOver;
    public PlayerScrooll player;
    private bool isGameOver;
    public string sceneName;
    public ScoreText scoreText;
    public AudioSource audioSource;

    private void Awake() {
        player = GameObject.Find("Player").GetComponent<PlayerScrooll>();
    }

    // Use this for initialization
    void Start () {
        gameOver.SetActive(false);
        start.SetActive(true);
        isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameOver) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(sceneName);
            }
        }
        else if (!isPlaying && Input.GetKeyDown(KeyCode.Space)) {
            GameStart();
        }
        if (Input.GetKeyDown(KeyCode.F1)) {
            scoreText.Reset();
        }
	}

    public void GameStart() {
        start.SetActive(false);
        audioSource.Play();
        isPlaying = true;
        player.ScrollStart();
    }

    public void GameOver() {
        if (isPlaying) {
            gameOver.SetActive(true);
            audioSource.Stop();
            isPlaying = false;
            isGameOver = true;
            scoreText.Save();
        }
    }
}
