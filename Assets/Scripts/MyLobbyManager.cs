using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class MyLobbyManager : NetworkLobbyManager  {

	private int nbToWin = 0;
	public string[] sceneBoard;
	private int currentSceneIndex = -1 ;

	public List<Player_Camera> playerList = new List<Player_Camera>();

	private int randomIndex ;

	private string createMatchPwd = "";
	private string joinMatchPwd = "";

	private static MyLobbyManager instance;
    public static MyLobbyManager Instance ()
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

	}

	public void SendHelpRequest(GameObject playGO)
	{
		if(playerList[0].gameObject == playGO)
		{	
			randomIndex = Random.Range(0,2) ;
			Debug.Log("SendRequest") ;
			playerList[1].RpcIconToHelp(randomIndex) ;
		}
		else if(playerList[1].gameObject == playGO)
		{
			randomIndex = Random.Range(0,2) ;
			Debug.Log("SendRequest") ;
			playerList[0].RpcIconToHelp(randomIndex) ;
		}
	}

	public void Response(GameObject gO)
	{
		if(playerList[0].gameObject == gO)
		{	
			playerList[1].RpcTeleport() ;
		}
		else if(playerList[1].gameObject == gO)
		{
			playerList[0].RpcTeleport() ;
		}
	}

	public void AddNb (){
		nbToWin += 1;
		Debug.Log(nbToWin);
		if (nbToWin >= 2)
		{
			currentSceneIndex++ ;
			NetworkLobbyManager.singleton.ServerChangeScene(sceneBoard[currentSceneIndex]);
		}
	}

	public void AddPlayer (Player_Camera playerScript){
		playerList.Add(playerScript);
	}

	public void QuitGame()
	{
		playerList[0].RpcQuitGame();
		playerList[1].RpcQuitGame();
	}

	public void PlayerIsOutTrigger(GameObject gamePlayer)
	{
		if(playerList[0].gameObject == gamePlayer)
		{	
			playerList[1].RpcHideIconToHelp() ;
		}
		else if(playerList[1].gameObject == gamePlayer)
		{
			playerList[0].RpcHideIconToHelp() ;
		}
	}

	public override void OnLobbyServerSceneChanged (string scName)
	{
		
		//if (scName != "Scene_Online")
		//{
			if (playerList.Count > 0)
			{
				StartCoroutine("Test");
				nbToWin = 0;
			}
		//}
	}



	public IEnumerator Test ()
	{
		yield return new WaitForSeconds (0.8f);
		playerList[0].RpcGoTo(startPositions[0].gameObject);
		playerList[1].RpcGoTo(startPositions[1].gameObject);
	}

	public void QuitButton()
	{
		Application.Quit() ;
	}

	//-------------------------------------------//

	public void OnClickStart (int playersNb){
		minPlayers = playersNb;
		SearchForGame();	// looks for a match the player can join, or else creates one
	}

	public void SearchForGame (){
		StartMatchMaker();
		matchMaker.ListMatches(0, 10, "ROOL", false, 0, 0, OnMatchList);
	}

	public override void OnMatchList (bool succes, string extendedInf, List<MatchInfoSnapshot> matchList){
		if (LogFilter.logDebug){
			Debug.Log("NetworkManager OnMatchList ");
		}
        matches = matchList;
        // If the player can join a match, joins it...
        for (var i = 0; i < matches.Count; i++){
			if (matches[i].currentSize < minPlayers){
				matchMaker.JoinMatch(matches[i].networkId, joinMatchPwd," ", " ", 0, 0, OnMatchJoined);
				return;
			}
		}
		// ... or else creates a match
		CreateMatch ();
	}

	public override void OnMatchJoined (bool success, string extendedInf, MatchInfo matchInfo){
		if (LogFilter.logDebug){
			Debug.Log("NetworkManager OnMatchJoined ");
		}
        if (success){
        	Utility.SetAccessTokenForNetwork(matchInfo.networkId, matchInfo.accessToken);
			StartClient(matchInfo);
        }
        else {
            if (LogFilter.logError) {
            	Debug.LogError("Join Failed:" + matchInfo);
            }
        }
	}

	public void CreateMatch (){
		matchMaker.CreateMatch("ROOL", 2, true, createMatchPwd, " ", " ", 0, 0, OnMatchCreate);
	}

	public override void OnMatchCreate (bool success, string extendedInfo, MatchInfo matchInfo){
		if (success) {
			StartHost(matchInfo);
		}
	}
}