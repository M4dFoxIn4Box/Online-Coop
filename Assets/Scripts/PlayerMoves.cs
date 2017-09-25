using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMoves : NetworkBehaviour {

	public GameObject playerCamera ;
	public GameObject playerBall ;

	public override void OnStartLocalPlayer ()
	{
		gameObject.tag = "Player" ;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public override void OnStartClient ()
	{
		if(!isLocalPlayer)
		{
			playerCamera.SetActive(false) ;
		}
	}
}
