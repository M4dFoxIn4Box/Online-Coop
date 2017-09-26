using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Trigger : MonoBehaviour {

	public GameObject gameManager;

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
			Game_Manager.Instance().CmdAddNb() ;
			Destroy(gameObject);
		}
	}

}
