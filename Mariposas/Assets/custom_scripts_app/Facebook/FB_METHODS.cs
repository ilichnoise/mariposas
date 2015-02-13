using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FB_METHODS : MonoBehaviour
{
  
    //protected string lastResponse = "";
//	private static bool loged=false;
	public delegate void afterAction();
	private static afterAction accion;
    public static string Callback(FBResult result)
    {
      
        if (!String.IsNullOrEmpty (result.Error))
        {
          return  "Error Response:\n" + result.Error;
        }
        else if (!String.IsNullOrEmpty (result.Text))
        {
            return "Success Response:\n" + result.Text;
        }
        else if (result.Texture != null)
        {
       
           return "Success Response: texture\n";
        }
        else
        {
           return "Empty Response\n";
        }
    }


  

   public static void CallFBInit()
    {
        FB.Init(OnInitComplete, OnHideUnity);
    }

    public static void OnInitComplete()
    {
        Debug.Log("FB.Init completed: Is user logged in? " + FB.IsLoggedIn);
    }

    public static void OnHideUnity(bool isGameShown)
    {
        Debug.Log("Is game showing? " + isGameShown);
    }
	

    public static void CallFBLogin(afterAction accion_)
    {
		accion = accion_;
        FB.Login("public_profile,email,user_friends,publish_actions", LoginCallback);
    }

 	 public static void LoginCallback(FBResult result)
    {
        if (result.Error != null)
           Debug.Log( "Error Response:\n" + result.Error);
        else if (!FB.IsLoggedIn)
        {
           Debug.Log("Login cancelled by Player");
        }
        else
        {

          	Debug.Log( "Login was successful!");
			accion();
        }
    }



    public static void CallFBLogout()
    {
        FB.Logout();
    }

}
