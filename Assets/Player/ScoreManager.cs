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
	
	
	// Use this for initialization
	void Awake () 
	{
		if(instance == null)
		{
			instance = this;
			
			PlayerScoreMessage message = (PlayerScoreMessage)FindObjectOfType(typeof(PlayerScoreMessage));
			
			if(message != null)
			{
				for(int i = 0; i < message.scores.Length ; i++)
				{
					int index = message.scores[i].index;
					PlayerManager.instance.AddPlayerWithIndex(index);
					playerScores[i].SetScore(message.scores[i].GetScore());
				}
				
				Destroy(message.gameObject);
			}
		}
		else
			Destroy(gameObject);
	}
	
	
	private bool loading = false;
	void Update()
	{
		int index = PlayerManager.instance.GetIndexOfLastPlayer();
		
		if(index != -1 && !loading)
		{
			loading = true;
			
			IncrementPlayerScore(index);
			
			PlayerScoreMessage.CreateMessage(playerScores.ToArray());
			
			Invoke("DelayThenReloadLevel", 0.3f);
		}
	}
	
	private void DelayThenReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public int GetPlayerScore(int index)
	{
		return playerScores[index].GetScore();
	}
	
	public void SetPlayerScore(int index, int score)
	{
		playerScores[index].SetScore(score);
	}
	
	public void IncrementPlayerScore(int index)
	{
		for(int i = 0 ; i < playerScores.Count ; i++)
		{
			if(playerScores[i].index == index)
				playerScores[i].IncrementScore();
		}
	}
	
	public void AddPlayerScore(int index)
	{
		playerScores.Add(new PlayerScore(index));
	}
	
}
