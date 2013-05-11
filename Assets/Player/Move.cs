using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	public AnimationCurve moveSpeed;

	public float slideFriction = 0.01f;
	
	private Vector2 _horizontalVel;
	
	private Controls _controlScript;
	
	private float _moveTime = 0;
	private const float _inputThreshold = 0.9f; 
	
	private bool _movementEnabled = true;
	
	private bool _canDodge = false;
	private bool _startDodge = false;
	
	private ParticleEmitter _emitter;
	public float dodgeSpeed = 20;
	public float dodgeDotThreshold = 0.5f;
	public float dodgeTimeThreshold = 0.3f;
	public Vector2 dodgeFirstDirection;
	public float dodgeDuration = 1f;
	private bool _dodging = false;
	public bool dodging
	{
		get{return _dodging;}	
	}
	
	private TakeDamage _damageScript;
	
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
		_damageScript = GetComponent<TakeDamage>();
		_controlScript = GetComponent<Controls>();
		
		_emitter = transform.Find("Detailed Smoke").particleEmitter;
	}
			
	private Vector3 _lastMoveVec = Vector3.forward;
		
	void Update()
	{

		Vector2 input;
		
		if(_movementEnabled)
			input = _controlScript.GetMoveDirection2D();
		else
			input = Vector2.zero;
		
		if(dodging)
			return;
		
		if(input.magnitude > _inputThreshold)
		{
			_moveTime += Time.deltaTime;
			
			_horizontalVel = input.normalized * moveSpeed.Evaluate(_moveTime);
			
			Vector3 moveVec = new Vector3();
			
			moveVec.x = _horizontalVel.x;
			moveVec.z = _horizontalVel.y;
			
			_lastMoveVec = moveVec;
			rigidbody.velocity = moveVec;
			
			if(_canDodge && !_startDodge)
			{
				_canDodge = false;
				dodgeFirstDirection = input;
				StartCoroutine(_TimeThreshold());
			}
			
			if(_canDodge && _startDodge)
			{
				if(Vector2.Dot(dodgeFirstDirection, input) > dodgeDotThreshold)
				{
					StartCoroutine(_Dodge(input));	
				}
			}
		}
		else
		{
			Vector3 moveVec = Vector3.Lerp(_lastMoveVec, Vector3.zero, slideFriction * Time.deltaTime);
			_lastMoveVec = moveVec;
			rigidbody.velocity = moveVec;
			
			_canDodge = true;
		}
	}
	
	private IEnumerator _Dodge(Vector2 input)
	{
		_dodging = true;
		_damageScript.isInvolnurable = true;
		_emitter.emit = true;
		
		Vector3 moveDir = Vector3.zero;
		moveDir.x = input.x * dodgeSpeed;
		moveDir.z = input.y * dodgeSpeed;
		rigidbody.velocity = moveDir;
		yield return new WaitForSeconds(dodgeDuration);
		
		_dodging = false;
		_damageScript.isInvolnurable = false;
		_emitter.emit = false;
	}
	
	private IEnumerator _TimeThreshold()
	{
		_startDodge = true;
		yield return new WaitForSeconds(dodgeTimeThreshold);
		_startDodge = false;
	}
	
	public void SetMovementEnabled(bool trigger)
	{
		_movementEnabled = trigger;
	}
}