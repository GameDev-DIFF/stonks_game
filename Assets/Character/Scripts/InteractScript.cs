using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject pressKey;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    private bool nextClick;

    public float wordSpeed;
    public bool playerIsClose;

    private void Start()
    {
        nextClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogueText.text = "";
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }

        }

        if (dialogueText.text == dialogue[index])
        {
            nextClick = true;
        }

        if (nextClick && Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        nextClick = false;

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerInteraction"))
        {
            Debug.Log("ez");
            playerIsClose = true;
            pressKey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerInteraction"))
        {
            playerIsClose = false;
            zeroText();
            pressKey.SetActive(false);
        }
    }
}
