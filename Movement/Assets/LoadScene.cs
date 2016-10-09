using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    public int iLevel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Load Scene " + iLevel);
            Application.LoadLevel(iLevel);
        }
        
    }

   
}
