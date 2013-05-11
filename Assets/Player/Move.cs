using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	public AnimationCurve moveSpeed;
	public AnimationCurve jumpSpeed;
	public AnimationCurve doubleJumpSpeed;
	public float normalJumpForwardVel = 10f;
	
	public float inAirMovementDampening = 1.0f;
	
	public float maxSpeedDown = 10f;
	public float gravity = 9.8f;
	public float slideFriction = 0.01f;
	public float inAirDirectionChange = 4f;
	public float rotationChangeSpeed = 0.5f;
	public float extremeRotationChangeSpeed = 0.5f;
	
	public float groundRayLength = 1f;
	public float groundSphereRadius = 0.3f;
	
	private bool _isApplyingNormalJumping = false;
	public bool IsNormalJumping
	{
		get{return _isApplyingNormalJumping;}	
	}
	
	private bool _isApplyingDoubleJumping = false;
	public bool IsDoubleJumping
	{
		get{return _isApplyingDoubleJumping;}	
	}
	
	public float groundedDelayTime = 0.1f;
	private bool _isGroundedDelayed = false;
	
	private bool _isGrounded = false;
	public bool IsGrounded
	{
		get{return _isGrounded;}	
	}
	
	private const float _analogThreshold = 0.1f;
	private Vector2 _horizontalVel;
	
	private Controls _controlScript;
	
	private float _moveTime = 0;
	private const float _inputThreshold = 0.1f; 
	


	
	private bool _movementEnabled = true;
	

	
	public void OnRespawn()
	{

		_moveTime = 0;
		
		rigidbody.velocity = Vector3.zero;
		
		_horizontalVel = Vector2.zero;
	}
	
	public Vector2 HorizontalVelocity
	{
		get{return new Vector2(rigidbody.velocity.x, rigidbody.velocity.z);}
	}
	
	
	void Start()
	{
		_controlScript = GetComponent<Controls>();
		
	}
			
	private Vector3 _lastMoveVec = Vector3.forward;
		
	void Update()
	{

		Vector2 input;
		
		if(_movementEnabled)
			input = _controlScript.GetMoveDirection2D();
		else
			input = Vector2.zero;
		
		if(input.magnitude > _inputThreshold)
		{
			_moveTime += Time.deltaTime;
		}
		else
			_moveTime = 0;
		
		_horizontalVel = input.normalized * moveSpeed.Evaluate(_moveTime);
		
		Vector3 moveVec = new Vector3();
		
		//finally build the velocity vector
		moveVec.x = _horizontalVel.x;
		moveVec.z = _horizontalVel.y;
		
		/*
		float dot = 1 - ( 1 + Vector3.Dot(_lastMoveVec.normalized, moveVec.normalized) ) / 2;
		
		float rotationSpeed = ( dot * extremeRotationChangeSpeed + rotationChangeSpeed ) * Time.deltaTime;
		
		float moveMagnitude = moveVec.magnitude;
		
		moveVec = Vector3.RotateTowards(_lastMoveVec.normalized, moveVec.normalized , rotationSpeed, 10f);
		moveVec.y = 0;
		
		if(moveVec.magnitude > _analogThreshold)
			_lastMoveVec = moveVec;
		
		moveVec = moveVec * moveMagnitude * (1.01f - dot);
		
		moveVec.y = rigidbody.velocity.y;
		*/
		
		rigidbody.velocity = moveVec;
	}
	
	public void SetMovementEnabled(bool trigger)
	{
		_movementEnabled = trigger;
	}
}