using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance
	{
		get;
		private set;
	}
	
	public List<PlayerScore> playerScores = new List<PlayerScore>();
	
	public AnimationCurve multiplierCurve;
	
	// Use this for initialization
	void Start () 
	{
		if(instance == null)
		{
			instance = this;
		}
		else
			Destroy(gameObject);
	}
	
	public int GetPlayerScore(int index)
	{
		return playerScores[index].GetScore();
	}
	
	public void IncrementMultiplier(int index, int amount)
	{
		playerScores[index].IncrementMultiplier(amount);
	}
	
	public int GetPlayerMultiplier(int index)
	{
		return playerScores[index].GetMultiplier();
	}
	
	public void SetPlayerScore(int index, int score)
	{
		playerScores[index].SetScore(score);
	}
	
	public void IncrementPlayerScore(int index)
	{
		playerScores[index].IncrementScore();
	}
	
	public void ResetPlayerMultiplier(int index)
	{
		playerScores[index].ResetMultiplier();
	}
	
	public void AddPlayerScore()
	{
		playerScores.Add(new PlayerScore(multiplierCurve));
	}
	
}
