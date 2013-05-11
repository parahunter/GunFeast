using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Bullet")
		{
			transform.position = Respawn.instance.GetSpawnPos();
		}
	}
}
