using UnityEngine;
using System.Collections;

public class FreePull : MonoBehaviour {

    public bool bSwitch1;
    public bool bSwitch2;

    public static FreePull instance { get; set; }

	// Use this for initialization
	void Start () {

        instance = this;
        bSwitch1 = false;
        bSwitch2 = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        if(bSwitch1 && bSwitch2)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
	
	}


}
