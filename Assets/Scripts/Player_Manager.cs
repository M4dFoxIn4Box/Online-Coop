﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking ;

public class Player_Manager : NetworkBehaviour  {

	[SyncVar]
	private Vector3 currentCheckpointPosition;
	public GameObject TutoMoves;
	public GameObject TutoJump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckPointTake(Vector3 checkpointPosition)
	{
		currentCheckpointPosition = checkpointPosition ;
	}

	[ClientRpc]
	public void RpcDeath()
	{	
		transform.position = currentCheckpointPosition ;
	}

	[Command]
	public void CmdRespawn()
	{
		RpcDeath() ;
	}

}
