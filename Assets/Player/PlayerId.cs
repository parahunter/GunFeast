using UnityEngine;
using System.Collections;

public class PlayerId : MonoBehaviour 
{
	
	public enum PlayerIndex {one = 1, two = 2, three = 3, four = 4};
	public PlayerIndex playerIndex;
	
	public Color color
	{
		get;set;	
	}
	
	public void SetPlayerId(int id)
	{
		playerIndex = (PlayerIndex)id;
	}
}
