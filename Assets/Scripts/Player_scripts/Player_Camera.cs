using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Vehicles.Ball;

public class Player_Camera : NetworkBehaviour {

	private bool canAskHelp = false ;
	private int touchIndex ;


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
		if(canAskHelp)
		{
			if(touchIndex == 0 && Input.GetButtonDown("X_Button") ) // X button
			{
				Menu_Pause.Instance().HideActiveKey() ;
				Debug.Log("Right") ;
			}

			if(touchIndex == 1 && Input.GetButtonDown("B_Button")) // B button
			{
				Menu_Pause.Instance().HideActiveKey() ;
				Debug.Log("Right") ;
			}

			if(touchIndex == 2 && Input.GetButtonDown("Y_Button")) // Y button
			{
				Menu_Pause.Instance().HideActiveKey() ;
				Debug.Log("Right") ;
			}
		}
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

	public void ToggleHelp()
	{
		canAskHelp = true ;
	}

	public void DisableHelp()
	{
		canAskHelp = false ;
	}

	public bool ReturnCanAskHelp()
	{
		return canAskHelp ;
	}

	public void ChangeTouchIndex(int idx)
	{
		touchIndex = idx ;
	}

	[ClientRpc]
	public void RpcGoTo(GameObject pos){
		if (isLocalPlayer){
			transform.position = pos.transform.position;
			GetComponent<Rigidbody>().isKinematic = false;
			myPlayerControls.UnlockPlayer();
		}
	}

	[Command]
	public void CmdAskForHelp(GameObject ply)
	{	
		MyLobbyManager.Instance().SendHelpRequest(ply) ;
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
