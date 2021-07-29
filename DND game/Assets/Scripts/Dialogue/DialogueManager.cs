using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject textObj;
    public Image protait;
    public bool dialogueActive;
    bool updateDialog;
    public Dialogue[] dialogue;
    public int index;

    public static DialogueManager Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        textObj.gameObject.SetActive(false);
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

            if(dialogue[index].protait != null)
            {
                protait.sprite = dialogue[index].protait;
                protait.gameObject.SetActive(true);
            }
            else
            {
                protait.gameObject.SetActive(false);
            }
        }

        if (Input.GetButtonDown("Proceed"))
        {
            if (dialogue[index].lastInOrder)
            {
                if (dialogue[index].loadNewestScene)
                {
                    SceneManager.LoadScene(dialogue[index].loadScene);
                    //MySceneManager.Instance.LoadAndUnloadScenes(dialogue[index].loadScene, MySceneManager.Instance.currentScene.sceneId);
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
        textObj.SetActive(true);
        updateDialog = false;
        index = 0;
    }

    public void CloseDialogue()
    {
        index = 0;
        dialogueActive = false;
        textObj.SetActive(false);
    }

    #endregion
}
