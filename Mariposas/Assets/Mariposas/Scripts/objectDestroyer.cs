using UnityEngine;
using System.Collections;

public class objectDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void destroy()
	{
		Object.Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
