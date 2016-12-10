using UnityEngine;
using System.Collections;

// Get the latest webcam shot from outside "Friday's" in Times Square
public class SkyBoxController : MonoBehaviour {

	IEnumerator Start() {
		// Start a download of the given URL
		string url = RoomLayout.url;
		WWW www = new WWW(url);

		// Wait for download to complete
		yield return www;

		if(!string.IsNullOrEmpty(www.error)){
			Debug.LogError("www Error:" + www.error);
			yield break;
		}

		// assign texture
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = www.texture;

		//家具データの読み込みと配置
		GameObject setfurnobj = GameObject.Find("SetFurniture");
		LoadFurniture loader = setfurnobj.GetComponent<LoadFurniture> ();
		loader.reloadlayout ();

	}
}