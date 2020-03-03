using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcollide : MonoBehaviour
{
    private GameObject messageBubble;
    private GameObject textBox;
    private TextBox textBoxScript;

    [SerializeField] private string speaker;
    [SerializeField] private string dialogue;

    private bool inTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        messageBubble = this.gameObject.transform.GetChild(0).gameObject;
        textBox = GameObject.Find("Text Box");
        textBoxScript = textBox.GetComponent<TextBox>();
        textBox.SetActive(false);
        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger == true)
        {
            messageBubble.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space) && textBoxScript.dialogueIndex == 0)
            {
                textBoxScript.dialogue = dialogue;
                textBoxScript.speaker = speaker;
                textBoxScript.shownDialogue = "";
                textBox.SetActive(true);
            }
        }
        else
        {
            messageBubble.SetActive(false);
        }
        //inTrigger = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
