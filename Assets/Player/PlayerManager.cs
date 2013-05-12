using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour 
{
	public Transform playerPrefab;

	public Color[] playerColors;
	
	public int numberOfPlayers = 1;
	public List<Player> players = new List<Player>();
	
	public static PlayerManager instance
	{
		get{return _instance;}	
	}
	private static PlayerManager _instance;
	
	public LayerMask[] playerLayerMask;
	
	public float cameraWideFOWRatio = 50f;
	
	private bool[] _connectedPlayers = new bool[4];
	
	public bool debugging = false;
	
	Texture[] faces;
	
	void Awake()
	{	
		if(_instance == null)
		{
			for(int i = 0; i < _connectedPlayers.Length; i++)
				_connectedPlayers[i] = false;
			
			_instance = this;
			
			for(int i = 0 ; i < numberOfPlayers; i++)
			{
				_connectedPlayers[i] = true;
				AddPlayer(i);	
				ScoreManager.instance.AddPlayerScore(i);
			}
			
		}
		else
			Destroy(gameObject);
	}
	
	
	
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < 4 ; i++)
		{
			if(!_connectedPlayers[i] /*&& (OuyaInputHandler.instance.GetBottonADown(i) || */ && XBoxInput.GetButtonADown(i + 1))
			{
				numberOfPlayers++;
				_connectedPlayers[i] = true;
				AddPlayer(i);
				ScoreManager.instance.AddPlayerScore(i);
			}
		}
	}
	
	public void AddPlayerWithIndex(int i)
	{
		numberOfPlayers++;
		_connectedPlayers[i] = true;
		AddPlayer(i);
		ScoreManager.instance.AddPlayerScore(i);	
	}
	
	public int GetIndexOfLastPlayer()
	{
		int index = -1;
		
		int counter = 0;
		for(int i = 0 ; i < players.Count ; i++)
		{
			if(!players[i].damageScript.dead)
			{
				counter++;
				index = i;
			}
		}
		
		if(counter == 1 && players.Count >= 2)
			return players[index].playerId;
		else
			return -1;
	}
	
	public void AddPlayer(int id)
	{
		
		Transform newPlayer = (Transform)Instantiate(playerPrefab, RespawnManager.instance.GetSpawnPos(), Quaternion.identity);
		
		newPlayer.GetComponent<PlayerId>().SetPlayerId(id + 1);
		newPlayer.GetComponent<PlayerId>().color = playerColors[id];
		
		TakeDamage damageScript = newPlayer.GetComponent<TakeDamage>();
		
		players.Add(new Player(id, newPlayer, damageScript));
	}
	
	
}
