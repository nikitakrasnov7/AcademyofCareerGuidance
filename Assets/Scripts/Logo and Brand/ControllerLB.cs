
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ControllerLB : MonoBehaviour
{
    public TextMeshProUGUI FinishText;

    public List<Image> ListLogoImages = new List<Image>();
    public List<Sprite> ListSpriteForLogo = new List<Sprite>();

    public static List<Sprite> S_ListSpriteForLogo;

    private List<Sprite> shuffledSprites;

    public List<TextMeshProUGUI> ButtonBrandText = new List<TextMeshProUGUI>();

    bool isCor = true;

    int correctCount = 0;
    List<string> buttonTitle = new List<string>()
    {
        "Яблосос",
        "Дольче Гуни",
        "Спермбанк",
        "Найк Про",
        "Четыре свадьбы"
    };
    public static List<string> S_ButtonTitle = new List<string>();

    List<string> shufflesTitle;

    public List<BrandLB> ListBrands = new List<BrandLB>();
    public static List<BrandLB> S_ListBrands;

    public static GameObject SelectLogo;
    public static GameObject SelectButton;


    private void Start()
    {
        S_ListBrands = ListBrands;
        S_ListSpriteForLogo = ListSpriteForLogo;
        S_ButtonTitle = buttonTitle;

        Shuffle();
        Assign();
    }


    void Shuffle()
    {
        shuffledSprites = ListSpriteForLogo.OrderBy(x => Random.value).ToList();
        shufflesTitle = buttonTitle.OrderBy(x => Random.value).ToList();
    }

    void Assign()
    {
        int spriteIndex = 0;
        int textIndex = 0;
        foreach (Image image in ListLogoImages)
        {
            if (spriteIndex < shuffledSprites.Count)
            {
                image.GetComponent<InformationLogo>().GetSprite(shuffledSprites[spriteIndex]);
                spriteIndex++;
            }

        }
        foreach (TextMeshProUGUI text in ButtonBrandText)
        {
            if (textIndex < shufflesTitle.Count)
            {
                text.GetComponent<InformationButtonLB>().GetStringButton(shufflesTitle[textIndex]);
                textIndex++;
            }
        }
    }


    private void Update()
    {
        CheckResoult();
    }

    public void CheckResoult()
    {
        if (SelectLogo != null && SelectButton != null)
        {
            if (isCor)
            {
                isCor = false;
                StartCoroutine(CheckSelectLogoAndBrand());
            }
        }
    }
    private IEnumerator CheckSelectLogoAndBrand()
    {
        if (SelectLogo.GetComponent<InformationLogo>().BrandLogo == SelectButton.GetComponent<InformationButtonLB>().BrandButton)
        {
            SelectButton.GetComponentInParent<Outline>().effectColor = Color.green;
            SelectLogo.GetComponent<Outline>().effectColor = Color.green;

            yield return new WaitForSeconds(0.3f);

            SelectButton.GetComponentInParent<Outline>().enabled = false;
            SelectLogo.GetComponent<Outline>().enabled = false;

            Destroy(SelectLogo);
            Destroy(SelectButton.transform.parent.gameObject);
            correctCount++;
        }
        else
        {
            SelectButton.GetComponentInParent<Outline>().effectColor = Color.red;
            SelectLogo.GetComponent<Outline>().effectColor = Color.red;

            yield return new WaitForSeconds(0.3f);
            SelectButton.GetComponentInParent<Outline>().enabled = false;
            SelectLogo.GetComponent<Outline>().enabled = false;
        }

        SelectLogo = null;
        SelectButton = null;

        isCor = true;

        if (correctCount == 5)
        {
            FinishText.gameObject.SetActive(true);
            FinishText.text = "Молодец";

        }
    }


}
