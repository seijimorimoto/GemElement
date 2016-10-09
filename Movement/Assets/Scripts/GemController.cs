using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GemController : MonoBehaviour {

	public enum ActiveGem {PULL_PUSH, BLINK, WARP};
	public static ActiveGem gem;
	public static bool objectsStopped;

    public Image imgWheel;

    public Sprite sprWheel1;
    public Sprite sprWheel2;
    public Sprite sprWheel3;
    public Sprite sprWheel4;

    public bool bRotate = false;
    public float fAngle = 90.0f;

    // Use this for initialization
    void Start () {

		gem = ActiveGem.PULL_PUSH;
		objectsStopped = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightAlt))) {
			if (!Pull.hasObjectRotating) {
				if (gem == ActiveGem.PULL_PUSH)
                {
                    gem = ActiveGem.BLINK;
                    bRotate = true;
                }
				else if (gem == ActiveGem.BLINK)
                {
                    gem = ActiveGem.WARP;
                    bRotate = true;
                }
				else if (gem == ActiveGem.WARP)
                {
                    gem = ActiveGem.PULL_PUSH;
                    bRotate = true;
                }
				Debug.Log (gem.ToString ());
			}
		}
	}

    void RotateWheel(float fTarget)
    {
        imgWheel.transform.RotateAround(imgWheel.transform.position,transform.forward,fTarget);
        
    }

    void LateUpdate()
    {
        if(bRotate)
        {
            

        }
    }
}
