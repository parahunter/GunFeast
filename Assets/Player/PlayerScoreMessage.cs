using UnityEngine;
using System.Collections;

public class PlayerScoreMessage : MonoBehaviour 
{
	public PlayerScore[] scores;
	
	public static void CreateMessage(PlayerScore[] scores)
	{
		GameObject gameObj = new GameObject("scoreMessage");
		DontDestroyOnLoad(gameObj);
		gameObj.AddComponent(typeof(PlayerScoreMessage));
		gameObj.GetComponent<PlayerScoreMessage>().scores = scores;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
