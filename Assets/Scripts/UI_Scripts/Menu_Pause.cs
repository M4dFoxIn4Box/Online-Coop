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

        if (Input.GetButtonDown("Pause"))
        {
            Continuer();
        } 
	}

    public void Continuer ()
    {
        isPause = !isPause;
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
         GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Vehicles.Ball.BallUserControl>().ChangerPause(isPause) ;
        }
        menuPause.SetActive(isPause);
    }

    public void QuitterPause()
    {
        Game_Manager.Instance().CmdQuitGame() ;
    }
}