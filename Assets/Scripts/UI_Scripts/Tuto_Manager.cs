using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Manager : MonoBehaviour  {

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
