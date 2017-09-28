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
		MyLobbyManager.Instance().AddPlayer(this);
	}

	[ClientRpc]
	public void RpcQuitGame (){
		if (isServer)
		{
			MyLobbyManager.singleton.StopMatchMaker();
		}
		MyLobbyManager.singleton.StopClient();
	}

	[Command]
	void CmdFinished ()
	{
		MyLobbyManager.Instance().AddNb();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("WinTrigger") && isLocalPlayer){
			myPlayerControls.LockPlayer();
			GetComponent<Rigidbody>().isKinematic = true;
			CmdFinished();
		}
	}

	[ClientRpc]
	public void RpcGoTo(GameObject pos){
		if (isServer)
		{
			MyLobbyManager.singleton.StopMatchMaker();
		}
		MyLobbyManager.singleton.StopClient();
		// Debug.Log (pos.name);
		// if (isLocalPlayer){
		// 	transform.position = pos.transform.position;
		// }
	}

	[Command]
	public void CmdAskForHelp(GameObject ply)
	{	
		//MyLobbyManager.Instance().SendHelpRequest(ply) ;
	}

	[ClientRpc]
	public void RpcIconToHelp()
	{
		if(isLocalPlayer)
		{
			Menu_Pause.Instance().DisplayIconToHelp() ;
		}
	}
}
