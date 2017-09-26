using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking ;

public class Player_Manager : NetworkBehaviour  {

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

	[Command]
	public void CmdDeath()
	{	
		transform.position = new Vector3(0,0,0) ;
	}

}
