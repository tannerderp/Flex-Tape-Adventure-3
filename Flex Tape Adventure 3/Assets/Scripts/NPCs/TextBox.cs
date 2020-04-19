using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    public string dialogue = "Put crap here";
    public string speaker = "Put Crap here";
    public string shownDialogue; //the dialogue that you can see on the screen at the time. Basically, how the words fill in

    [SerializeField] private GameObject speakerObject;
    [SerializeField] private GameObject dialogueObject;
    [SerializeField] private bool dissapearAfterSpace = true;
    [SerializeField] private bool isCutscene = false;

    public int dialogueIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DialogueIncrease", 0, 0.04f);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueObject.GetComponent<TextMeshProUGUI>().text == "Put Crap here" && !isCutscene)
        {
            dialogueIndex = 0;
            gameObject.SetActive(false);
        }
        speakerObject.GetComponent<TextMeshProUGUI>().text = speaker + ":";
        dialogueObject.GetComponent<TextMeshProUGUI>().text = shownDialogue;
        if(dialogueIndex >= dialogue.Length && (Input.GetKeyDown(KeyCode.Space) && dissapearAfterSpace))
        {
            dialogueIndex = 0;
            if (dissapearAfterSpace)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void DialogueIncrease()
    {
        if (gameObject.active == true)
        {
            if (dialogueIndex < dialogue.Length)
            {
                shownDialogue += dialogue[dialogueIndex];
                dialogueIndex++;
            }
        }
    }
}
