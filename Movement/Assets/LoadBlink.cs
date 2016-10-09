using UnityEngine;
using System.Collections;

public class LoadBlink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            Camera.main.orthographicSize = 10;
            followObject.map_size_x = 33.6f;
            followObject.map_size_y = 28.8f;
            Application.LoadLevel("Blink1");
        }

    }
}
