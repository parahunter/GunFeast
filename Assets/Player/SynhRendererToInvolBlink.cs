using UnityEngine;
using System.Collections;

public class SynhRendererToInvolBlink : MonoBehaviour {
	
	private TakeDamage _damageScript;
	
	// Use this for initialization
	void Start () {
		_damageScript = transform.root.GetComponent<TakeDamage>();
	}
	
	// Update is called once per frame
	void Update () {
		renderer.enabled = _damageScript.rendererEnabled;
	}
}
