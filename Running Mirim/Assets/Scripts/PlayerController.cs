﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidbody;

    public bool grounded; //checkbox. ground에 닿았는지 체크하는 변수.
    public LayerMask whatIsGround; // list
    public Transform groundCheck;
    public float groundCheckRadius;

    //private Collider2D myCollider;

    public GameManager theGameManager;
    public HPManager thehpManager;

    public bool greet; //인사확인 변수
    private Animator myAnimator;
    bool inputGreet = false;


    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
       // myCollider = GetComponent<Collider2D>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;
    }
	
	// Update is called once per frame
	void Update () {

        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);// Player을 moveSpeed만큼 앞으로 이동. Vector2는 x,y좌표 저장. 

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetBool("Greet", greet);

        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //스페이스바나 마우스 눌렸을 때
        //{
        //    //ground에 닿으면 점프가능
        //    if(grounded)
        //    {
        //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        //        stoppedJumping = false;
        //    }
        //    if(!grounded && canDoubleJump)
        //    {
        //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        //        jumpTimeCounter = jumpTime;
        //        stoppedJumping = false;
        //        canDoubleJump = false;
        //    }
                       
        //}
        //if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping) 
        //{
        //    if(jumpTimeCounter >0) // 이중점프
        //    {
        //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        //        jumpTimeCounter -= Time.deltaTime;
        //    }
        //}

        //if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        //{
        //    jumpTimeCounter = 0;
        //    stoppedJumping = true;
        //}

        //if(grounded)
        //{
        //    jumpTimeCounter = jumpTime;
        //    canDoubleJump = true;
        //}

        
	}

    public void JumpButtonClick()
    {
        if (grounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            stoppedJumping = false;
        }
        if (!grounded && canDoubleJump)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            jumpTimeCounter = jumpTime;
            stoppedJumping = false;
            canDoubleJump = false;
        }
        if (jumpTimeCounter > 0 && !stoppedJumping) // 이중점프
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }
        jumpTimeCounter = 0;
        stoppedJumping = true;
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="killbox")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
     
    }

    public void GreetButtonDown()
    {
        greet = true;
    }

    public void GreetButtonUp()
    {
        greet = false;
    }
}
