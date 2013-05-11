using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {
	
	public Transform bloodSplatter;
	
	public float involBlinkTime = 0.1f;
	public int amountOfInvolBlinks = 5;
	public float stayDeadTime = 1f;
	
	private bool _isInvolnurable = false;
	public bool isInvolnurable
	{
		get{return _isInvolnurable;}	
	}
	
	private bool _rendererEnabled = true;
	public bool rendererEnabled
	{
		get{return _rendererEnabled;}
	}	
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Bullet" && !_isInvolnurable)
		{
			Die ();
		}
	}
	
	private void Die()
	{
		Instantiate(bloodSplatter, transform.position, Quaternion.identity);
		transform.position = new Vector3(9001,9001,9001);
		
		Invoke("Respawn", stayDeadTime);
	}
	
	public void Respawn()
	{	
		transform.position = RespawnManager.instance.GetSpawnPos();
		
		StartCoroutine( _RunInvolnurable() );
	}
		
	private IEnumerator _RunInvolnurable()
	{
		
		
		_isInvolnurable = true;
		for(int i = 0 ; i < amountOfInvolBlinks ; i++)
		{
			_rendererEnabled = !_rendererEnabled;	
			yield return new WaitForSeconds(involBlinkTime);
		}
		
		_rendererEnabled = true;
		_isInvolnurable = false;
	}
}
