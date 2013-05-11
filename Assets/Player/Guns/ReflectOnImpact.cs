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
			
			RaycastHit hit;
			Vector3 normal;
			if(Physics.Raycast(transform.position, transform.forward, out hit,10f))
			{
				normal = hit.normal;
			
				Debug.DrawLine(transform.position, transform.position + normal * 10, Color.blue, 2);
				
				
				transform.forward = Vector3.Reflect(transform.forward, normal);
				Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.red, 2);
				
			}
			
		}
	}
}
