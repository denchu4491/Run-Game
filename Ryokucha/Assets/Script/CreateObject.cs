using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

    public float createInterval = 3.0f;
    public float offset = 5.0f;
    public float minOffset = 3.0f, maxOffset = 5.0f;
    public float randamRange = 2.0f;
    private float lastCreateTime = 0f;
    private bool isStop = false;
    private Transform player;
    public GameObject[] setObject;
    public float eaglePosY = 0.0f;
    private Vector3 prevObjPos;
    private int objCount;
    public int maxObjCount = 3;
   
    private void Awake() {
       
    }

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        prevObjPos = new Vector3(2.0f, 0f, 0f);
    }

    private void Update()
    {
        if (!GameController.isPlaying) return;

        /*if(lastCreateTime + createInterval < Time.time) {
            CreateObj();
        }*/
        if (objCount < maxObjCount) {
            CreateObj();
        }
    }

    void CreateObj()
    {
        // 0はRock、1はEagle
        int select = Random.Range(0, setObject.Length);
        //int select = 2;
        float diffX = offset + Random.Range(-randamRange, randamRange);
        Vector3 createPos = Vector3.zero;

        switch (select) {
            case 0:
                createPos = new Vector3(prevObjPos.x + diffX, setObject[select].transform.position.y, 0f);
                createPos.x = Mathf.Clamp(createPos.x, prevObjPos.x + minOffset, prevObjPos.x + maxOffset);
                Instantiate(setObject[select], createPos, Quaternion.identity);
                break;

            case 1:
                int y = Random.Range(0, 2);
                createPos = new Vector3(prevObjPos.x + diffX, setObject[select].transform.position.y + (y * eaglePosY), 0f);
                createPos.x = Mathf.Clamp(createPos.x, prevObjPos.x + minOffset, prevObjPos.x + maxOffset);
                Instantiate(setObject[select], createPos, Quaternion.identity);
                break;
            case 2:
                createPos = new Vector3(prevObjPos.x + diffX, setObject[select].transform.position.y, 0f);
                createPos.x = Mathf.Clamp(createPos.x, prevObjPos.x + minOffset, prevObjPos.x + maxOffset);
                Instantiate(setObject[select], createPos, Quaternion.identity);
                break;
        }

        prevObjPos = createPos;
        lastCreateTime = Time.time;
        CountUp();
    }

    public void Stop()
    {
        isStop = true;
    }

    public void CountUp() {
        objCount++;
    }

    public void CountDown() {
        objCount--;
    }
}
