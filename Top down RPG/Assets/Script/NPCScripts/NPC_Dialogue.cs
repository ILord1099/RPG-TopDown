using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float DialogueRange;
    public LayerMask PlayerLayer;

    public DialogueSettings dialogue;

    bool playerHit;

    private List<string> sentences = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        GetNPCInfo();
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& playerHit)
        {
            DialogueControll.instance.Speech(sentences.ToArray());
        }
    }
    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++) 
        {
            switch (DialogueControll.instance.language)
            {
                case DialogueControll.idioma.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogueControll.idioma.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
            }

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }
    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, DialogueRange,PlayerLayer);
        if (hit != null)
        {
           playerHit = true;
        }
        else
        {
            playerHit= false;
           // sentences = null;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,DialogueRange);
    }
}
