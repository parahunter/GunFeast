using UnityEngine;
using System.Collections;

public class BulletVelocity : MonoBehaviour {
	
	public float speed = 10;
	
	// Use this for initialization
	void Update () 
	{
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.velocity = transform.forward * speed;
	}
	
}
