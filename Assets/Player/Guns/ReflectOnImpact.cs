using UnityEngine;
using System.Collections;

public class ReflectOnImpact : MonoBehaviour 
{
	
	private Vector3 lastCollisionPos = new Vector3(1000, 1000, 1000);
	
	private const float threshold = 0.5f;	
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Wall")
		{
			if((lastCollisionPos - transform.position).magnitude < threshold)
				return;
			
			lastCollisionPos = transform.position;
			
			Vector3 normal = collision.contacts[0].normal;
			
			transform.forward = Vector3.Reflect(transform.forward, normal);
			Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.red, 2);
		
		}
	}
}
