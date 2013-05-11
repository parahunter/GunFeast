using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour 
{
	
	private Vector3 _aimDirection = Vector3.zero;
	private Controls _controlScript;
	
	
	Transform _body;
	
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
		
		_body.forward = _aimDirection;
	}
}
