using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour 
{
	public Transform grenadeFragmentPrefab;
	
	public int minAmount = 30;
	public int maxAmount = 40;
	
	public Transform shootByPlayer;
		
	public void OnDestroy()
	{
		int amount = Random.Range(minAmount, maxAmount);
		for(int i = 0 ; i < amount ; i++)
		{
			Quaternion rot = Quaternion.Euler(0, Random.Range(0,360f), 0);
			
			Instantiate(grenadeFragmentPrefab, transform.position, rot);
		}
		
		shootByPlayer.GetComponent<Shoot>().ResetToPistol();
	}
	
}
