﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints_Script : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Debug.Log("Checkpoint") ;
			other.transform.GetComponent<Player_Manager>().CheckPointTake(transform.position) ;
			gameObject.SetActive(false) ;

		}
	}
}
