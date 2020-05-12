using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
	public float distance;
	public GameObject player;
	public LayerMask moveObjectMask;
	public LayerMask verevkaObjectMask;
	public GameObject moveObject;
	public GameObject verevkaObject;
	public	Rigidbody2D rbMoveObject;
	public Transform raycastmoveObject;
	public bool raycasthitcontroller;
	private float raycontrollertimer;
	PlayerController playercontrollerscr;
	public TimeManager timemanager;


	// Use this for initialization
	void Start () {
		playercontrollerscr = player.GetComponent<PlayerController>();
		raycasthitcontroller = true;
		raycontrollertimer = 0.05f;
	}
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit2 =	Physics2D.Raycast(raycastmoveObject.position,Vector2.right*transform.localScale.x,1.0f,verevkaObjectMask);
		if(hit2.collider != null && playercontrollerscr.grounding == false && raycasthitcontroller == true)
			{
				playercontrollerscr.rope = true;
				verevkaObject = hit2.collider.gameObject;
				verevkaObject.GetComponent<RopeMoveObject>().enabled = true;
				player.GetComponent<RopeWalking>().enabled = true;
				rbMoveObject = verevkaObject.GetComponent<Rigidbody2D>();
				rbMoveObject.constraints = RigidbodyConstraints2D.None;
				verevkaObject.GetComponent<FixedJoint2D>().enabled = true;
				verevkaObject.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
			}
		if(raycasthitcontroller == false)
		{
			raycontrollertimer -= Time.deltaTime;
			if(raycontrollertimer < 0)
			{
				raycasthitcontroller = true;
				raycontrollertimer = 0.05f;
			}
		}
		Physics2D.queriesStartInColliders = false;
		if(Input.GetKey(KeyCode.LeftShift) && raycasthitcontroller == true)
		{
			RaycastHit2D hit =	Physics2D.Raycast(raycastmoveObject.position,Vector2.right*transform.localScale.x,distance,moveObjectMask);
			if(hit.collider != null && playercontrollerscr.grounding == true)
			{
				playercontrollerscr.moveObjectB = true;
				moveObject = hit.collider.gameObject;
				rbMoveObject = moveObject.GetComponent<Rigidbody2D>();
				rbMoveObject.constraints = RigidbodyConstraints2D.None;
				moveObject.GetComponent<FixedJoint2D>().enabled = true;
				moveObject.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
			}
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)&& moveObject != null)
		{
			MoveObjectDestroy();
		}
	}
	void FrezzyAllPosition()
	{
			rbMoveObject.constraints = RigidbodyConstraints2D.FreezeAll;
			moveObject = null;
	}
	public void RopeDestroy()
	{
		if(verevkaObject != null)
		{
			raycasthitcontroller = false;
			playercontrollerscr.moveObjectB = false;
			verevkaObject.GetComponent<RopeMoveObject>().enabled = false;
			verevkaObject.GetComponent<FixedJoint2D>().connectedBody = null;
			verevkaObject.GetComponent<FixedJoint2D>().enabled = false;
			player.GetComponent<RopeWalking>().enabled = false;
			rbMoveObject = null;
			verevkaObject = null;
			playercontrollerscr.rope = false;
		}
	}	
	void MoveObjectDestroy()
	{
		if(moveObject != null)
		{
			raycasthitcontroller = false;
			moveObject.GetComponent<FixedJoint2D>().enabled = false;
			playercontrollerscr.moveObjectB = false;
			FrezzyAllPosition();
			moveObject = null;
			rbMoveObject = null;
		}
	}
}
