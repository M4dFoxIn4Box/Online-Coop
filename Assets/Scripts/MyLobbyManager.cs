using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyLobbyManager : NetworkLobbyManager  {

	private int nbToWin = 0;

	public List<Player_Camera> playerList = new List<Player_Camera>();
	public GameObject[] winTriggers;

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
		if (trig == winTriggers[0])
		{
			NetworkServer.UnSpawn(winTriggers[0]);
			winTriggers[0].SetActive(false);
		}
		if (trig == winTriggers[1])
		{
			NetworkServer.UnSpawn(winTriggers[1]);
			winTriggers[1].SetActive(false);
		}
		if (nbToWin >= 2)
		{
			NetworkLobbyManager.singleton.ServerChangeScene("Luc_Test");
			/*playerList[0].RpcQuitGame();
			playerList[1].RpcQuitGame();*/
		}
		
		Debug.Log(nbToWin);
	}

	public void AddPlayer (Player_Camera playerScript){
		playerList.Add(playerScript);
		if (playerList.Count == 2)
		{
			winTriggers[0].SetActive(true);
			NetworkServer.Spawn(winTriggers[0]);
			winTriggers[1].SetActive(true);
			NetworkServer.Spawn(winTriggers[1]);
		}
	}

	public void QuitGame()
	{
		//Debug.Log("Cliennnnt");
		playerList[0].RpcQuitGame();
		playerList[1].RpcQuitGame();
	}
}