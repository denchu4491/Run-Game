using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrooll : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidbody2d;
    public float moveSpeed = 3.0f;
    public float jumpPower = 10.0f, jumpCoolTime = 0.1f;
    private Vector2 velocity;
    private bool isGround;
    private bool inputJump, isJump;
    private float jumpTimeElapsed = 0f;
    public bool IsStop { get; private set; }
    public CreateObject createObject;
    public GameController gameCtrl;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        IsStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStop) return;

        inputJump = false;

        if (isJump) {
            jumpTimeElapsed += Time.deltaTime;
            if (jumpTimeElapsed > jumpCoolTime) {
                isJump = false;
                jumpTimeElapsed = 0.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            inputJump = true;
        }

    }

    private void FixedUpdate()
    {
        if (IsStop) return;

        velocity = Vector2.zero;

        Move();

        if (inputJump && isGround && !isJump) {
            Jump();
        }

        rigidbody2d.velocity = new Vector2(velocity.x, rigidbody2d.velocity.y);
    }

    private void Move()
    {
        velocity.x = moveSpeed;
        animator.SetFloat("MoveSpeed",1.1f);
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        rigidbody2d.AddForce(Vector2.up * jumpPower);
        isJump = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground") {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground") {
            isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Object") {
            Stop();
        }
    }

    private void Stop()
    {
        animator.speed = 0f;
        rigidbody2d.isKinematic = true;
        rigidbody2d.Sleep();
        IsStop = true;
        createObject.SendMessage("Stop");

        gameCtrl.SendMessage("GameOver");
    }

    public void ScrollStart() {
        IsStop = false;
    }
}
