using UnityEngine;
using System.Collections;

public class butterfly_controller : MonoBehaviour {

	public Camera camera;
	public float accelerationTrigger;
	bool flying=false;
	float ceiling=688;
	string gui="eins";
	public AudioSource noise1;
	// Use this for initialization
	void Start () {
		rigidbody.AddRelativeTorque (new Vector3(Random.Range(-400,400),Random.Range(-400,400),Random.Range(-400,400)));
		Invoke ("toggleState", 3);
	}
	
	public void destroy()
	{
		Object.Destroy(gameObject);
	}

	void toggleState(){
	
		flying = !flying;
		Invoke ("toggleState", 1);
		//Debug.Log ("toggleState");
	
	}

	public void add_force(){
		rigidbody.AddForce (Vector3.up*50);
		//Debug.Log ("add force");
	}

	// Update is called once per frame
	void Update () {

		if (flying) {
			if(transform.position.y<ceiling){
				add_force();
			}
		}
		Vector3 screenPos = camera.WorldToScreenPoint(transform.position);

		if (screenPos.y < 4 * Screen.height * 0.2f && screenPos.y > Screen.height * 0.2f && screenPos.x < 4 * Screen.width * 0.2f && screenPos.x > Screen.width * 0.2f) {
			gui = "eins";
			if(Input.acceleration.x>accelerationTrigger||Input.acceleration.y>accelerationTrigger||Input.acceleration.z>accelerationTrigger){
				noise1.Play();
				destroy();
			}
		}
		else
			gui="zwei";
	}
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), gui);
	}
}
