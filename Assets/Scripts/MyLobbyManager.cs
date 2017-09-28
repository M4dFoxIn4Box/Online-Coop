﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MyLobbyManager : NetworkLobbyManager  {

	private int nbToWin = 0;

	public List<Player_Camera> playerList = new List<Player_Camera>();

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

	public void SendHelpRequest(GameObject playerGo)
	{
		if(playerGo == playerList[0].gameObject)
		{
			playerList[1].RpcIconToHelp() ;
		}
		else if(playerGo == playerList[1].gameObject)
		{
			playerList[0].RpcIconToHelp() ;
		}
	}

	public void AddNb (){
		nbToWin += 1;
		Debug.Log(nbToWin);
		if (nbToWin >= 2)
		{
			NetworkLobbyManager.singleton.ServerChangeScene("Scene_Online3");
		}
	}

	public void AddPlayer (Player_Camera playerScript){
		playerList.Add(playerScript);
	}

	public void QuitGame()
	{
		playerList[0].RpcQuitGame();
		playerList[1].RpcQuitGame();
	}

	public override void OnLobbyServerSceneChanged (string scName){
		
		if (scName != "Scene_Online")
		{
			if (playerList.Count > 0)
			{
				StartCoroutine("Test");
				nbToWin = 0;
			}
		}
	}

	public IEnumerator Test ()
	{
		yield return new WaitForSeconds (0.8f);
		playerList[0].RpcGoTo(startPositions[0].gameObject);
		playerList[1].RpcGoTo(startPositions[1].gameObject);
	}
}