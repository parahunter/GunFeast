using UnityEngine;
using System.Collections;

public class DestroyWhenHitByBullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Bullet")
		{
			Destroy(gameObject);
		}
	}
}
