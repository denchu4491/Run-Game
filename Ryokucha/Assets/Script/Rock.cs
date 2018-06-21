﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    public float destroyPoint;
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    protected virtual void Update()
    {
        if (player.position.x - transform.position.x > destroyPoint) {
            Destroy(gameObject);
        }
    }
}