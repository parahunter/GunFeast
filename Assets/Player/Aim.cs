using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour 
{
	
	private Vector3 _aimDirection = Vector3.zero;
	private Controls _controlScript;
	
	Transform _body;
	
	
	public float turnSpeed = 10f;
	
	private Vector3 lastDirection = Vector3.zero;
	
	// Use this for initialization
	void Start () 
	{
		_body = transform.Find("Body");
		_controlScript = GetComponent<Controls>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		_aimDirection = _controlScript.GetAimDirection3D();
		
		_aimDirection = Vector3.Slerp(lastDirection, _aimDirection, turnSpeed * Time.deltaTime);
		
		if(_aimDirection.magnitude > 0.1f)
			_body.forward = _aimDirection;
		
		lastDirection = _aimDirection;
	}
}
