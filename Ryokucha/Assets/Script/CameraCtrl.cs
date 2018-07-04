using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

    private Transform player;
    public float offset;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x + offset, transform.position.y, transform.position.z);
	}
}
