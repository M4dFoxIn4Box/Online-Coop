using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking ;

public class Game_Manager : NetworkBehaviour {

	[SyncVar(hook = "ReturnToLobby")]
	public int nbToWin = 0;

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
	void Update () 
	{
		//RpcReturnToLobby();
	}

	public void AddNb ()
	{
		nbToWin ++;
		Debug.Log(nbToWin);
	}

	void ReturnToLobby (int number)
	{
		if (number >= 2)
		{
			Network.Disconnect();
		}
		
	}
}
