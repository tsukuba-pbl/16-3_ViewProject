using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

public class RoomLayout : MonoBehaviour {

	private string path = "https://salty-fortress-26407.herokuapp.com/uxsers/9.json";

	// Use this for initialization
	IEnumerator Start () {

		using(WWW www = new WWW(path)){

			yield return www;

			if(!string.IsNullOrEmpty(www.error)){

				Debug.LogError("www Error:" + www.error);
				yield break;

			}

			Debug.Log(www.text);
			var jsonDict = Json.Deserialize(www.text) as Dictionary<string,object>;
			Debug.Log("id = " + jsonDict["id"]);
			Debug.Log("gazo_url = " + jsonDict["gazo_url"]);
			var jsonDict2 = jsonDict ["zahyo"] as Dictionary<string,object>;
			Debug.Log("x = " + jsonDict2["x"]);
			Debug.Log("y = " + jsonDict2["y"]);
			Debug.Log("z = " + jsonDict2["z"]);
			Debug.Log("offset = " + jsonDict["offset"]);
		}


	}
}
