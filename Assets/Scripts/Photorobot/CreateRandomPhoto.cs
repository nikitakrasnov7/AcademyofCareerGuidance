using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private string _hairGenereted;
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

    public static void UpdateInventary()
    {
        if (ImagesInventary.Count > 0 && NewSpriteForInventary.Count > 0)
        {
            for (int i = 0; i < NewSpriteForInventary.Count; i++)
            {
                ImagesInventary[i].sprite = NewSpriteForInventary[i];
            }
        }
    }


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

    public void CheckingPhoto()
    {
        int i = 0;
        if (_hairGenereted == HairImage.sprite.name.ToString())
        {
            HairImage.color = Color.green;
            i++;
        }
        else
        {
            HairImage.color = Color.red;

        }

        if (_beardGenereted == BeardImage.sprite.name.ToString())
        {
            BeardImage.color = Color.green;
            i++;
        }
        else
        {
            BeardImage.color = Color.red;
        }

        if (_noseGenereted == NoseImage.sprite.name.ToString())
        {
            NoseImage.color = Color.green;
            i++;
        }
        else
        {
            NoseImage.color = Color.red;
        }

        if (_lipsGenereted == LipsImage.sprite.name.ToString())
        {
            LipsImage.color = Color.green;
            i++;
        }
        else
        {
            LipsImage.color = Color.red;
        }

        if (_eyesGenereted == EyesRightImage.sprite.name.ToString())
        {
            EyesLeftImage.color = Color.green;
            EyesRightImage.color = Color.green;
            i++;
        }
        else
        {
            EyesLeftImage.color = Color.red;
            EyesRightImage.color = Color.red;
        }

        if (_glassesGenereted == GlassesImage.sprite.name.ToString())
        {
            GlassesImage.color = Color.green;
            i++;
        }
        else
        {
            GlassesImage.color = Color.red;
        }

        if (_faceGenereted == FaceImage.sprite.name.ToString())
        {
            FaceImage.color = Color.green;
            i++;
        }
        else { FaceImage.color = Color.red; }

        if (i == 7)
        {
            FinishText.text = "�� �������";
        }

        else
        {
            FinishText.text = "���";
        }
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
