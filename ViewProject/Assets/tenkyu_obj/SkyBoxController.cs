﻿using UnityEngine;
using System.Collections;

// Get the latest webcam shot from outside "Friday's" in Times Square
public class SkyBoxController : MonoBehaviour {
	public string url = "http://subarutelescope.org/Gallery/gallery_images/theta_ExteriorNW_20140205.jpg";

	IEnumerator Start() {
		// Start a download of the given URL
		WWW www = new WWW(url);

		// Wait for download to complete
		yield return www;

		// assign texture
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = www.texture;
	}
}