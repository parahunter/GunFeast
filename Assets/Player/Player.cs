using UnityEngine;
using System.Collections;

public class Player
{
	public int playerId;
	public Transform transform;
	public TakeDamage damageScript;

	public Player(int playerId, Transform transform, TakeDamage damageScript)
	{
		this.playerId = playerId;
		this.transform = transform;
		this.damageScript = damageScript;
	}
}
