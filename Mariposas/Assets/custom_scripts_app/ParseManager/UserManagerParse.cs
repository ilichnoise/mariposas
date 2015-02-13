
//public class UserManagerParse : MonoBehaviour {
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Parse;

public class UserManagerParse : MonoBehaviour {
	
	
	public delegate void afterAction();
	public static User global_user = new User ();

	public static void loadUser(string idFacebook) {
		
		loadByIdFacebook(idFacebook,delegate() {
			Debug.Log("delegating.."+idFacebook);
			if(global_user.idObject==null){
				global_user.idFacebook=idFacebook;
				save ();
			}else{
				Debug.Log ("Previously User Registered:"+global_user.idObject);
			}
		});
		
	}
	public static void IncreasePoint(){
		global_user.points++;
		save();
	}
	
	private static void loadByIdFacebook(String idFacebook_,afterAction after_){
		
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Usuario").WhereEqualTo ("idFacebook", idFacebook_);
		query.FindAsync().ContinueWith(t =>
		                               {
			Debug.Log ("Loading user");
			IEnumerable<ParseObject> results =(IEnumerable<ParseObject>) t.Result;
			List<ParseObject> result_ = results.ToList();
			foreach(ParseObject user in result_){
				string objectId=user.ObjectId;
				string idFacebook=user.Get<string>("idFacebook");
				int points=user.Get<int>("points");
				global_user.idObject=objectId;
				global_user.idFacebook=idFacebook;
				global_user.points=points;
			}
			after_();
		});
	}
	
	private static void _DestroyUser(){
		global_user = new User ();
	}
	
	private static void save(){
		ParseObject user = new ParseObject ("Usuario");

		if (global_user.idObject == null) {

			user ["idFacebook"] = global_user.idFacebook;
			user ["points"] = 0;
			
		} else {
			user.ObjectId=global_user.idObject;
			user ["idFacebook"] = global_user.idFacebook;
			user ["points"] = global_user.points;
		}
				
			  user.SaveAsync ().ContinueWith(t=>
		      {
					
							loadByIdFacebook(global_user.idFacebook,delegate() {
								if(global_user.idObject == null)
									Debug.Log("Created Object");
								else
									Debug.Log("Updated Object");
						
								Debug.Log ("ObjectId:"+global_user.idObject+" idFacebook:"+global_user.idFacebook+",  Points:"+global_user.points);
							});
					

			  }
		      );
	}
	
}