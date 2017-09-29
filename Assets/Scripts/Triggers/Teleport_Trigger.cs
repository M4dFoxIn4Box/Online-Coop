using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Trigger : MonoBehaviour {

	private int randomNumber ;
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
			randomNumber = Random.Range(0,3) ;
			IconToDisplay() ;
			other.GetComponent<Player_Camera>().ToggleHelp() ;
			other.GetComponent<Player_Camera>().ChangeTouchIndex(randomNumber) ;
			Debug.Log("Demand trigger") ;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			other.GetComponent<Player_Camera>().DisableHelp() ;
			HideIcon() ;
		}
	}

	void IconToDisplay()
	{
		Debug.Log("IconToD") ;
		Menu_Pause.Instance().DisplayActiveKey(randomNumber) ;
	}

	void HideIcon()
	{
		Menu_Pause.Instance().HideActiveKey() ;
	}
}
