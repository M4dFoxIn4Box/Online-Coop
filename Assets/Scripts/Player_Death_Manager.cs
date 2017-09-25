using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death_Manager : MonoBehaviour {

	private Vector3 currentCheckpointPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
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
			SceneManager.LoadScene("Killian_Test_2", LoadSceneMode.Single);
			Debug.Log("Win");
		}

	}


}
