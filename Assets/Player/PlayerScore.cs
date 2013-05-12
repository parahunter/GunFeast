using UnityEngine;
using System.Collections;

public class PlayerScore{
	
	public int playerScore;
	public int pointStreak;
	public int index;
	
	
	public PlayerScore(int index)
	{
		this.index = index;
	}
	
	public void IncrementScore()
	{
		playerScore ++;
	}
	
	public void SetScore(int amount)
	{
		playerScore = amount;
	}
	
	public int GetScore()
	{
		return playerScore;
	}
	

}
