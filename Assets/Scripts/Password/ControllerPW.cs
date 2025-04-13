using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerPW : MonoBehaviour
{
    public GameObject prefabPassword;
    public GameObject PointToSpawn;
    public GameObject ReloadButtin;

    public TextMeshProUGUI Timer;
    public TextMeshProUGUI StartTimerText;

    public TMP_InputField InputPasword;
    public static TMP_InputField S_InputPassword;

    public Outline OutlineInputField;

    static int lenghtInputPassword = 0;
    int countTruePassword;

    [SerializeField] private float time = 30f;
    float clearTime = 0f;


    static bool isCor = true;
    bool isTimer = false;
    public bool isClear;


    private string savePassword;
    private void Start()
    {
        S_InputPassword = InputPasword;
        StartCoroutine(StartTimer());
        InputPasword.interactable = false;


    }

    private void Update()
    {
        if (isTimer)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
                Timer.text = $"00:{Math.Truncate(time)}";

            }
            else
            {
                isTimer = false;
                StartTimerText.transform.parent.gameObject.SetActive(true);
                StartTimerText.text = countTruePassword.ToString() + "/5";
                ReloadButtin.gameObject.SetActive(true);
                //StopAllCoroutines();

            }
        }

        if (isClear)
        {
            if (clearTime <= 3)
            {
                clearTime += Time.deltaTime;
            }
            else
            {
                InputPasword.text = "";
                isClear = false;
                clearTime = 0f;
                lenghtInputPassword = 0;
            }
        }
        if (!isClear)
        {
            if (clearTime != 0)
            {
                clearTime = 0f;
                InputPasword.text = InputPasword.text.Substring(0, InputPasword.text.Length - 1);
                lenghtInputPassword--;
            }
        }
    }
    public void RandomCreatePassword()
    {
        if (isCor)
        {
            StartCoroutine(RandomCreateCoroutine());
        }
    }

    IEnumerator RandomCreateCoroutine()
    {

        isCor = false;
        string password = "";

        for (int i = 0; i < 6; i++)
        {
            password = password + UnityEngine.Random.Range(0, 9).ToString();
        }
        savePassword = password;
        float x = UnityEngine.Random.Range(50, Screen.width - 100);
        float y = UnityEngine.Random.Range(0, Screen.height - 50);

        GameObject newPrefab = Instantiate(prefabPassword);
        newPrefab.GetComponentInChildren<TextMeshProUGUI>().text = password;
        newPrefab.transform.parent = PointToSpawn.transform;
        newPrefab.transform.position = new Vector3(x, y, 0);

        InputPasword.interactable = false;

        yield return new WaitForSeconds(2f);

        InputPasword.interactable = true;

        Destroy(newPrefab);
        isCor = true;
    }

    public void CheckPasssword()
    {
        if (lenghtInputPassword != 0)
        {

            lenghtInputPassword = 0;
            if (InputPasword.text == savePassword)
            {
                StartCoroutine(OutlineColor(Color.green));
                countTruePassword++;
            }
            else
            {
                StartCoroutine(OutlineColor(Color.red));
            }
            InputPasword.text = "";
            StartCoroutine(RandomCreateCoroutine());
        }
        else
        {
            StartCoroutine(OutlineColor(Color.red));
        }
        if(countTruePassword ==5)
        {
            StartTimerText.transform.parent.gameObject.SetActive(true);
            StartTimerText.text = countTruePassword.ToString()+ "/5 + \nСигма";
            ReloadButtin.gameObject.SetActive(true);
        }
    }

    IEnumerator OutlineColor(Color color)
    {
        OutlineInputField.enabled = true;
        OutlineInputField.effectColor = color;
        yield return new WaitForSeconds(0.2f);
        OutlineInputField.enabled = false;
    }

    public static void InputPasswordButton(string number)
    {

        if (isCor)
        {
            if (lenghtInputPassword < 6)
            {
                lenghtInputPassword++;
                S_InputPassword.text = S_InputPassword.text + number.ToString();
            }
        }
    }

    IEnumerator StartTimer()
    {
        StartTimerText.text = "3";
        yield return new WaitForSeconds(1f);
        StartTimerText.text = "2";
        yield return new WaitForSeconds(1f);
        StartTimerText.text = "1";
        yield return new WaitForSeconds(1f);
        StartTimerText.text = "Старт";
        yield return new WaitForSeconds(1f);
        StartTimerText.transform.parent.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Timer.text = time.ToString();
        isTimer = true;
        RandomCreatePassword();

    }


    public void ClearInput()
    {
        isClear = true;
    }
    public void ClearInput2()
    {
        isClear = false;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

