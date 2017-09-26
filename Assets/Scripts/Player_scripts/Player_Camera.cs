using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Camera : NetworkBehaviour {

	public override void OnStartLocalPlayer ()
	{
		gameObject.tag = "Player" ;
		CmdRegisterMe();			
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	[Command]
	void CmdRegisterMe (){
		Game_Manager.Instance().AddPlayer(this);
	}

	[ClientRpc]
	public void RpcQuitGame (){
		NetworkLobbyManager.singleton.StopClient();
	}
}
