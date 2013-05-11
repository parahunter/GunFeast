using UnityEngine;
using System.Collections;

public class MachineGun : Gun 
{
	public Transform bulletPrefab;
	public int ammo = 50;
	
	public float audioStartTime = 1f;
	public float audioLoopTime = 1.4f;
	
	public AnimationCurve triggerValueToSpawnTime;
	
	private Transform _spawnPoint;
	
	public float timeBetweenShots = 3f;
	
	// Use this for initialization
	void Start () 
	{
		_spawnPoint = transform.Find("spawnPoint");
	}
	
	
	private bool isShooting = false;
	private float triggerVal;
	#region implemented abstract members of Gun
	public override void Shoot (float triggerValue)
	{
		if(!isShooting)
			StartCoroutine(SpawnBullets());
		
		
		triggerVal = triggerValue;
	}
	
	public override void ResetGun ()
	{
		//StopAllCoroutines();
		isShooting = false;
	}
	#endregion
	
	private IEnumerator SpawnBullets()
	{
		isShooting = true;
		
		while(isShooting == true)
		{
			if(ammo < 0)
			{	
				transform.root.GetComponent<Shoot>().ResetToPistol();
				break;
			}
				
			ammo--;
			
			Transform bullet = (Transform)Instantiate(bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
			audio.pitch = 1 + triggerVal * 0.5f ;
			audio.Play();
			audio.time = audioStartTime;
		
			
			yield return new WaitForSeconds(triggerValueToSpawnTime.Evaluate(triggerVal));
		
		}

	}
}
