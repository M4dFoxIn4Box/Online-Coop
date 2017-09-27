using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking ;

public class Game_Manager : NetworkBehaviour {

	private int nbToWin = 0;

	public List<Player_Camera> playerList = new List<Player_Camera>();
	public GameObject[] winTriggers;



	private static Game_Manager instance;
	public static Game_Manager Instance () 
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

	[Command]
	public void CmdAddNb (GameObject trig){
		nbToWin += 1;
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
			playerList[0].RpcQuitGame();
			playerList[1].RpcQuitGame();
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

	[Command]
	public void CmdQuitGame()
	{
		Debug.Log("Cliennnnt");
		playerList[0].RpcQuitGame();
		playerList[1].RpcQuitGame();
	}

	[Command]
	public void CmdActivatePlateform (GameObject plateformActive){
		plateformActive.SetActive(true);
		NetworkServer.Spawn(plateformActive);
	}

	[Command]
	public void CmdStopPlateform (GameObject plateformActive){
		plateformActive.SetActive(false);
		NetworkServer.UnSpawn(plateformActive);
	}
}
