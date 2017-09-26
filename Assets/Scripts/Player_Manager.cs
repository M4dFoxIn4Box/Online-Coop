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

	[ClientRpc]
	public void RpcDeath()
	{	
		if(!isServer)
		{
			return ;
		}
		
		if(isLocalPlayer)
		{
			transform.position = new Vector3(0,0,0) ;
		}
	}
	/*void OnTriggerEnter (Collider other)
	{

		if (other.CompareTag("Checkpoint"))
		{
			currentCheckpointPosition = other.transform.position;
			Debug.Log("Checkpoint");
			other.gameObject.SetActive(false) ;

		}
		
		if (other.CompareTag("DeathTrigger"))
		{
			transform.position = currentCheckpointPosition;
			Debug.Log("Mort");
			GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
			
		}
		if (other.CompareTag("WinTrigger"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			Debug.Log("Win");
		}
		if (other.CompareTag("TutoMoves"))
		{
			TutoMoves.SetActive(true);
		}
		if (other.CompareTag("TutoJump"))
		{
			TutoJump.SetActive(true);
		}

	}
	void OnTriggerExit (Collider other)
	{
		if (other.CompareTag("TutoMoves"))
		{
			TutoMoves.SetActive(false);
		}
		if (other.CompareTag("TutoJump"))
		{
			TutoJump.SetActive(false);
		}
	}*/


}
