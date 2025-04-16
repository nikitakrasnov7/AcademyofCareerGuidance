using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreateRandomPhoto : MonoBehaviour
{
    public Image Photo;
    public List<Sprite> SpritesPhoto;
    public Animator AnimatorFace;
    public AnimationClip AnimationFace;

    public UnityEvent StartTimer;


    public List<Image> ImagesInventaryInspector = new List<Image>();

    public static List<Image> ImagesInventary = new List<Image>();
    public static List<Sprite> NewSpriteForInventary;


    public GameObject ListElement;
    public GameObject Inventary;

    public GameObject NewPhoto;



    [Header("Face  sprite element")]
    public List<Sprite> Face = new List<Sprite>();
    public List<Sprite> Beard = new List<Sprite>();
    public List<Sprite> Lips = new List<Sprite>();
    public List<Sprite> Eyes = new List<Sprite>();
    public List<Sprite> Nose = new List<Sprite>();
    public List<Sprite> Hair = new List<Sprite>();
    public List<Sprite> Glasses = new List<Sprite>();

    [Header("Face Image element")]
    public Image FaceImage;
    public Image BeardImage;
    public Image LipsImage;

    public Image EyesRightImage;
    public Image EyesLeftImage;

    public Image NoseImage;
    public Image HairImage;
    public Image GlassesImage;


    private string _faceGenereted;
    private string _hairGenereted;
    private string _beardGenereted;
    private string _lipsGenereted;
    private string _eyesGenereted;
    private string _glassesGenereted;
    private string _noseGenereted;

    [HideInInspector] public static TypeElementPhotorobot ActiveTypeElement;

    Color noneColor = new Color(0, 0, 0, 0);
    Color activeColor = new Color(0, 0, 0, 255);

    private void Start()
    {
        ImagesInventary = ImagesInventaryInspector;

        ListElement.SetActive(false);
        Inventary.SetActive(false);

        Photo.gameObject.SetActive(true);
        NewPhoto.SetActive(false);

        CheckButton.SetActive(false);

        ActiveTypeElement = TypeElementPhotorobot.None;

    }
    public void StartPhotoRobot()
    {
        StartCoroutine(CreatePhoto());

    }

    private IEnumerator CreatePhoto()
    {
        AnimatorFace.SetTrigger("Start");
        AnimatorFace.speed = 20f;
        yield return new WaitForSeconds(2f);
        AnimatorFace.speed = 10f;
        yield return new WaitForSeconds(2f);
        AnimatorFace.speed = 5f;
        yield return new WaitForSeconds(2f);

        AnimatorFace.SetTrigger("Exit");

        Photo.gameObject.GetComponent<Animator>().enabled = false;

        Photo.gameObject.SetActive(false);
        NewPhoto.gameObject.SetActive(true);

        CreateRandomFace();

        StartTimer.Invoke();

    }

    public void CreateRandomFace()
    {
        FaceImage.sprite = Face[Random.Range(0, Face.Count)];
        _faceGenereted = FaceImage.sprite.name.ToString() + "1";

        BeardImage.sprite = Beard[Random.Range(0, Beard.Count)];
        _beardGenereted = BeardImage.sprite.name.ToString() + "1";

        LipsImage.sprite = Lips[Random.Range(0, Lips.Count)];
        _lipsGenereted = LipsImage.sprite.name.ToString() + "1";

        EyesRightImage.sprite = Eyes[Random.Range(0, Eyes.Count)];
        EyesLeftImage.sprite = EyesRightImage.sprite;
        _eyesGenereted = EyesRightImage.sprite.name.ToString() + "1";


        NoseImage.sprite = Nose[Random.Range(0, Nose.Count)];
        _noseGenereted = NoseImage.sprite.name.ToString() + "1";

        GlassesImage.sprite = Glasses[Random.Range(0, Glasses.Count)];
        _glassesGenereted = GlassesImage.sprite.name.ToString() + "1";

        HairImage.sprite = Hair[Random.Range(0, Hair.Count)];
        _hairGenereted = HairImage.sprite.name.ToString() + "1";

    }

    public void UpdateInventary()
    {
        ActiveInventary();
        switch (DropdownList.value)
        {
            case 0:
                UpdateInventarySlot(SpritesForFaceInventary);
                ActiveTypeElement = TypeElementPhotorobot.Face;
                break;

            case 1:
                UpdateInventarySlot(SpritesForHairInventary);
                ActiveTypeElement = TypeElementPhotorobot.Hair;
                break;

            case 2:
                UpdateInventarySlot(SpritesForNoseInventary);
                ActiveTypeElement = TypeElementPhotorobot.Nose;
                break;

            case 3:
                UpdateInventarySlot(SpritesForBoardInventary);
                ActiveTypeElement = TypeElementPhotorobot.Board;
                break;

            case 4:
                UpdateInventarySlot(SpritesForEyesInventary);
                ActiveTypeElement = TypeElementPhotorobot.Eyes;
                break;

            case 5:
                UpdateInventarySlot(SpritesForLipsInventary);
                ActiveTypeElement = TypeElementPhotorobot.Lips;
                break;

            case 6:
                UpdateInventarySlot(SpritesForGlassesInventary);
                ActiveTypeElement = TypeElementPhotorobot.Glasses;
                break;

        }

    }

    public List<Sprite> SpritesForFaceInventary = new List<Sprite>();
    public List<Sprite> SpritesForHairInventary = new List<Sprite>();
    public List<Sprite> SpritesForNoseInventary = new List<Sprite>();
    public List<Sprite> SpritesForLipsInventary = new List<Sprite>();
    public List<Sprite> SpritesForEyesInventary = new List<Sprite>();
    public List<Sprite> SpritesForBoardInventary = new List<Sprite>();
    public List<Sprite> SpritesForGlassesInventary = new List<Sprite>();

    private void UpdateInventarySlot(List<Sprite> sprites)
    {
        for (int i = 0; i < ImagesInventaryInspector.Count; i++)
        {
            ImagesInventaryInspector[i].sprite = sprites[i];
            ImagesInventaryInspector[i].color = Color.white;
        }

    }

    public TMP_Dropdown DropdownList;
    public void ActiveInventary()
    {
        Inventary.SetActive(true);
    }

    public void ActiveListElemwent()
    {
        ListElement.SetActive(true);
    }

    public void CollectingPhotorobot(Sprite sprite)
    {
        if (ActiveTypeElement != TypeElementPhotorobot.None)
        {
            switch (ActiveTypeElement)
            {
                case TypeElementPhotorobot.Face:
                    FaceImage.sprite = sprite;
                    FaceImage.color = activeColor;
                    break;

                case TypeElementPhotorobot.Board:
                    BeardImage.sprite = sprite;
                    BeardImage.color = activeColor;
                    break;

                case TypeElementPhotorobot.Nose:
                    NoseImage.sprite = sprite;
                    NoseImage.color = activeColor;
                    break;

                case TypeElementPhotorobot.Eyes:
                    EyesLeftImage.sprite = sprite;
                    EyesRightImage.sprite = sprite;
                    EyesLeftImage.color = activeColor;
                    EyesRightImage.color = activeColor;
                    break;

                case TypeElementPhotorobot.Hair:
                    HairImage.sprite = sprite;
                    HairImage.color = activeColor;
                    break;

                case TypeElementPhotorobot.Glasses:
                    GlassesImage.sprite = sprite;
                    GlassesImage.color = activeColor;
                    break;

                case TypeElementPhotorobot.Lips:
                    LipsImage.sprite = sprite;
                    LipsImage.color = activeColor;
                    break;

            }
        }
    }

    public void ResetFace()
    {
        FaceImage.color = noneColor;
        BeardImage.color = noneColor;
        LipsImage.color = noneColor;
        EyesRightImage.color = noneColor;
        EyesLeftImage.color = noneColor;
        GlassesImage.color = noneColor;
        HairImage.color = noneColor;
        NoseImage.color = noneColor;

    }

    [SerializeField]int i = 0;
    public void CheckingPhoto()
    {
        i = 0;
        CheckOutline(_faceGenereted, FaceImage);
        CheckOutline(_beardGenereted, BeardImage);
        CheckOutline(_eyesGenereted, EyesLeftImage);
        CheckOutline(_eyesGenereted, EyesRightImage);
        CheckOutline(_hairGenereted, HairImage);
        CheckOutline(_lipsGenereted, LipsImage);
        CheckOutline(_glassesGenereted, GlassesImage);
        CheckOutline(_noseGenereted, NoseImage);


        if (i == 8)
        {
            FinishText.text = "ÀÉ ÌÀËÀÄÖÀ";
        }

        else
        {
            FinishText.text = "ËÎÕ";
        } 
           
    }

    public void CheckOutline(string generatedSprite, Image image)
    {
        if (image.GetComponent<Outline>() != null)
        {
            image.GetComponent<Outline>().enabled = true;
            image.GetComponent<Outline>().effectDistance = new Vector2(4f, 4f);
            if (generatedSprite == image.sprite.name.ToString())
            {
                i++;
                image.GetComponent<Outline>().effectColor = Color.green;
            }

            else
            {
                image.GetComponent<Outline>().effectColor = Color.red;
            }
        }
    }

    public void ResetOutline()
    {
        FaceImage.GetComponent<Outline>().enabled = false;
        HairImage.GetComponent<Outline>().enabled = false;
        EyesLeftImage.GetComponent<Outline>().enabled = false;
        EyesRightImage.GetComponent<Outline>().enabled = false;
        NoseImage.GetComponent<Outline>().enabled = false;
        LipsImage.GetComponent<Outline>().enabled = false;
        GlassesImage.GetComponent<Outline>().enabled = false;
        BeardImage.GetComponent<Outline>().enabled = false;
    }

    public TextMeshProUGUI FinishText;
    int countFace = 0;
    public GameObject CheckButton;
    public void ActiveCheckButton()
    {
        countFace++;
        if (FaceImage.color == activeColor &&
            HairImage.color == activeColor &&
            NoseImage.color == activeColor &&
            LipsImage.color == activeColor &&
            EyesRightImage.color == activeColor &&
            BeardImage.color == activeColor &&
            GlassesImage.color == activeColor
            )
        {
            CheckButton.SetActive(true);
        }
    }
}
