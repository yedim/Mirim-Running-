using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter; 

    private Rigidbody2D myRigidbody;

    public bool grounded; //checkbox. ground에 닿았는지 체크하는 변수.
    public LayerMask whatIsGround; // list

    private Collider2D myCollider;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        jumpTimeCounter = jumpTime;
    }
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);// Player을 moveSpeed만큼 앞으로 이동. Vector2는 x,y좌표 저장. 
           
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //스페이스바나 마우스 눌렸을 때
        {
            //ground에 닿으면 점프가능
            if(grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) 
        {
            if(jumpTimeCounter >0) // 이중점프
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }

        if(grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        
	}
}
