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
		set
		{
			_isInvolnurable = value;
			if(value == true)
				gameObject.layer = LayerMask.NameToLayer( "Involnurable" );	
			else
				gameObject.layer = LayerMask.NameToLayer( "Default" );	
			
		}
	}
	
	private bool _dead = false;
	public bool dead
	{
		get{return _dead;}	
	}
	
	private bool _rendererEnabled = true;
	public bool rendererEnabled
	{
		get{return _rendererEnabled;}
	}	
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Bullet" && !isInvolnurable)
		{
			Die ();
		}
	}
	
	private Shoot _shootScript;
	
	public void Start()
	{
		_shootScript = GetComponent<Shoot>();	
	}
	
	private void Die()
	{
		_dead = true;
		Instantiate(bloodSplatter, transform.position, Quaternion.identity);
		transform.position = new Vector3(9001,9001,9001);
		
		_shootScript.ResetToPistol();
		
	}
	
	public void Respawn()
	{	
		_dead = false;
		transform.position = RespawnManager.instance.GetSpawnPos();
		
		StartCoroutine( _RunInvolnurable() );
	}
		
	private IEnumerator _RunInvolnurable()
	{
		isInvolnurable = true;
		for(int i = 0 ; i < amountOfInvolBlinks ; i++)
		{
			_rendererEnabled = !_rendererEnabled;	
			yield return new WaitForSeconds(involBlinkTime);
		}
		
		_rendererEnabled = true;
		isInvolnurable = false;
	}
}
