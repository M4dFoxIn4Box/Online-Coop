using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

	public class Menu_Pause : NetworkBehaviour {
	
	public string Room;
	private bool isPause = false;
	public GameObject menuPause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Continuer();
        } 
	}

    public void Continuer ()
    {
        isPause = !isPause;
        menuPause.SetActive(isPause);
    }
    [ClientRpc]
    public void RpcquitterPause ()
    {
        Game_Manager.Instance().CmdQuitGame() ;
    }
}