using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    public float destroyPoint;
    private Transform player;

    protected virtual void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    protected virtual void Update()
    {
        if (player.position.x - transform.position.x > destroyPoint) {
            GameObject.Find("CreateObjectManage").GetComponent<CreateObject>().CountDown();
            Destroy(gameObject);
        }
    }
}
