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
    public float eaglePosY = 0.0f;


    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (!GameController.isPlaying) return;

        if(lastCreateTime + createInterval < Time.time) {
            CreateObj();
        }
    }

    void CreateObj()
    {
        // 0はRock、1はEagle
        int select = 1;
        float diffX = offset + Random.Range(-2.0f, 2.0f);

        switch (select) {
            case 0:
                Instantiate(setObject[select], new Vector3(player.position.x + diffX, setObject[select].transform.position.y, 0f), Quaternion.identity);
                break;

            case 1:
                int y = Random.Range(0, 2);
                Instantiate(setObject[select], 
                                 new Vector3(player.position.x + diffX, setObject[select].transform.position.y + (y * eaglePosY), 0f), 
                                    Quaternion.identity);
                break;
        }
        lastCreateTime = Time.time;
    }

    public void Stop()
    {
        isStop = true;
    }
}
