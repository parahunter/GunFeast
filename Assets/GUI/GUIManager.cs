using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour 
{
	
	public Texture2D titleScreen;
	
	public Rect[] scoreRects;
	
	public GUIStyle style;
	
	private Rect screenRect;
	// Use this for initialization
	void Start () 
	{
		screenRect = new Rect(0, 0, Screen.width, Screen.height);
		
		
	}
	
	void OnGUI()
	{
		if(PlayerManager.instance.numberOfPlayers == 0)
			GUI.DrawTexture(screenRect, titleScreen, ScaleMode.ScaleToFit);
		
		if(ScoreManager.instance.playerScores.Count >= 1)
		{
			scoreRects = new Rect[ScoreManager.instance.playerScores.Count];
			
			float rectWidth = Screen.width / scoreRects.Length;
			for(int i = 0 ; i < scoreRects.Length ; i++)
			{
				scoreRects[i] = new Rect(rectWidth * i, 0, rectWidth, 100);	
			}
			
			for(int i = 0 ; i < ScoreManager.instance.playerScores.Count ; i++)
			{
				GUI.color = PlayerManager.instance.playerColors[ScoreManager.instance.playerScores[i].index];
				GUI.Label(scoreRects[i], "" + ScoreManager.instance.playerScores[i].GetScore(), style);
			}
		}
	}
}
