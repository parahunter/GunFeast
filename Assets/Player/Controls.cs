using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour 
{
	private bool _mouseEnabled = false;
	
	public bool GetJumpButtonDown()
	{
		return Input.GetKey(KeyCode.Space) || XBoxInput.GetButtonA(this.GetPlayerIndex());// || OuyaInputHandler.instance.GetBottonOPressed(this.GetPlayerIndex() - 1);
	}
		
	public bool GetAttackButtonDown()
	{
		return Input.GetMouseButtonDown(0) || XBoxInput.GetButtonBDown(this.GetPlayerIndex());
	}
	
	public bool GetCrouchButton()
	{
		return XBoxInput.GetButtonL(this.GetPlayerIndex()) 
				|| Input.GetKey(KeyCode.LeftShift)
				|| Input.GetMouseButton(1);
	}
	
	private Vector2 _mouseDirection = Vector2.zero;
	
	public Vector2 GetMoveDirection2D()
	{
		Vector2 result;
		
		result = /* OuyaInputHandler.instance.GetAnalogInput(this.GetPlayerIndex() - 1)  + */ XBoxInput.GetLeftAnalogInput(this.GetPlayerIndex());
		
		_mouseDirection = (Vector2)Input.mousePosition - (new Vector2(Screen.width, Screen.height) * 0.5f);
		
		if(Input.GetMouseButton(0))
			_mouseEnabled = true;
		if(XBoxInput.GetButtonA(this.GetPlayerIndex()))
			_mouseEnabled = false;
		
		if(_mouseEnabled)
			result += _mouseDirection.normalized * Input.GetAxis("Fire1");
		
		result = Vector2.ClampMagnitude(result, 1.0f);
		
		return result;
	}
	
	public Vector3 GetMoveDirection3D()
	{
		Vector2 result = GetMoveDirection2D();
		return new Vector3(result.x, 0, result.y);
	}
	
	public Vector2 GetAimDirection2D()
	{
		Vector2 result;
		
		result = /* OuyaInputHandler.instance.GetAnalogInput(this.GetPlayerIndex() - 1)  + */ XBoxInput.GetRightAnalogInput(this.GetPlayerIndex());
			
		return result;
		
	}
	
	public Vector3 GetAimDirection3D()
	{
		Vector2 result = GetAimDirection2D();
		return new Vector3(result.x, 0, result.y);
	}
	
	public float GetShoot()
	{
		return XBoxInput.GetRightTrigger(this.GetPlayerIndex());	
	}
	
	/*
	public Vector2 GetCameraDirection()
	{
		
	}*/
}
