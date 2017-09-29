using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyLobbyPlayer : NetworkLobbyPlayer {

	public override void OnStartLocalPlayer (){
		DontDestroyOnLoad(gameObject);
		StartCoroutine("Ready");
	}

	void Update () {

	}

	public IEnumerator Ready (){
		yield return new WaitForSeconds(0.3f);
		SendReadyToBeginMessage();
	}

	public override void OnClientReady (bool readyState){
		if (!readyState){
			SendSceneLoadedMessage();
		}
	}
}
