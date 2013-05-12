using UnityEngine;
using System.Collections;

public class WallSegmentDurability : MonoBehaviour 
{
	public int durability = 5;
	
	public Color healthyCol = Color.white;
	public Color brokenCol = Color.black;
	
	private int maxDurability;
	// Use this for initialization
	void Start () {
		maxDurability = durability;
		renderer.material.color = healthyCol;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Bullet")
		{
			durability--;
			
			float t = (float)durability / maxDurability;
			renderer.material.color = Color.Lerp(brokenCol, healthyCol, t);
			
			if(durability <= 0)
				Destroy(gameObject);
		}
	}
}
