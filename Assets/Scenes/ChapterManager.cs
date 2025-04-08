using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{
    public Button[] chapterButtons; // Buttons representing the chapters
    public int numberOfChapters = 12; // Total number of chapters
    private bool[] chapterCompletionStatus; // Tracks chapter completion status

    // Initialization when the script starts
    void Start()
    {
        chapterCompletionStatus = new bool[numberOfChapters];

        LoadChapterProgress(); // Load saved chapter progress

        InitializeChapterButtons(); // Set up chapter buttons
    }

    // Initialize each chapter button with its respective data
    void InitializeChapterButtons()
    {
        for (int i = 0; i < numberOfChapters; i++)
        {
            if (i < chapterButtons.Length)
            {
                ChapterButton chapterButtonScript = chapterButtons[i].gameObject.AddComponent<ChapterButton>(); // Ensure the ChapterButton script is added
                chapterButtonScript.Initialize(i, chapterCompletionStatus[i]);
            }
        }
    }

    // Save the completion status of each chapter using PlayerPrefs
    public void SaveChapterProgress()
    {
        for (int i = 0; i < chapterCompletionStatus.Length; i++)
        {
            PlayerPrefs.SetInt("Chapter" + i + "Completed", chapterCompletionStatus[i] ? 1 : 0);
        }
        PlayerPrefs.Save(); // Ensure data is written to storage
    }

    // Load saved completion status from PlayerPrefs
    public void LoadChapterProgress()
    {
        for (int i = 0; i < chapterCompletionStatus.Length; i++)
        {
            chapterCompletionStatus[i] = PlayerPrefs.GetInt("Chapter" + i + "Completed", 0) == 1;
        }
    }

    // Mark a chapter as completed and update progress
    public void CompleteChapter(int chapterIndex)
    {
        if (chapterIndex >= 0 && chapterIndex < chapterCompletionStatus.Length)
        {
            chapterCompletionStatus[chapterIndex] = true;

            SaveChapterProgress(); // Persist updated progress

            InitializeChapterButtons(); // Refresh chapter buttons
        }
        else
        {
            Debug.LogError("Invalid chapter index: " + chapterIndex);
        }
    }
}

public class ChapterButton : MonoBehaviour
{
    private int chapterIndex;
    private bool isCompleted;

    // Initialize the button with chapter data
    public void Initialize(int chapterIndex, bool isCompleted)
    {
        this.chapterIndex = chapterIndex;
        this.isCompleted = isCompleted;

        Debug.Log($"Chapter {chapterIndex} Initialized. Completed: {isCompleted}");
    }

    // Optionally handle button clicks
    public void OnButtonClick()
    {
        if (isCompleted)
        {
            Debug.Log($"Chapter {chapterIndex} clicked!");
            // Add logic for what happens when a chapter is clicked
        }
        else
        {
            Debug.Log($"Chapter {chapterIndex} is locked.");
        }
    }
}
