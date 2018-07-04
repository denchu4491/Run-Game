using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Rock {

    private Animator animator;
    private bool isStop = false;
    public float speed = 0.0f;
    private PlayerScrooll playerCtrl;
    private Transform playerTrfm;
    private int patern;
    public float jumpOffset;
    private bool isJumped = false;
    private Rigidbody2D rgby2D;
    public float jumpPower;
    private bool jump;
    public float height;
    private float firsePosY;
    private bool canJump = true;

    void Awake() {
        animator = GetComponent<Animator>();
        playerTrfm = GameObject.Find("Player").transform;
        playerCtrl = playerTrfm.GetComponent<PlayerScrooll>();
        //rgby2D = GetComponent<Rigidbody2D>();
    }

    protected override  void Start() {
        base.Start();
        firsePosY = transform.position.y;
        patern = 0;
        //patern = Random.Range(0, 2);
    }

    protected override void Update() {
        if (isStop) return;
        if (playerCtrl.IsStop) Stop();
        base.Update();

        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void FixedUpdate() {
        switch (patern) {
            case 0:
                break;
            case 1:
                if (transform.position.x - playerTrfm.position.x < jumpOffset && !isJumped) {
                    jump = true;
                    isJumped = true;
                    animator.SetTrigger("Jump");
                }
                break;
        }
        if (jump) {
            Jump();
        }
    }

    public void Stop() {
        animator.speed = 0f;
        isStop = true;
    }

    public void Jump() {

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

        if (transform.position.y > firsePosY + height) {
            jump = false;
        }
    }
}
