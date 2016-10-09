using UnityEngine;
using System.Collections;

public class GemController : MonoBehaviour {

	public enum ActiveGem {PULL_PUSH, BLINK, WARP};
	public static ActiveGem gem;
	public static bool objectsStopped;
	public static bool blinkObtained, warpObtained;
	// Use this for initialization
	void Start () {
		gem = ActiveGem.PULL_PUSH;
		blinkObtained = warpObtained = false;
		objectsStopped = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightAlt))) {
			if (!Pull.hasObjectRotating) {
                if (gem == ActiveGem.PULL_PUSH && blinkObtained)
                    gem = ActiveGem.BLINK;
                else if (gem == ActiveGem.BLINK && warpObtained)
                    gem = ActiveGem.WARP;
                else if (gem == ActiveGem.BLINK && !warpObtained)
                    gem = ActiveGem.PULL_PUSH;
                else if (gem == ActiveGem.WARP)
                    gem = ActiveGem.PULL_PUSH;

				Debug.Log (gem.ToString ());
			}
		}
	}
}
