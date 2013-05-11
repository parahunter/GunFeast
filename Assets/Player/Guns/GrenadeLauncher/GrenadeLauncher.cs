using UnityEngine;
using System.Collections;

public class GrenadeLauncher : Gun 
{
	public Transform bulletPrefab;
	
	private Transform _spawnPoint;
	
	public float timeBetweenShots = 3f;
	
	private bool canShoot = true;
	
	private bool grenadeFired = false;
	
	Transform bullet;
	// Use this for initialization
	void Start () 
	{
		_spawnPoint = transform.Find("spawnPoint");
	}
	
	#region implemented abstract members of Gun
	public override void Shoot (float triggerValue)
	{
		if(canShoot && !grenadeFired)
		{
			
			audio.PlayWithRandomPitch(0.8f, 1.2f);
			canShoot = false;
			bullet = (Transform)Instantiate(bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
			bullet.GetComponent<Grenade>().shootByPlayer = transform.root;
			
			transform.Find("spawnPoint/Sphere").renderer.enabled = false;
			
			grenadeFired = true;
		}
		else if(canShoot && grenadeFired)
		{
			Destroy(bullet.gameObject);
		}
	}
	#endregion
	
	public override void ResetGun ()
	{
		canShoot = true;
	}
}
