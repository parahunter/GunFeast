using UnityEngine;
using System.Collections;

public class DestroyWhenHittingPlayer : MonoBehaviour 
{

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Player")
			Destroy(gameObject);
	}
}
