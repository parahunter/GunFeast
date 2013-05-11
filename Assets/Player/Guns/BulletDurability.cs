using UnityEngine;
using System.Collections;

public class BulletDurability : MonoBehaviour {
	
	public int durability = 3;
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Wall")
		{
			durability--;
			
			if(durability < 0)
				Destroy(gameObject);
		}
	}
}
