using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidbody2d;
    public float moveSpeed = 3.0f;
    private float direction, dirOld;
    public float jumpPower = 10.0f, jumpCoolTIme = 1.0f;
    private Vector2 velocity;
    private bool isGround;
    private float horizon;
    private bool inputJump, isJump;
    private float jumpTimeElapsed = 0f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        direction = Mathf.Sign(transform.localScale.x);
	}
	
	// Update is called once per frame
	void Update () {
        horizon = Input.GetAxis("Horizontal");
        inputJump = false;

        if (isJump) {
            jumpTimeElapsed += Time.deltaTime;
            if (jumpTimeElapsed > jumpCoolTIme) {
                isJump = false;
                jumpTimeElapsed = 0.0f;
            }
        }

        if (horizon != 0f) {
            if(direction != Mathf.Sign(horizon)) {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                direction *= -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
;           // Debug.Log(isGround + " " + isJump);
            inputJump = true;
        }

	}

    private void FixedUpdate()
    {
        velocity = Vector2.zero;

        Move();
        
        if (inputJump && isGround && !isJump) {
            Jump();
        }

        rigidbody2d.velocity = new Vector2(velocity.x, rigidbody2d.velocity.y);
    }

    private void Move()
    {
        velocity.x = horizon * moveSpeed;

        if (horizon != 0.0f) {
            animator.SetFloat("MoveSpeed", 1.1f);
        } else {
            animator.SetFloat("MoveSpeed", 0f);
        }
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        rigidbody2d.AddForce(Vector2.up * jumpPower);
        isJump = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.tag == "Ground") {
            isGround = true;
            animator.SetTrigger("Idle");
        }*/
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Ground") {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground") {
            isGround = false;
        }
    }
}
