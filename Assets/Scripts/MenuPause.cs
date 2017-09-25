using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

	public class MenuManager : MonoBehaviour {
	
	public string Seb_Test;
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

    public void QuitterPause ()
    {
       SceneManager.LoadScene (Seb_Test);
    }
}