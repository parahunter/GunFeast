using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour 
{
	
	public Texture2D titleScreen;
	
	
	private Rect screenRect;
	// Use this for initialization
	void Start () {
		screenRect = new Rect(0, 0, Screen.width, Screen.height);
	}
	
	void OnGUI()
	{
		if(PlayerManager.instance.numberOfPlayers == 0)
			GUI.DrawTexture(screenRect, titleScreen, ScaleMode.ScaleToFit);
	}
}
