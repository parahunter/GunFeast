using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	
	
	public Gun currentGun;
	
	private Controls _controlScript;
	
	// Use this for initialization
	void Start () 
	{
		_controlScript = GetComponent<Controls>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float triggerVal = _controlScript.GetShoot();
		 
		if(triggerVal > 0)
			currentGun.Shoot(triggerVal);
		else
			currentGun.Reset();
	}
}
