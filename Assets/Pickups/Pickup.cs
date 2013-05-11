using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour 
{
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<Shoot>().PickupNewWeapon();
			
			Destroy(gameObject);
		}	
	}
}
