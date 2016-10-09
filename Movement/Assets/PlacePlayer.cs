using UnityEngine;
using System.Collections;

public class PlacePlayer : MonoBehaviour {

    GameObject gbjPlayer;

	// Use this for initialization
	void Start () {

        gbjPlayer = GameObject.FindGameObjectWithTag("Player");
        gbjPlayer.transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
