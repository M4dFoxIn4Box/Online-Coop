using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Vehicles.Ball;

public class Player_Camera : NetworkBehaviour {

	public BallUserControl myPlayerControls;

	void Awake()
	{
		DontDestroyOnLoad(gameObject) ;
		
	}
	
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
		if (isServer)
		{
			NetworkLobbyManager.singleton.StopMatchMaker();
		}
		NetworkLobbyManager.singleton.StopClient();
	}

	[Command]
	void CmdFinished (GameObject winT)
	{
		Game_Manager.Instance().AddNb(winT);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("WinTrigger") && isLocalPlayer){
			myPlayerControls.LockPlayer();
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			CmdFinished(other.gameObject);
		}
	}
}
