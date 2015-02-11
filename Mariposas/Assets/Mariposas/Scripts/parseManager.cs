using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Parse;
using System;
using System.Collections.Generic;

public class parseManager : MonoBehaviour {

	public string playerName="gerardo2";
	public string nameFromParse;
	public InputField inputField;
	public int score;

	// Use this for initialization
	public void retrievePlayerData () {

		/*ParseQuery<ParseObject> query = ParseObject.GetQuery("Usuario").WhereEqualTo("idFacebook",playerName);
		query.FindAsync().ContinueWith(t => 
		                               {
		});
		*/
	//	ArrayList<ParseObject> results  =new ArrayList<ParseObject>();
		//IEnumerable<Parse.ParseObject> results=new;

		ParseQuery<ParseObject> query = ParseObject.GetQuery("Usuario").WhereEqualTo("idFacebook",playerName);
		//query.OrderBy("HighScore").ThenByDescending("PlayerName").Limit(5);

		query.FindAsync().ContinueWith(t =>
		    {
			Debug.Log("Entro al async");
			//results =(List<ParseObject>) t.Result;
			IEnumerable<ParseObject> results =(IEnumerable<ParseObject>) t.Result;
			Debug.Log("Data"+results.);
			foreach (ParseObject obj in results)
			{
				ParseObject id = obj.Get<ParseObject>("idFacebook");
				Debug.Log("Score: ");
			}
		});
		Debug.Log ("retrieveing...");

		//Debug.Log ("afdgeragraeg"+result["idFacebook"]);
		

		/*query.FindAsync().ContinueWith(t =>
		                               {
			IEnumerable<Parse.ParseObject> results = t.Result;
			//ParseQuery<ParseObject> retrievedGameState = t;
			//score = retrievedGameState.Get<int>("score");
		});*/



		//Retrieve score
		/*ParseQuery<ParseObject> query = ParseObject.GetQuery("Usuario").WhereExists(playerName);
		query.GetAsync("rfENQs8joB").ContinueWith(t =>
		                                          {
			ParseObject retrievedGameState = t.Result;
			nameFromParse = retrievedGameState.Get<string>("idFacebook");
		});*/
	}


	public void createUser(){

		playerName = inputField.text;
		ParseObject seed_type = new ParseObject("Usuario");
		seed_type["idFacebook"] = playerName;
		seed_type.SaveAsync ();
	
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 40, 1000, 20), "ID de Facebook: "+nameFromParse);
	}
}
