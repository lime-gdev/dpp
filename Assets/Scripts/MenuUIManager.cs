using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Text BestScoreText;
    private string Name;
    private int Score;

    private void Start()
    {
        ScenesManager.Instance.Load();
        Name = ScenesManager.Instance.BestName;
        Score = ScenesManager.Instance.Score;
        BestScoreText.text = "Best score: " + Name + " " + Score;
    }
    public void SetGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void SetName()
    {
        Name = inputField.text;
        ScenesManager.Instance.Name = Name;
        print(ScenesManager.Instance.Name);
    }

}
