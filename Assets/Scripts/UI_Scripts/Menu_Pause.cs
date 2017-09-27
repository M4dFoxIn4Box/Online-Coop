using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Menu_Pause : NetworkBehaviour {
	
	public string Room;
	private bool isPause = false;
	public GameObject menuPause;

	private static Menu_Pause instance;
	public static Menu_Pause Instance () 
    {
    	return instance;
    }

    void Awake (){
    	if (instance != null)
        {
            Destroy (gameObject);
        }
        else 
        {
            instance = this;
        }
    }
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
        menuPause.SetActive(isPause);
    }

    public void QuitterPause()
    {
        Game_Manager.Instance().CmdQuitGame() ;             
    }

    public bool ReturnPause()
    {
    	 return isPause ;
    }
}