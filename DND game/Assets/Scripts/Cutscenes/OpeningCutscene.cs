using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    public GameObject dialogueCanvas;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas.gameObject.SetActive(false);
        StartCoroutine(OpeningSequence());
    }

    IEnumerator OpeningSequence()
    {
        yield return new WaitForSeconds(5);

        dialogueCanvas.gameObject.SetActive(true);
    }
}
