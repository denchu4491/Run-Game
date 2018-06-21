using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour {

    public int spriteCount = 3;
    public float width;
    public float movepoint;
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(player.position.x - transform.position.x > movepoint && transform.position.x < player.position.x) {
            Move();
        }
    }

    void Move()
    {
        // 幅ｘ個数分だけ右へ移動
        transform.position += Vector3.right * width * spriteCount;
    }
}
