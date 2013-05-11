using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour 
{

	public abstract void Shoot(float triggerValue);
	
	public abstract void Reset();
}
