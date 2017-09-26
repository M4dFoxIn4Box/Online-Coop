using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Settings : NetworkBehaviour {

	public GameObject playerCamera ;
	public GameObject playerBall ;

	public override void OnStartLocalPlayer ()
	{
		playerBall.tag = "Player" ;
		playerCamera.SetActive(true) ;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
