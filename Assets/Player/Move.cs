using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	public AnimationCurve moveSpeed;

	public float slideFriction = 0.01f;
	
	private const float _analogThreshold = 0.1f;
	private Vector2 _horizontalVel;
	
	private Controls _controlScript;
	
	private float _moveTime = 0;
	private const float _inputThreshold = 0.1f; 
	
	private bool _movementEnabled = true;
	
	private bool _canDodge = false;
	public float dodgeTimeTreshold = 0.3f;
	public Vector2 dodgeFirstDirection;
	
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
			
			_horizontalVel = input.normalized * moveSpeed.Evaluate(_moveTime);
			
			Vector3 moveVec = new Vector3();
			
			//finally build the velocity vector
			moveVec.x = _horizontalVel.x;
			moveVec.z = _horizontalVel.y;
			
			_lastMoveVec = moveVec;
			rigidbody.velocity = moveVec;
		}
		else
		{
			Vector3 moveVec = Vector3.Lerp(_lastMoveVec, Vector3.zero, slideFriction * Time.deltaTime);
			_lastMoveVec = moveVec;
			rigidbody.velocity = moveVec;
		}
		
	}
	
	public void SetMovementEnabled(bool trigger)
	{
		_movementEnabled = trigger;
	}
}