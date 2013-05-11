using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	public Transform pistolGunPrefab;
	public Transform[] gunPrefabs;
	
	private Controls _controlScript;
	
	private Gun _currentGun;
	private Transform _currentGunTransform;
	private Transform _gunPivot;
	
	// Use this for initialization
	void Start () 
	{
		_controlScript = GetComponent<Controls>();
			
		_gunPivot = transform.Find("Body/gunPivot");
		
		MakeNewGun(pistolGunPrefab);
	}
		
	public void ResetToPistol()
	{
		MakeNewGun(pistolGunPrefab);
	}
	
	public void MakeNewGun(Transform newGunPrefab)
	{
		if(_currentGunTransform != null)
			Destroy(_currentGunTransform.gameObject);
		
		Transform newGun = (Transform)Instantiate(newGunPrefab, _gunPivot.position, _gunPivot.rotation);
		_currentGunTransform = newGun;
		newGun.parent = _gunPivot;
		_currentGun = newGun.GetComponent<Gun>();
	}
	
	public void PickupNewWeapon()
	{
		MakeNewGun(gunPrefabs[Random.Range(0, gunPrefabs.Length)]);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float triggerVal = _controlScript.GetShoot();
		
		if(triggerVal > 0)
			//print ("boom");
			
			_currentGun.Shoot(triggerVal);
		else
			//print ("reset");
			_currentGun.ResetGun();
	}
}
