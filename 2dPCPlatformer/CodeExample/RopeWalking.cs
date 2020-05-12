using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeWalking : MonoBehaviour {
	public bool up;
	public bool down;
	public float walkspeed;
	public bool grounding;
	public GameObject player;
	PlayerController playercontrollerscr;
	Rigidbody2D rbMoveObj;
	public GameObject moveobj;
	public float distancejoint2d;
	public bool ropeObject;
	public float moveY;

	// Use this for initialization
	void Start () {
		up = false;
		down = false;
		playercontrollerscr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		ropeObject = playercontrollerscr.rope;
		grounding = playercontrollerscr.grounding;
		float movey = Input.GetAxis("Vertical");
		moveY = movey;
		if(movey > 0 && grounding == false && Input.GetKeyDown(KeyCode.W) == true)
		{
			down = false;
			up = true;
		}
		///if up = false;
		if(movey < 0 && grounding == false && Input.GetKeyDown(KeyCode.S) == true)
		{
			up = false;
			down = true;
		}
		///if down = false;
		if(ropeObject == true)
		{	
			player.GetComponent<Animator>().ResetTrigger ("Run");
			player.GetComponent<Animator>().ResetTrigger ("Jump");
			player.GetComponent<Animator>().ResetTrigger ("Idle");
			player.GetComponent<Animator>().SetTrigger ("Rope");
			moveobj = player.GetComponent<MoveObject>().verevkaObject;
			if(moveobj != null)
			{
				distancejoint2d = moveobj.GetComponent<DistanceJoint2D>().distance;
				rbMoveObj = moveobj.GetComponent<Rigidbody2D>();

			}
		if(movey == 0)
		{
			up = false;
			down = false;
		}
		}
	}
	void FixedUpdate() {
		
		if(up == true )
		{
			distancejoint2d -= walkspeed;
			rbMoveObj.MovePosition(rbMoveObj.position + Vector2.up * moveY * walkspeed * Time.deltaTime);
			player.GetComponent<Animator>().ResetTrigger ("Rope");
			player.GetComponent<Animator>().ResetTrigger ("Down");
			player.GetComponent<Animator>().SetTrigger ("Up");
			if(moveobj != null && distancejoint2d > 4.2f)
			{
				moveobj.GetComponent<DistanceJoint2D>().distance = distancejoint2d;
			}
		}
		if(up == false)
		{
			player.GetComponent<Animator>().ResetTrigger ("Up");
			player.GetComponent<Animator>().SetTrigger ("Rope");
		}
		if(down == true)
		{
			distancejoint2d += walkspeed;
			rbMoveObj.MovePosition(rbMoveObj.position + Vector2.down * moveY * walkspeed * Time.deltaTime);
			player.GetComponent<Animator>().ResetTrigger ("Rope");
			player.GetComponent<Animator>().ResetTrigger ("Up");
			player.GetComponent<Animator>().SetTrigger ("Down");
			if(moveobj != null && distancejoint2d < 13.79f)
			{
				moveobj.GetComponent<DistanceJoint2D>().distance = distancejoint2d;
			}
		}
		if(down == false)
		{
			player.GetComponent<Animator>().ResetTrigger ("Down");
			player.GetComponent<Animator>().SetTrigger ("Rope");
		}
		
	}
}
