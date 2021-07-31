using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public bool dialogueActive;
    bool updateDialog;
    public Dialogue[] dialogue;
    public int index;
    public bool startOnAwake;
    public bool fadeInText;
    public bool shakeText;
    public DialogueObj awakeDialogue;

    public static DialogueManager Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (startOnAwake && awakeDialogue != null)
            ApplyDialogue(awakeDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueActive)
            return;

        if(!updateDialog)
        {
            updateDialog = true;
            dialogueText.text = dialogue[index].dialogue;

            if (fadeInText)
                dialogueText.DOFade(1, 0.9f);

            if (shakeText)
                dialogueText.transform.DOShakePosition(99999, 1, 3);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (dialogue[index].lastInOrder)
            {
                if (dialogue[index].loadNewestScene)
                {
                    SceneManager.LoadScene(dialogue[index].loadScene);
                }
                index = 0;
                CloseDialogue();
            }
            else
            {
                updateDialog = false;
                index++;
            }
        }


    }

    #region Controls

    public void ApplyDialogue(DialogueObj d)
    {
        dialogue = d.dialogues;
        dialogueActive = true;
        updateDialog = false;

        dialogueText.gameObject.SetActive(true);


        if (fadeInText)
            dialogueText.DOFade(1, 0.9f);

        if (shakeText)
            dialogueText.transform.DOShakePosition(10, 1, 1);

        index = 0;
    }

    public void CloseDialogue()
    {
        index = 0;
        dialogueActive = false;
        dialogueText.gameObject.SetActive(false);
    }

    #endregion
}
