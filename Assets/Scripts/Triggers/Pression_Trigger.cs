using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pression_Trigger : MonoBehaviour {

	public GameObject plateformActive;
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
			Game_Manager.Instance().CmdActivatePlateform(plateformActive) ;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			Game_Manager.Instance().CmdStopPlateform(plateformActive) ;
		}
	}
}
