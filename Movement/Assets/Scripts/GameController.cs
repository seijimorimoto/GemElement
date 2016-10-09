using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Instance of this script to ease acess in other scripts
    public static GameController instance { get; set; }

    //Flag that tells if the player is in a dialogue or not.
    public bool isOnDialogue;

    //An Array of TextFiles with the info of the Dialogues
    public TextAsset[] textDialogues;

    //The number of the next dialogue to play
    private int iDialogueIndex;

    //The number of dialoges in the game
    private int iCountDialogues;
    
    //A reference to the gameobject that controls the dialogues
    public GameObject gbjTextBoxManager;

    //Reference to the canvas that holds the dialogue objects
    public Canvas cvsDialogueCanvas;

    //Reference to the textbox inside the canvas of dialogues
    public GameObject gbjTextContainer;

    //Reference to the text inside the TextContainer
    public Text txtDialogue;

    //Reference to the Array of Arrays of Sprite Images for Actor1 and Actor2 in the
    //Dialogue Scene 
    public imageMatrix[] matActor1;
    public imageMatrix[] matActor2;

    //Reference to the Images in the canvas that will show actor 1 and actor 2
    //sprites
    public Image Actor1;
    public Image Actor2;

    // Use this for initialization
    void Start () {

        //Set the instance of a GameControllerScript, to this Script
        instance = this;

        //The dialogue index starts in the first dialogue
        iDialogueIndex = 0;

        //This is the amount of dialogue in the game
        iCountDialogues = textDialogues.Length;

        //This is the the function to call for the next cutscene
        //if you wish to start the next cutscene in another script
        //write GameController.instance.StartCutScene();
        StartDailogueScene();
        
	}

    /// <summary>
    /// This function initializes and creates all the necessary information to
    /// display the next dailogue, including setting up the DialogBox, the sprites
    /// to show in the next scene, and the correct sprite transitions.
    /// </summary>
    void StartDailogueScene ()
    {
        //Validate that a next dailogue exists, or that this is the last dailogue
        if (iDialogueIndex < iCountDialogues)
        {
            //If the index is valid, start the scene, set the dialogue flag
            //to true
            isOnDialogue = true;

            //Create a TextBoxController instance, this object will control
            //the Dialogue scene, we just need to feed it info.
            GameObject gbjTextBoxInstance = (GameObject)Instantiate(gbjTextBoxManager, Vector3.zero, Quaternion.identity);

            //Make the instance son of the canvas, for order.
            gbjTextBoxInstance.transform.SetParent(cvsDialogueCanvas.transform);

            //Feed the TextBoxInstance the necessary parameters so that it can
            //work out the dialogue
            gbjTextBoxInstance.GetComponent<TextBoxManager>().gbjTextBox = gbjTextContainer;
            gbjTextBoxInstance.GetComponent<TextBoxManager>().arrImageAct1 = matActor1[iDialogueIndex].arrImage;
            gbjTextBoxInstance.GetComponent<TextBoxManager>().arrImageAct2 = matActor2[iDialogueIndex].arrImage;
            gbjTextBoxInstance.GetComponent<TextBoxManager>().textFile = textDialogues[iDialogueIndex++];
            gbjTextBoxInstance.GetComponent<TextBoxManager>().txtDialogue = txtDialogue;
            gbjTextBoxInstance.GetComponent<TextBoxManager>().imgActor1 = Actor1;
            gbjTextBoxInstance.GetComponent<TextBoxManager>().imgActor2 = Actor2;
            
            //Make the 3 objects that compose a dialogue in the Unity Scene to
            //Active, the Dailogue box and the two Actors of the scene.
            gbjTextBoxInstance.GetComponent<TextBoxManager>().gbjTextBox.SetActive(true);
            Actor1.gameObject.SetActive(true);
            Actor2.gameObject.SetActive(true);

            //The TextBoxManager will do the rest
            
        }
        else
        {
            //If the are no more scenes display an error
            Debug.LogError("They are no more Dialogues to play!");
        }

        
    }

    /// <summary>
    /// This Hides the Unity objects of a dialogue and turns off the dailogue
    /// flag
    /// </summary>
    public void EndCutScene ()
    {
        Actor1.gameObject.SetActive(false);
        Actor2.gameObject.SetActive(false);
        isOnDialogue = false;
    }



}
