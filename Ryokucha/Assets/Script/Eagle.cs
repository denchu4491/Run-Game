using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Rock {

    private Animator animator;
    private bool isStop = false;
    public float speed = 0.0f;
    private PlayerScrooll playerCtrl;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerScrooll>();
    }

    protected override void Update()
    {
        if (isStop) return;
        if (playerCtrl.IsStop) Stop();

        base.Update();

        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void Stop()
    {
        animator.speed = 0f;
        isStop = true;
    }

}
