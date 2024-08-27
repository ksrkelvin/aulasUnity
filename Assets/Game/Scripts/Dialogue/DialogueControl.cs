using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    [System.Serializable]
    public enum idiom
    {
        pt,
        en,
        es
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //Janela do dialogo
    public Image profileSprite; //Sprite do personagem
    public TextMeshProUGUI speechText;//Texto do dialogo
    public TextMeshProUGUI actorNameText;//Nome do personagem
    

    [Header("Settings")]
    public float typingSpeed;//Velocidade de escrita


    //Variaveis de controle
    private bool _isShowing;//janela de dialogo esta aberta
    public bool isShowing
    {
        get => _isShowing; 
        set =>_isShowing = value; 
    }
    private int index;//index da sentença atual
    private string[] sentences;


    public static DialogueControl instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //funcao para mostrar o dialogo letra por letra
    IEnumerator TypeSentence()
    {
     foreach(char letter in sentences[index].ToCharArray())
     {
        speechText.text += letter;
        yield return new WaitForSeconds(typingSpeed);
     }   
    }

    //funcao para mostrar a proxima sentenca
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                dialogueObj.SetActive(false);
                isShowing = false;
                sentences = null;
                index = 0;
            }
        }
    }

    //funcao para mostrar o dialogo
    public void Speech(string[] txt )
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
