using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
	public int verticalGridSize = 10;
	public int horizontalGridSize = 10;
	
	public float gridStepLength = 5f;
		
	private static RespawnManager _instance;
	
	public static RespawnManager instance
	{
		get{return _instance;}	
	}
	
	void Start()
	{
		_instance = this;	
	}
	
	public Vector3 GetSpawnPos()
	{
		return new Vector3(Random.Range(-horizontalGridSize,horizontalGridSize) * gridStepLength, 0, Random.Range(-verticalGridSize,verticalGridSize) * gridStepLength);
	}
}
