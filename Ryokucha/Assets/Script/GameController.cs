﻿using System.Collections;
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
        else if (!isPlaying && Input.GetKeyDown(KeyCode.Return)) {
            GameStart();
        }
	}

    public void GameStart() {
        start.SetActive(false);
        isPlaying = true;
        player.ScrollStart();
    }

    public void GameOver() {
        if (isPlaying) {
            gameOver.SetActive(true);
            isPlaying = false;
            isGameOver = true;
        }
    }
}