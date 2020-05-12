using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Gamekit3D
{
public class PlayerControl : MonoBehaviour {

    public Transform player;
    public GameObject cameraBrain;
    public bool cameraIdle;
    public bool camerIdleTimerStart;
    public float cameraIdleTimer;
    public GameObject cameraRig;
	public float maxForwardSpeed = 8f;
	public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
	public float minTurnSpeed = 400f;  
	public float maxTurnSpeed = 1200f;
	public CameraSettings cameraSettings;
	protected MyInput m_Input; 
	protected CharacterController controller;
	protected float m_ForwardSpeed;
	protected float m_DesiredForwardSpeed;
	protected float m_AngleDiff;
     protected Animator m_Animator; 
	protected Quaternion m_TargetRotation;   
    private Vector3 moveDirection = Vector3.zero;
	const float k_InverseOneEighty = 1f / 180f;
	const float k_AirborneTurnSpeedProportion = 5.4f;
	const float k_GroundAcceleration = 20f;
    const float k_GroundDeceleration = 25f;
    private Vector3 target;
    CinemachineBrain cinemashine ;
	
	
	void Awake() {
        m_Animator = GetComponent<Animator>();
        cinemashine = cameraBrain.GetComponent<CinemachineBrain>();
        camerIdleTimerStart = false;
        cameraIdle = false;
        cameraIdleTimer = 0;
		 m_Input = GetComponent<MyInput>();
		 cameraSettings = FindObjectOfType<CameraSettings>();
		  if (cameraSettings != null)
            {
                if (cameraSettings.follow == null)
                    cameraSettings.follow = transform;

                if (cameraSettings.lookAt == null)
                    cameraSettings.follow = transform.Find("HeadTarget");
            }
	}
    
   void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                m_Animator.ResetTrigger("BackRun");
                m_Animator.ResetTrigger("Idle");
                m_Animator.ResetTrigger("Run");
                m_Animator.SetTrigger("Jump");
                moveDirection.y = jumpSpeed;
            }
        }
       if(cameraIdleTimer > 0)
       {
           cameraIdleTimer -= Time.deltaTime;
           if(cameraIdleTimer < 1)
           {
               cinemashine.enabled = false;
               cameraIdle = true;
               cameraIdleTimer = 0;
           }
       }
    if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
    {
        cameraIdleTimer = 0;
    }
       if(Input.GetAxis("Horizontal") == 0 && camerIdleTimerStart == false || Input.GetAxis("Vertical") == 0 && camerIdleTimerStart == false)
       {
           cameraIdleTimer = 10;
           camerIdleTimerStart = true;
       }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        target = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
        ///Animator Trigger
         if(Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0)
       {
           m_Animator.ResetTrigger("Idle");
           m_Animator.ResetTrigger("Run");
           m_Animator.SetTrigger("BackRun");
       }
        if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
       {
            m_Animator.ResetTrigger("BackRun");
            m_Animator.ResetTrigger("Idle");
            m_Animator.SetTrigger("Run");
       }
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
       {
           m_Animator.ResetTrigger("BackRun");
           m_Animator.ResetTrigger("Idle");
           m_Animator.ResetTrigger("Run");
           m_Animator.SetTrigger("Idle");
       }
   }
   void FixedUpdate() {
       if (cameraIdle == false && Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 )
          {
            camerIdleTimerStart = false;
            UpdateOrientation();
		    CalculateForwardMovement();
		    SetTargetRotation();
          }
        if (cameraIdle == true)
            {
                cameraRig.transform.RotateAround(target, Vector3.up, 10 * Time.deltaTime);
                if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    cameraIdle = false;
                    camerIdleTimerStart = false;
                    cinemashine.enabled = true;
                }
            }
   }
   protected bool IsMoveInput
        {
            get { return !Mathf.Approximately(m_Input.MoveInput.sqrMagnitude, 0f); }
        }
    void UpdateOrientation()
        {
			CharacterController controller = GetComponent<CharacterController>();
            Vector3 localInput = new Vector3(m_Input.MoveInput.x, 0f, m_Input.MoveInput.y);
            float groundedTurnSpeed = Mathf.Lerp(maxTurnSpeed, minTurnSpeed, m_ForwardSpeed / m_DesiredForwardSpeed);
            float actualTurnSpeed = controller.isGrounded ? groundedTurnSpeed : Vector3.Angle(transform.forward, localInput) * k_InverseOneEighty * k_AirborneTurnSpeedProportion * groundedTurnSpeed;
            m_TargetRotation = Quaternion.RotateTowards(transform.rotation, m_TargetRotation, actualTurnSpeed * Time.deltaTime);

            transform.rotation = m_TargetRotation;
        }
	 void CalculateForwardMovement()
        {
            // Cache the move input and cap it's magnitude at 1.
            Vector2 moveInput = m_Input.MoveInput;
            if (moveInput.sqrMagnitude > 1f)
                moveInput.Normalize();

            // Calculate the speed intended by input.
            m_DesiredForwardSpeed = moveInput.magnitude * maxForwardSpeed;

            // Determine change to speed based on whether there is currently any move input.
            float acceleration = IsMoveInput ? k_GroundAcceleration : k_GroundDeceleration;

            // Adjust the forward speed towards the desired speed.
            m_ForwardSpeed = Mathf.MoveTowards(m_ForwardSpeed, m_DesiredForwardSpeed, acceleration * Time.deltaTime);

            // Set the animator parameter to control what animation is being played.
           /// m_Animator.SetFloat(m_HashForwardSpeed, m_ForwardSpeed);
        }
	void SetTargetRotation()
        {
            // Create three variables, move input local to the player, flattened forward direction of the camera and a local target rotation.
            Vector2 moveInput = m_Input.MoveInput;
            Vector3 localMovementDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
            
            Vector3 forward = Quaternion.Euler(0f, cameraSettings.Current.m_XAxis.Value, 0f) * Vector3.forward;
            forward.y = 0f;
            forward.Normalize();

            Quaternion targetRotation;
            
            // If the local movement direction is the opposite of forward then the target rotation should be towards the camera.
            if (Mathf.Approximately(Vector3.Dot(localMovementDirection, Vector3.forward), -1.0f))
            {
                targetRotation = Quaternion.LookRotation(-forward);
            }
            else
            {
                // Otherwise the rotation should be the offset of the input from the camera's forward.
                Quaternion cameraToInputOffset = Quaternion.FromToRotation(Vector3.forward, localMovementDirection);
                targetRotation = Quaternion.LookRotation(cameraToInputOffset * forward);
            }

            // The desired forward direction of Ellen.
            Vector3 resultingForward = targetRotation * Vector3.forward;
            transform.rotation = Quaternion.LookRotation(resultingForward);

            float angleCurrent = Mathf.Atan2(transform.forward.x, transform.forward.z) * Mathf.Rad2Deg;
            float targetAngle = Mathf.Atan2(resultingForward.x, resultingForward.z) * Mathf.Rad2Deg;

            m_AngleDiff = Mathf.DeltaAngle(angleCurrent, targetAngle);
            m_TargetRotation = targetRotation;
        }
}
}
