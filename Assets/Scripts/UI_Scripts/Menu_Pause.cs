﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI ;

public class Menu_Pause : NetworkBehaviour {
	
	public string Room;
	private bool isPause = false;
	public GameObject menuPause;

    public List<Sprite> iconList = new List<Sprite>() ;
    public Image demandIcon ;
    public Image helpIcon ;

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

    public void DisplayActiveKey(int idx)
    {
        demandIcon.sprite = iconList[idx] ;
        demandIcon.gameObject.SetActive(true) ;
    }

   public void DisplayIconToHelp()
    {
        helpIcon.sprite = iconList[Random.Range(0,2)] ;
        helpIcon.gameObject.SetActive(true) ;
    }

    public void QuitterPause()
    {
        // MyLobbyManager.singleton.CmdQuitGame() ;             
    }

    public bool ReturnPause()
    {
    	 return isPause ;
    }
}