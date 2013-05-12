using UnityEngine;
using System.Collections;

public class PlayerId : MonoBehaviour 
{
	
	public enum PlayerIndex {one = 1, two = 2, three = 3, four = 4};
	public PlayerIndex playerIndex;
	
	private Color _color;
	public Color color
	{
		get{return _color;}
		set
		{
			_color = value;
			transform.Find("Body/Plane").renderer.material.color = _color;
		}
			
	}
	
	public void SetPlayerId(int id)
	{
		playerIndex = (PlayerIndex)id;
	}
}
