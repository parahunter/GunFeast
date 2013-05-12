using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	
	private static MusicController _instance;
	
	
	// Use this for initialization
	void Start () 
	{
		if(_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}	
		else
			Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
