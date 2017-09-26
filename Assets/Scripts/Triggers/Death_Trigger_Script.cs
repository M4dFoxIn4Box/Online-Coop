using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Trigger_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			other.transform.GetComponent<Player_Manager>().Death() ;
			Debug.Log("Mort") ;
		}
	}
}
