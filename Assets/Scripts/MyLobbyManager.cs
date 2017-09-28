using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MyLobbyManager : NetworkLobbyManager  {

	private int nbToWin = 0;

	public List<Player_Camera> playerList = new List<Player_Camera>();
	public List<Transform> startPositions = new List <Transform>();
	// public GameObject[] winTriggers;

	private static MyLobbyManager instance;
    public static MyLobbyManager Instance () 
    {
        return instance;
    }

    void Awake (){
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else 
        {
            instance = this;
        }
    }
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddNb (GameObject trig){
		nbToWin += 1;
		Debug.Log(nbToWin);
		if (nbToWin >= 2)
		{
			NetworkLobbyManager.singleton.ServerChangeScene("Scene_Online2");
		}
		
		Debug.Log(nbToWin);
	}

	public void AddPlayer (Player_Camera playerScript){
		playerList.Add(playerScript);
	}

	public void QuitGame()
	{
		playerList[0].RpcQuitGame();
		playerList[1].RpcQuitGame();
	}

	public void OnServerChangeScene(){
		playerList[0].RpcGoTo(startPositions[0].gameObject);
		playerList[1].RpcGoTo(startPositions[1].gameObject);
	}
}