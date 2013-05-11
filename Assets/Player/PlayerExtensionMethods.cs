using UnityEngine;
using System.Collections;

public static class PlayerExtensionMethods
{
	public static int GetPlayerIndex(this MonoBehaviour behaviour) 
	{
       	int? id =  (int)behaviour.GetComponent<PlayerId>().playerIndex;
    	if(id != null)
			return (int)id;
		else
		{
			Debug.LogError("GetPlayerIndex called on a game object that does not have a PlayerId component attached!");
			return -1;
		}
    }
	
	public static int GetPlayerIndex(this Transform transform) 
	{
       	int? id =  (int)transform.GetComponent<PlayerId>().playerIndex;
    	if(id != null)
			return (int)id;
		else
		{
			Debug.LogError("GetPlayerIndex called on a game object that does not have a PlayerId component attached!");
			return -1;
		}
    }
}
