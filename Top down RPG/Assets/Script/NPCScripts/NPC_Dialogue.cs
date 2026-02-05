using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float DialogueRange;
    public LayerMask PlayerLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowDialogue();
    }
    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, DialogueRange,PlayerLayer);
        if (hit != null)
        {
            Debug.Log("player na area de colisão.");
        }
        else
        {

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,DialogueRange);
    }
}
