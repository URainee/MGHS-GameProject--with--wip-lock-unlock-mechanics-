using UnityEngine;       
using UnityEngine.UI;

public class MenuVerses : MonoBehaviour
{
    public Button[] Verses;
    public Button[] Chapters;
    public int totalofChapters = 4; //Update accordingly to each new chapter
    private bool[] ChapterCompleted;

    void Start()
    {
        ChapterCompleted = new bool[totalofChapters]; // Initialize completion


        LoadCurrentChapterProgress();

        InitializeChapters();
        InitializeVerses();
    }

    void InitializeChapters()
    {
        for (int i = 0; i < totalofChapters; i++)
        {
            if (i < Chapters.Length)
            {

                Chapters ChaptersScript = Chapters[i].GetComponent<Chapters>();


                ChaptersScript.Initialize(i, ChapterCompleted[i]);
            }
        }
    }

    void InitializeVerses()
    {

        for (int i = 0; i < totalofChapters; i++)
        {
            if (i < Verses.Length)
            {
                Verses VersesScript = Verses[i].GetComponent<Verses>();


                GameObject versesPanel = Instantiate(versesPanelPrefab);
                versesPanel.SetActive(false);

                VersesScript.Initialize(i, ChapterCompleted[i], versesPanel);
            }
        }
    }

    public void SaveCurrentChapterProgress()
    {
        for (int i = 0; i < ChapterCompleted.Length; i++)
        {
            PlayerPrefs.SetInt("Chapter" + i + "Completed", ChapterCompleted[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    public void LoadCurrentChapterProgress()
    {
        for (int i = 0; i < ChapterCompleted.Length; i++)
        {
            ChapterCompleted[i] = PlayerPrefs.GetInt("Chapter" + i + "Completed", 0) == 1;
        }
    }

    public void CompleteChapter(int chapterIndex)
    {
        ChapterCompleted[chapterIndex] = true;
        SaveCurrentChapterProgress(); 
        InitializeChapters(); 
        InitializeVerses(); 
    }
}
