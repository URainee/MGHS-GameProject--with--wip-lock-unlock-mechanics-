using UnityEngine;
using UnityEngine.UI;

public class Chapters : MonoBehaviour
{
    public Button chapterButton;  // The button for the chapter
    public int chapterIndex;      // The chapter number (1-based)
    public bool isChapterCompleted; // Whether the chapter is completed

    // Initialize the button
    public void Initialize(int chapterNumber, bool isCompleted)
    {
        chapterIndex = chapterNumber;
        isChapterCompleted = isCompleted;

        // Set the button text to show the chapter number
        chapterButton.GetComponentInChildren<Text>().text = "Chapter " + (chapterIndex + 1);

        // Lock or unlock the button based on completion
        chapterButton.interactable = isChapterCompleted;

        // Add a listener to handle the button click
        chapterButton.onClick.RemoveAllListeners(); // Clear any existing listeners
        chapterButton.onClick.AddListener(() => OnChapterButtonClick());
    }

    // This method will be called when the button is clicked
    private void OnChapterButtonClick()
    {
        if (isChapterCompleted)
        {
            Debug.Log("Chapter " + (chapterIndex + 1) + " unlocked! Show verses.");
            // Code to show the verses for the chapter
        }
        else
        {
            Debug.Log("Chapter " + (chapterIndex + 1) + " is locked.");
        }
    }
}
