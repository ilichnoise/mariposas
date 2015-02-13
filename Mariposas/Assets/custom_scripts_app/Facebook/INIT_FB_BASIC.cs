using UnityEngine;
using System.Collections;

public class INIT_FB_BASIC : MonoBehaviour {

	private bool ready=false;
	void OnGUI()
	{

		if(!FB.IsInitialized&&ready)
		{
			FB_METHODS.CallFBInit();
		}
		ready = true;
	}

}
