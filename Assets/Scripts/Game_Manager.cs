using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking ;

public class Game_Manager : NetworkBehaviour {

	[SyncVar]
	public int nbToWin;
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
	public void CmdAddNb (){
		nbToWin += 1;
	}
	[ClientRpc]
	void RpcReturnToLobby (){
		if (nbToWin >= 2){
			Network.Disconnect();
		}
		
	}
}
