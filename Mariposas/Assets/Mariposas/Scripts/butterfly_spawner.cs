using UnityEngine;
using System.Collections;

public class butterfly_spawner : MonoBehaviour {

	public Camera camera;
	public int lowerSpawnNumber, upperSpawnNumber;
	public float lowerSpawnTime, upperSpawnTime;
	public float item_lifetime;
	public AudioSource audioSource;
	public int objetosExistentes=0;
	bool hasStarted=false;
	// Use this for initialization
	void Start () {


	}
	

	//Spawn a single item
	void spawnItem(){
		if (objetosExistentes < upperSpawnNumber) {
			objetosExistentes++;
			Vector3 posInicio = new Vector3 (Random.Range (-300, 300), Random.Range (900, 5000), Random.Range (-300, 300));
			GameObject cosaPrefab = Random.value < 0.5f ? (GameObject)Resources.Load ("planePrefab") : (GameObject)Resources.Load ("planePrefab2");
			GameObject GOcosa = (GameObject)Object.Instantiate (cosaPrefab, posInicio, Quaternion.Euler (0, 180, 0));
			GOcosa.GetComponent<butterfly_controller> ().butterflySpawner = this;
			GOcosa.GetComponent<butterfly_controller> ().camera = this.camera;
			GOcosa.GetComponent<butterfly_controller> ().noise1 = this.audioSource;

		}

	}
	
	//Spawn a set of items in random times
	public void spawnSetOfItems(){
		
		int i = 0;
		
		while (i<upperSpawnNumber) {
			Invoke("spawnItem", Random.Range(lowerSpawnTime,upperSpawnTime));
			//spawnItem();
			i++;
		}
		Invoke ("spawnItem",4);
	}

	// Update is called once per frame
	void Update () {
		if (FB.IsLoggedIn&&!hasStarted) {
			spawnSetOfItems ();
			hasStarted=true;
		}

		if (FB.IsLoggedIn) {
			if (objetosExistentes < 5) {
				Invoke ("spawnItem", 2);
			}
		}
	}
}
