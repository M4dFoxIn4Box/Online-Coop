using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pression_Trigger : MonoBehaviour {

	public GameObject plateformActive ;
	
	// Use this for initialization
	void Awake () 
	{
		Game_Manager.Instance().RegisterObject(plateformActive) ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
