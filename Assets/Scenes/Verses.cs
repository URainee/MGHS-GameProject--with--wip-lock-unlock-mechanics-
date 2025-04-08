using UnityEngine;
using UnityEngine.UI;

public class MenuVerses : MonoBehaviour
{
    public Button[] Verses;
    public Button[] Chapters;
    public GameObject versesPanelPrefab; // Assign this in the Unity Editor
    public int totalOfChapters = 4; // Update as needed
    private bool[] chapterCompleted;

    void Start()
    {
        chapterCompleted = new bool[totalOfChapters];

        LoadCurrentChapterProgress();
        InitializeChapters();
        InitializeVerses();
    }

    void InitializeChapters()
    {
        for (int i = 0; i < totalOfChapters; i++)
        {
            if (i < Chapters.Length)
            {
                var chaptersScript = Chapters[i].GetComponent<Chapters>();
                if (chaptersScript != null)
                {
                    chaptersScript.Initialize(i, chapterCompleted[i]);
                }
            }
        }
    }

    void InitializeVerses()
    {
        for (int i = 0; i < totalOfChapters; i++)
        {
            if (i < Verses.Length)
            {
                var versesScript = Verses[i].GetComponent<Verses>();
                if (versesScript != null)
                {
                    GameObject versesPanel = Instantiate(versesPanelPrefab);
                    versesPanel.SetActive(false);

                    versesScript.Initialize(i, chapterCompleted[i], versesPanel);
                }
            }
        }
    }

    public void SaveCurrentChapterProgress()
    {
        for (int i = 0; i < chapterCompleted.Length; i++)
        {
            PlayerPrefs.SetInt("Chapter" + i + "Completed", chapterCompleted[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    public void LoadCurrentChapterProgress()
    {
        for (int i = 0; i < chapterCompleted.Length; i++)
        {
            chapterCompleted[i] = PlayerPrefs.GetInt("Chapter" + i + "Completed", 0) == 1;
        }
    }

    public void CompleteChapter(int chapterIndex)
    {
        if (chapterIndex >= 0 && chapterIndex < chapterCompleted.Length)
        {
            chapterCompleted[chapterIndex] = true;
            SaveCurrentChapterProgress();
            InitializeChapters();
            InitializeVerses();
        }
    }
}

public class Verses : MonoBehaviour
{
    public void Initialize(int verseIndex, bool isCompleted, GameObject versesPanel)
    {
        Debug.Log($"Verse {verseIndex} Initialized. Completed: {isCompleted}");
    }
}
