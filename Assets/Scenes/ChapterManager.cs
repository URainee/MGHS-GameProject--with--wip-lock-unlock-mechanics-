using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{
    public Button[] Chapters; 
    public int numberOfChapters = 12;
    private bool[] chapterCompletionStatus;

    void Start()
    {
        chapterCompletionStatus = new bool[numberOfChapters];

       
        LoadCurrentChapterProgress();

      
        InitializeChapterButtons();
    }

  
    void InitializeChapterButtons()
    {
       
        for (int i = 0; i < numberOfChapters; i++)
        {
            if (i < Chapters.Length)
            {
                Chapters chapterButtonScript = chapterButtons[i].GetComponent<ChapterButton>();

              
                chapterButtonScript.Initialize(i, chapterCompletionStatus[i]);
            }
        }
    }

 
    public void SaveCurrentChapterProgress()
    {
        for (int i = 0; i < chapterCompletionStatus.Length; i++)
        {
            PlayerPrefs.SetInt("Chapter" + i + "Completed", chapterCompletionStatus[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

 
    public void LoadChapterProgress()
    {
        for (int i = 0; i < chapterCompletionStatus.Length; i++)
        {
            chapterCompletionStatus[i] = PlayerPrefs.GetInt("Chapter" + i + "Completed", 0) == 1;
        }
    }


    public void CompleteChapter(int chapterIndex)
    {

        chapterCompletionStatus[chapterIndex] = true;


        SaveCurrentChapterProgress();


        InitializeChapterButtons();
    }
}
