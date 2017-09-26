using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Move_Trigger : MonoBehaviour {

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
			other.transform.GetComponent<Game_Manager>().TutoMove() ;
		}
	}
}
