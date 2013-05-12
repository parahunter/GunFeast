using UnityEngine;
using System.Collections;

public class PlayerScore{
	
	public int playerScore;
	public int pointStreak;
	
	private int _multiplier = 1;
	
	
	private int _multiplierBaseline = 0;
	public AnimationCurve _multiplierCurve;
	
	public PlayerScore(AnimationCurve curve)
	{
		_multiplierCurve = curve;
	}
		
	public void IncrementMultiplier(int amount)
	{
		_multiplierBaseline += amount;
		UpdateMultiplier();
	}
	
	public void IncrementScore()
	{
		playerScore += _multiplier;
		pointStreak++;
		
		UpdateMultiplier();
	}
	
	public void SetScore(int amount)
	{
		playerScore = amount;
	}
	
	public int GetScore()
	{
		return playerScore;
	}
	
	public int GetMultiplier()
	{
		return _multiplier;
	}
	
	public void ResetMultiplier()
	{
		pointStreak = 0;
		_multiplierBaseline = 0;
		UpdateMultiplier();
	}
	
	public void UpdateMultiplier()
	{
		_multiplier = _multiplierBaseline + Mathf.FloorToInt(_multiplierCurve.Evaluate(pointStreak));
	}
}
