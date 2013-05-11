using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour 
{
	public AnimationCurve spawnTimes;
	
	public Transform pickup;
	
	private int count = 0;		
	
	void Start () {
		StartCoroutine(_SpawnPickup());
	}
	
	private IEnumerator _SpawnPickup()
	{
		while(true)
		{
			yield return new WaitForSeconds(spawnTimes.Evaluate((float)count));
			
			Instantiate(pickup, RespawnManager.instance.GetSpawnPos(), Quaternion.identity);
			
			count++;
		}
		
	}
}
