using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControll : MonoBehaviour
{
    [System.Serializable]
    public enum idioma
    {
        pt,eng
    }

    public idioma language;

    [Header("Components")]
    public GameObject dialogueObj; // janela de dialogo
    public Image profileSprite;// sprite do perfil
    public Text speechText;// txt de fala
    public Text actorNameText;// nome do npc 

    [Header("Settings")]
    public float typingSpeed;// velocidade de fala 

    //variaveis de controle 
    private bool isShowing; // se janela esta visivel
    private int index;// index das sentenças 
    private string[] sentences;

    public static DialogueControll instance;



    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    void Update()
    {

    }
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //pular para proxima fala 
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if (index < sentences.Length -1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //quando terminar o texti 
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }
    // chamar a fala do NPC 
    public void Speech(string[]txt)
    {
        if(!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}