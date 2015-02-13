using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginCanvasMethods : MonoBehaviour {
	public GameObject loginButton;
	public Text data;
	private string idFacebook;

	void Start(){
	}

	public void LoginFB(){
		FB_METHODS.CallFBLogin (delegate {
			//on success login
			UserManagerParse.loadUser(FB.UserId);
			loginButton.SetActive(false);

			data.text="Ready for increase points?";
		});
	}

	public void IncreasePoints(){
		UserManagerParse.IncreasePoint ();
		data.text="ObjectId:"+UserManagerParse.global_user.idObject+"   idFacebook:"+UserManagerParse.global_user.idFacebook+"  Points:"+UserManagerParse.global_user.points;
	}
}
