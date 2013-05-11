using UnityEngine;
using System.Collections;

public class SpeedController : MonoBehaviour 
{
	public float speed = 1.0f;
	
	private static SpeedController _instance;
	
	void Start()
	{
		if(_instance == null)
		{
			_instance = this;	
		}
		else
			Destroy(gameObject);
	}
	
	public static float Speed
	{
		get
		{
			if(_instance != null)
				return _instance.speed;
			else
				return 1.0f;
		}
		set
		{
			if(_instance == null)
				return;
			else
				_instance.speed = value;
		}
		
	}
}
