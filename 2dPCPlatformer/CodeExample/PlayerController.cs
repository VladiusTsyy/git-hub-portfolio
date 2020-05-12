using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	public LayerMask groundLayerMask;
	public LayerMask wallLayerMask;
	public GameObject player;
	public float jumppower;
	public float speedrun;
	public float speedmove;
	public bool grounding;
	public bool forwardWall;
	public Transform wallCheck;
	public Transform groundCheck;
	public float groundcheckRadius;
	public float move;
	public bool runleft;
	public bool runright;
	public bool jump;
	private Rigidbody2D rb;
	public bool moveObjectB;
	public bool rope;
	public bool ropeJump;
	


	// Use this for initialization
	void Start () {
		rope = false;
		rb = GetComponent<Rigidbody2D>();
		runright = false;
		runleft = false;
		jump = false;
		ropeJump = false;
		moveObjectB = false;
	}
	
	// Update is called once per frame
	void Update () {	
		if(Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
		float movex = Input.GetAxisRaw("Horizontal");
		move = movex;
		/// Right run
		if(movex > 0 && grounding == true && Input.GetKeyDown(KeyCode.Space) == false)
		{
			runright = true;
		}
		else
			runright = false;
		/// Left run
		if(movex < 0 && grounding == true && Input.GetKeyDown(KeyCode.Space) == false)
		{
			runleft = true;
		}
		else
			runleft = false;
		/// Idle
		if(movex == 0)
		{
			player.GetComponent<Animator>().ResetTrigger ("Run");
			player.GetComponent<Animator>().SetTrigger ("Idle");
		}
		/// Rope Jump slow motion
		if( Input.GetKeyDown(KeyCode.Space) && rope == true)
		{
			ropeJump = true;
		}
		/// Jump
		if(Input.GetKeyDown(KeyCode.Space) && grounding == true && moveObjectB == false)
		{
			jump = true;
		}
		else
		{
			jump = false;
		}
	}
	void FixedUpdate() {
		Vector3 theScale = transform.localScale;
		forwardWall = Physics2D.OverlapCircle(wallCheck.position,groundcheckRadius,wallLayerMask);
		grounding =  Physics2D.OverlapCircle(groundCheck.position,groundcheckRadius,groundLayerMask);
		///MoveObject
		if(runleft == true && moveObjectB == true && rope == false)
		{
			transform.localScale = theScale;
			if(theScale.x == -1)
			{
				player.GetComponent<Animator>().ResetTrigger ("Wall");
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFL");
				player.GetComponent<Animator>().ResetTrigger ("Idle");
				player.GetComponent<Animator>().ResetTrigger ("Run");
				player.GetComponent<Animator>().SetTrigger ("MoveobjectFR");///SetTrigger MoveGame Object
			}
				if(theScale.x == 1)
			{
				player.GetComponent<Animator>().ResetTrigger ("Wall");
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFR");
				player.GetComponent<Animator>().ResetTrigger ("Idle");
				player.GetComponent<Animator>().ResetTrigger ("Run");
				player.GetComponent<Animator>().SetTrigger ("MoveobjectFL");///SetTrigger MoveGame Object
			}
			rb.MovePosition(rb.position + Vector2.right * move * (speedmove) * Time.deltaTime);
		}
		if(runright == true  && moveObjectB == true && rope == false)
		{
			transform.localScale = theScale;
			if(theScale.x == 1)
			{
				player.GetComponent<Animator>().ResetTrigger ("Wall");
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFL");
				player.GetComponent<Animator>().ResetTrigger ("Idle");
				player.GetComponent<Animator>().ResetTrigger ("Run");
				player.GetComponent<Animator>().SetTrigger ("MoveobjectFR");///SetTrigger MoveGame Object
			}
			if(theScale.x == -1)
			{
				player.GetComponent<Animator>().ResetTrigger ("Wall");
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFR");
				player.GetComponent<Animator>().ResetTrigger ("Idle");
				player.GetComponent<Animator>().ResetTrigger ("Run");
				player.GetComponent<Animator>().SetTrigger ("MoveobjectFL");///SetTrigger MoveGame Object
			}
			rb.MovePosition(rb.position + Vector2.right * move *  (speedmove) * Time.deltaTime);
		}
		///Rope Run
		if(move < 0 && rope == true)
		{
			rb.AddForce(Vector2.left * 500 * Time.deltaTime,ForceMode2D.Impulse);
		}
		if(move > 0 && rope == true)
		{
			rb.AddForce(Vector2.right * 500 * Time.deltaTime,ForceMode2D.Impulse);
		}
		///Run
		if(runleft == true && moveObjectB == false)
		{
			theScale.x = -1;
			transform.localScale = theScale;
			if(forwardWall == false)
			{
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFL");
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFR");
				player.GetComponent<Animator>().ResetTrigger ("Idle");
				player.GetComponent<Animator>().SetTrigger ("Run");
				rb.MovePosition(rb.position + Vector2.right * move * speedrun * Time.deltaTime);
			}
		}
		if(runright == true  && moveObjectB == false )
		{
			
			theScale.x = 1;
			transform.localScale = theScale;
			if(forwardWall == false)
			{
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFL");
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFR");
				player.GetComponent<Animator>().ResetTrigger ("Idle");
				player.GetComponent<Animator>().SetTrigger ("Run");
				rb.MovePosition(rb.position + Vector2.right * move * speedrun * Time.deltaTime);
			}
		}
		///RopeJumpSlowMoution
		if(ropeJump == true)
	{
		for (int i = 0; i < 1; i++)
		{
			if( move == 0)
			{
				Debug.Log("move=0");
				player.GetComponent<Animator>().ResetTrigger ("Rope");
				player.GetComponent<Animator>().SetTrigger ("Jump");
				rb.velocity = new Vector3(0, 30,0);
				player.GetComponent<MoveObject>().RopeDestroy();
				ropeJump = false;
				break;
			}

				if(move < 0)
				{
					player.GetComponent<MoveObject>().RopeDestroy();
					player.GetComponent<Animator>().ResetTrigger ("Rope");
					player.GetComponent<Animator>().SetTrigger ("Jump");
					rb.velocity = new Vector3(-15, 30,0);
					theScale.x = -1;
					transform.localScale = theScale;
					ropeJump = false;
					break;
				}
					if(move > 0)
				{
					player.GetComponent<MoveObject>().RopeDestroy();
					player.GetComponent<Animator>().ResetTrigger ("Rope");
					player.GetComponent<Animator>().SetTrigger ("Jump");
					rb.velocity = new Vector3(15, 30,0);
					theScale.x = 1;
					transform.localScale = theScale;
					ropeJump = false;
					break;
				}
		}
	}
		
		///Jump
		if(jump == true && forwardWall == false)
		{
			for (int i = 0; i < 1; i++)
			{
				player.GetComponent<Animator>().ResetTrigger ("Rope");
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFL");
				player.GetComponent<Animator>().ResetTrigger ("MoveobjectFR");
				player.GetComponent<Animator>().ResetTrigger ("Idle");
				player.GetComponent<Animator>().ResetTrigger ("Run");
				player.GetComponent<Animator>().SetTrigger ("Jump");
				if(move == 0)
				{
					rb.velocity = new Vector2(0, 40);
					jump = false;	
					break;
				}
				if(move < 0)
				{
					rb.velocity = new Vector2(-15, 40);	
					jump = false;	
					break;
				
				}
				if(move > 0)
				{
					rb.velocity = new Vector2(15, 40);	
					jump = false;
					break;
				}
					
			}
			
			
		}
		///Wall Jump
		if(forwardWall == false & move > 0)
		{
			player.GetComponent<Animator>().ResetTrigger ("Wall");
		}
		if(forwardWall == false && grounding == false && move > 0 && moveObjectB == false)
					{
						rb.AddForce(Vector2.right *80);
						player.GetComponent<Animator>().ResetTrigger ("WallUp");

					}
					if(forwardWall == false && grounding == false && move < 0)
					{
						rb.AddForce(Vector2.left *80);
						player.GetComponent<Animator>().ResetTrigger ("WallUp");
					}
		if(forwardWall == true && move != 0 && moveObjectB == false)
		{
				player.GetComponent<Animator>().ResetTrigger ("Idle");
				player.GetComponent<Animator>().ResetTrigger ("Run");
				player.GetComponent<Animator>().SetTrigger ("Wall");
		
			if(jump == true && move > 0 && moveObjectB == false)
			{
				
					player.GetComponent<Animator>().ResetTrigger ("MoveobjectFL");
					player.GetComponent<Animator>().ResetTrigger ("MoveobjectFR");
					player.GetComponent<Animator>().ResetTrigger ("Wall");
					player.GetComponent<Animator>().ResetTrigger ("Run");
					player.GetComponent<Animator>().ResetTrigger ("Idle");
					player.GetComponent<Animator>().SetTrigger ("WallUp");
					rb.velocity = new Vector2(0, 50);
				
			}
			if(jump == true && move < 0 && moveObjectB == false)
				{
					player.GetComponent<Animator>().ResetTrigger ("MoveobjectFL");
					player.GetComponent<Animator>().ResetTrigger ("MoveobjectFR");
					player.GetComponent<Animator>().ResetTrigger ("Wall");
					player.GetComponent<Animator>().ResetTrigger ("Run");
					player.GetComponent<Animator>().ResetTrigger ("Idle");
					player.GetComponent<Animator>().SetTrigger ("WallUp");
					rb.velocity = new Vector2(0, 50);
				}
		}
	}
}
	
