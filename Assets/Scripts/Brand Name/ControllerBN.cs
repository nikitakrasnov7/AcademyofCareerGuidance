using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerBN : MonoBehaviour
{
    public GameObject ReloadButton;

    public TextMeshProUGUI HintText;
    public TMP_InputField InputPlayerBrand;

    public TextMeshProUGUI Progress;
    public TextMeshProUGUI TimerText;

    float timer = 30f;

    private int MaxCount = 5;
    private int playerResoult = 0;

    bool isTimer = true;

    public Dictionary<string, string> DictionaryBrand = new Dictionary<string, string>()
    {
        { "orbit", "���, ���, ��� ... (����������)"},
        { "aviasales" ,"����� ������� ���������� (����������)"},
        { "gillette","..., ����� ��� ������� ��� (����������)"},
        { "������������"," ������ � ... (�������)"},
        { "�����","�������� ��� � ����, �� ���� ������� �� (�������)"},
        { "nike","������ ������ ��� (a���������)"},
        { "redBull", "... �������� (����������)" }
    };

    List<string> KeyBrand = new List<string>()
    {
        "orbit","aviasales","gillette","������������", "�����","nike", "redBull"

    };

    string randomKey = "";
    string inputText = "";

    private void Start()
    {
        Progress.text = $"��� �������� {playerResoult} / {MaxCount}";
        GeneratingRandomHintText();
    }

    private void Update()
    {
        if (isTimer)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                TimerText.text = "00:" + Math.Truncate(timer);
            }
            else
            {
                Progress.text = Progress.text + "\n���";
                ReloadButton.SetActive(true);
               isTimer = false;
            }

        }
    }

    public void GeneratingRandomHintText()
    {
        randomKey = KeyBrand[UnityEngine.Random.Range(0, KeyBrand.Count)];
        HintText.text = DictionaryBrand[randomKey];

    }

    public void CheckingInputPlayerBrand()
    {
        if (timer >= 0)
        {
            inputText = InputPlayerBrand.text.ToLower();
            inputText = inputText.Replace(" ", "");

            if (inputText == randomKey)
            {
                playerResoult++;
                Progress.text = $"��� �������� {playerResoult} / {MaxCount}";
            }
            InputPlayerBrand.text = "";
            GameOver();
            GeneratingRandomHintText();
        }


    }

    public void GameOver()
    {
        if (playerResoult == 5)
        {
            Progress.text = Progress.text + "�������";
            ReloadButton.SetActive(true);

        }
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        BackToMainMenu.Instance.BackToMenu(SceneManager.GetActiveScene().name);
    }
}
