using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);// Player을 moveSpeed만큼 앞으로 이동. Vector2는 x,y좌표 저장. 
           
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //스페이스바나 마우스 눌렸을 때
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        }
	}
}
