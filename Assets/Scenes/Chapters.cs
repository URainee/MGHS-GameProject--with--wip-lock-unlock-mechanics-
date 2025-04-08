using UnityEngine;
using UnityEngine.UI;

public class Chapters : MonoBehaviour
{
    // Public variables
    public Button chapterButton; // Button representing the chapter
    public int chapterIndex;     // Chapter number (1-based index)
    public bool isChapterCompleted; // Status of chapter completion

    // Initialize the chapter button
    public void Initialize(int chapterNumber, bool isCompleted)
    {
        chapterIndex = chapterNumber;
        isChapterCompleted = isCompleted;

        // Set button label to display the chapter number
        if (chapterButton != null && chapterButton.GetComponentInChildren<Text>() != null)
        {
            chapterButton.GetComponentInChildren<Text>().text = "Chapter " + chapterNumber;
        }

        // Lock button if the chapter isn't completed
        if (chapterButton != null)
        {
            chapterButton.interactable = isCompleted;
        }

        // Add a click event to the button
        if (chapterButton != null)
        {
            chapterButton.onClick.RemoveAllListeners(); // Ensure no duplicate listeners
            chapterButton.onClick.AddListener(OnChapterButtonClick);
        }
    }

    // Handle chapter button click
    private void OnChapterButtonClick()
    {
        if (isChapterCompleted)
        {
            Debug.Log("Chapter " + chapterIndex + " selected!");
            // Add functionality to display verses for this chapter
        }
        else
        {
            Debug.Log("Chapter " + chapterIndex + " is locked.");
        }
    }
}