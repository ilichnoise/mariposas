using UnityEngine;
using System.Collections;

public class locationServices : MonoBehaviour {

	string latitude, longitude;

		void Start() {
			//if (!Input.location.isEnabledByUser)
			//	return;
			
			Input.location.Start();
			int maxWait = 20;
			/*while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
				yield return new WaitForSeconds(1);
				maxWait--;
			}
			if (maxWait < 1) {
				print("Timed out");
				return;
			}
			if (Input.location.status == LocationServiceStatus.Failed) {
				print("Unable to determine device location");
				return;
			} else*/
				print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		latitude = ""+Input.location.lastData.latitude;
		longitude = ""+Input.location.lastData.longitude;
		//Input.location.Stop();
		Invoke ("refreshPosition", 1);
		}

	void refreshPosition(){
		latitude = ""+Input.location.lastData.latitude;
		longitude = ""+Input.location.lastData.longitude;
		Invoke ("refreshPosition", 1);
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 1000, 20), "latitude: "+latitude+", longitude: "+longitude);
	}
}
