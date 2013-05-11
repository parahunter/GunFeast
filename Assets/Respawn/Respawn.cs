using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
	public int gridSize = 10;
	public float gridStepLength = 5f;
		
	private static Respawn _instance;
	
	public static Respawn instance
	{
		get{return _instance;}	
	}
	
	void Start()
	{
		_instance = this;	
	}
	
	public Vector3 GetSpawnPos()
	{
		return new Vector3(Random.Range(-gridSize,gridSize) * gridStepLength, 0, Random.Range(-gridSize,gridSize) * gridStepLength);
	}
}
