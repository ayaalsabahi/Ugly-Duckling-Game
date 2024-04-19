using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Based largely on this tutorial by Game Dev Experiments on YouTube
// https://www.youtube.com/watch?v=2CmG7ZtrWso&ab_channel=GameDevExperiments

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialogue;
    public event Action OnCloseDialogue;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    Dialogue localDialogue;
    public bool isTyping = false;

    public IEnumerator ShowDialogue(Dialogue receivingDialogue)
    {
        SetDialogue(receivingDialogue);

        dialogueBox.SetActive(true);

        StartCoroutine(TypeDialogue(receivingDialogue.Lines[0]));
        yield return new WaitForEndOfFrame();
    }

    private void SetDialogue(Dialogue receivingDialogue)
    {
        localDialogue = receivingDialogue;
    }

    private void Update()
    {
        if (!isTyping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CloseDialogueBox();
            }
        }
    }

    public void CloseDialogueBox()
    {
        //StopCoroutine(TypeDialogue(localDialogue.Lines[0]));
        dialogueBox.SetActive(false);
    }

    public IEnumerator TypeDialogue(string line)
    {
        isTyping = true;
        Debug.Log("Line should be: " +line);
        dialogueText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }
}
