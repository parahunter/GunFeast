using UnityEngine;
using System.Collections;

public class Pistol : Gun 
{
	public Transform bulletPrefab;
	
	private Transform _spawnPoint;
	
	public float timeBetweenShots = 3f;
	
	private bool canShoot = true;
	
	// Use this for initialization
	void Start () 
	{
		_spawnPoint = transform.Find("spawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region implemented abstract members of Gun
	public override void Shoot (float triggerValue)
	{
		if(canShoot)
		{
			canShoot = false;
			Transform bullet = (Transform)Instantiate(bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
		}
		
	}
	#endregion
	


	#region implemented abstract members of Gun
	public override void Reset ()
	{
		canShoot = true;
	}
	#endregion
}
