using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 👈 IMPORTANTE

public class DialogueControll : MonoBehaviour
{
    [System.Serializable]
    public enum idioma
    {
        pt, eng
    }

    public idioma language;

    [Header("Components")]
    public GameObject dialogueObj; // janela de dialogo
    public Image profileSprite;    // sprite do perfil
    public TMP_Text speechText;    // texto da fala (TMP)
    public TMP_Text actorNameText; // nome do NPC (TMP)

    [Header("Settings")]
    public float typingSpeed; // velocidade de digitação

    // variáveis de controle
    private bool isShowing;
    private int index;
    private string[] sentences;

    public static DialogueControll instance;

    private void Awake()
    {
        instance = this;
    }

    IEnumerator TypeSentence()
    {
        speechText.text = "";

        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // pular para próxima fala
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                StartCoroutine(TypeSentence());
            }
            else // terminou o diálogo
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
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            index = 0;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
