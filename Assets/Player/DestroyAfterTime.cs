using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour 
{
	
	public float duration = 3f;
	
	// Use this for initialization
	void Start () {
		Invoke("DestroyGameObject", duration);
	}
	
	// Update is called once per frame
	void DestroyGameObject () {
		Destroy(gameObject);
	}
}
