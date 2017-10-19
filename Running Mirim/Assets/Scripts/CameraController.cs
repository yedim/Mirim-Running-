using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController thePlayer;
    private Vector3 lastPlayerPosition; //Vector3는 x,y,z 좌표.
    private float distanceToMove;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();// Player 위치값 알아내기
        lastPlayerPosition = thePlayer.transform.position; //Player의 초기 위치.
	}
	
	// Update is called once per frame
	void Update () {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; //움직여야 할 거리는 현재 위치에서 초기 위치 뺀 만큼
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = thePlayer.transform.position;
	}
}
