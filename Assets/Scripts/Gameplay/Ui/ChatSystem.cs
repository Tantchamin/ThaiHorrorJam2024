using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // For handling the UI elements

public class ChatSystem : MonoBehaviour
{
    // Reference to the Text UI element where the chat is displayed
    public TMP_Text chatText;
    [SerializeField]
    // Array to hold the dialogue messages
    private string[] messages =
    {
        "Hello! Welcome to our visual novel game.",
        "I hope you enjoy your time here.",
        "Feel free to explore the story by advancing the dialogue.",
        "Good luck, and have fun!"
    };
    // Keeps track of the current message index
    private int currentMessageIndex = -1;
    public GameplayManager gameplayManager;

    void Start()
    {
        gameplayManager.isPlayerMovable = false;
        // Display the first message when the game starts
        AdvanceChat();
    }
    private void OnEnable()
    {
        foreach(Transform obj in gameObject.transform)
        {
            obj.gameObject.SetActive(true);
        }
    }
    private void OnDisable()
    {
        foreach (Transform obj in gameObject.transform)
        {
            obj.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        // Check for player input (pressing Enter key to advance the chat)
        if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))  // Return is the Enter key
        {
            AdvanceChat();
        }
    }

    // Method to progress the dialogue
    void AdvanceChat()
    {
        currentMessageIndex++;

        if (currentMessageIndex < messages.Length)
        {
            StopAllCoroutines();  // Stop any previous typing coroutine
            StartCoroutine(TypeText(messages[currentMessageIndex]));
        }
        else
        {
            this.enabled = false;
            //chatText.text = "End of conversation.";
            gameplayManager.isPlayerMovable = true;
        }
    }
    IEnumerator TypeText(string message)
    {
        chatText.text = ""; // Clear the text first
        foreach (char letter in message.ToCharArray())
        {
            chatText.text += letter;
            yield return new WaitForSeconds(0.05f); // Wait for a short time between each letter
        }
    }

 
}
