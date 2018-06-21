using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

    public float createInterval = 3.0f;
    public float offset = 5.0f;
    public float randamRange = 2.0f;
    private float lastCreateTime = 0f;
    private bool isStop = false;
    private Transform player;
    public GameObject[] setObject;


    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (isStop) return;

        if(lastCreateTime + createInterval < Time.time) {
            CreateObj();
        }
    }

    void CreateObj()
    {
        int select = 0;
        Instantiate(setObject[select], new Vector3(player.position.x + offset + Random.Range(-2.0f, 2.0f), setObject[select].transform.position.y, 0f), Quaternion.identity);
        lastCreateTime = Time.time;
    }

    public void Stop()
    {
        isStop = true;
    }
}
