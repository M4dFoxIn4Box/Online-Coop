using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Trigger : MonoBehaviour {

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
			IconToDisplay() ;
			Debug.Log("Demand trigger") ;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			HideIcon() ;
		}
	}

	void IconToDisplay()
	{
		Debug.Log("IconToD") ;
		Menu_Pause.Instance().DisplayActiveKey(Random.Range(0,3)) ;
	}

	void HideIcon()
	{
		Menu_Pause.Instance().HideActiveKey() ;
	}
}
