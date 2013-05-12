using UnityEngine;
using System.Collections;

public class Player
{
	public int playerId;
	public Transform transform;

	public Player(int playerId, Transform transform)
	{
		this.playerId = playerId;
		this.transform = transform;
	}
}
