﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking ;

public class Game_Manager : NetworkBehaviour  {

	public GameObject tutoMove;
	public GameObject tutoJump;
	private bool moveBool = false;
	private bool jumpBool = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TutoMove (){

		moveBool = !moveBool;
	}
	public void TutoJump (){

		jumpBool = !jumpBool;
	}
	void TutoMoveDisp (){

		tutoMove.SetActive(moveBool);
	}
	void TutoJumpDisp (){

		tutoJump.SetActive(jumpBool);
	}
}
