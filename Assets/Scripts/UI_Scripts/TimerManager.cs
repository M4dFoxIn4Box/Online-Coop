using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : NetworkBehaviour {

	public Image timerBar;
	public float timerLength;
	[SyncVar]
	private float timerValue;
	private bool chronoRunning = true;

	// Use this for initialization
	void Start () {
		if (isServer)
		{
			timerValue = timerLength;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer && chronoRunning)
		{
			timerValue -= Time.deltaTime;
			if (timerValue <= 0)
			{
				ReloadScene();
			}
		}

		timerBar.fillAmount = timerValue / timerLength;
	}

	public void ReloadScene ()
	{
		NetworkLobbyManager.singleton.ServerChangeScene(SceneManager.GetActiveScene().name);
	}
}
