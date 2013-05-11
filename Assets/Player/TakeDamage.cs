using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {
	
	public Transform bloodSplatter;
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Bullet")
		{
			Die ();
		}
	}
	
	private void Die()
	{
		Instantiate(bloodSplatter, transform.position, Quaternion.identity);
		transform.position = Respawn.instance.GetSpawnPos();
			
	}
}
