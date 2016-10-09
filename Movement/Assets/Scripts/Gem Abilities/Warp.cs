using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Warp : MonoBehaviour {

	private float lastWarpTime;
	public float warpCooldown;
	public float warpDuration;

	void stopObjects(){
		GemController.objectsStopped = true;
	}

	void awakeObjects(){
		GemController.objectsStopped = false;
	}

	// Use this for initialization
	void Start () {
		lastWarpTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && GemController.gem == GemController.ActiveGem.WARP){
			if ((Time.timeSinceLevelLoad - lastWarpTime) > warpCooldown)
				lastWarpTime = Time.timeSinceLevelLoad;
				stopObjects ();
		}

		if (Time.timeSinceLevelLoad >= (lastWarpTime + warpDuration)){
			awakeObjects ();
		}
	}
}
