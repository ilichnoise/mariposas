using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Parse;
using System;
using System.Collections.Generic;

public class parseManager : MonoBehaviour {

	public string playerName="gerardo2";
	public string nameFromParse="eins";
	public InputField inputField;
	public int score;

	// Use this for initialization
	public void retrievePlayerData () {
		ParseQuery<ParseObject> query = ParseObject.GetQuery("Usuario").WhereEqualTo("idFacebook",playerName);
		query.FindAsync().ContinueWith(t =>
		                               {
			IEnumerable<ParseObject> results = t.Result;

			foreach(ParseObject parseObject in results){
				nameFromParse = parseObject.Get<string>("idFacebook");
				Debug.Log(nameFromParse);
			}
		});


		/*
		var query = ParseObject.GetQuery("Maintenances")
			.WhereEqualTo("z", "b");
		IEnumerable<ParseObject> results = await query.FindAsync();
		
		
		
		foreach (var record in results)
		{
			Console.WriteLine("in for each");
			var docket = record.Get<String>("Docket");
			Console.WriteLine(docket);
		}
		*/
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
