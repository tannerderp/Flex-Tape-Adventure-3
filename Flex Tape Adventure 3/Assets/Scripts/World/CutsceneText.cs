using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneText : MonoBehaviour
{
    [SerializeField] private string[] dialogue;
    [SerializeField] private string speaker;

    private TextBox textBoxScript;

    private bool firstOne = true; //whether its the first line of dialogue or not
    private int dialogueLineIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        textBoxScript = GetComponent<TextBox>();
        textBoxScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || firstOne == true) && (firstOne || textBoxScript.dialogueIndex >= dialogue[dialogueLineIndex-1].Length - 1) && dialogueLineIndex < dialogue.Length)
        {
            firstOne = false;
            textBoxScript.dialogue = dialogue[dialogueLineIndex];
            textBoxScript.speaker = speaker;
            textBoxScript.shownDialogue = "";
            dialogueLineIndex++;
            textBoxScript.dialogueIndex = 0;
            textBoxScript.enabled = true;
        }
        if(dialogueLineIndex >= dialogue.Length && Input.GetKeyDown(KeyCode.Space) && textBoxScript.dialogueIndex >= dialogue[dialogueLineIndex - 1].Length - 1)
        {
            SceneManager.LoadScene("overworld");
        }
    }
}
