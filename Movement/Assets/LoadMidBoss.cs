using UnityEngine;
using System.Collections;

public class LoadMidBoss : MonoBehaviour {

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

            Camera.main.orthographicSize = 6;
            followObject.map_size_x = 17.14f;
            followObject.map_size_y = 14.68f;
            Application.LoadLevel("boss test");
        }

    }

}
