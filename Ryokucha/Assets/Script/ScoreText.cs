using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    private Transform player;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: " + string.Format("{0:000000}",player.position.x * 10);
	}
}
