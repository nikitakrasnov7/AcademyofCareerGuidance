

using UnityEngine;
using UnityEngine.UI;

public class TestScreen : MonoBehaviour
{
    public Camera renderCamera;      // ������ ��� ���������� � RenderTexture
    public RawImage rawImage;        // RawImage ��� ����������� ���������
    public RenderTexture renderTexture;  // RenderTexture
    public bool useMainCameraCullingMask = false; // �������������� ��������

    public Image image;

    void Start()
    {
        //���������� ������ � ������
       // renderCamera.enabled = false;
    }

    public void TakeScreenshot()
    {
        //��������� ������ ��� �������
        renderCamera.enabled = true;

        // ���� ����� ������������ culling mask �� �������� ������:
        if (useMainCameraCullingMask)
        {
            renderCamera.cullingMask = Camera.main.cullingMask;
        }

        // ��������� � RenderTexture
        renderCamera.Render();

        // �������� �������� �� RenderTexture
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();
        RenderTexture.active = null;

        // �������� ������� �� ��������
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);

        // ��������� ������� �� RawImage
        image.sprite = sprite;

        //���������� ������
        renderCamera.enabled = false;

    }
    public void Deb()
    {
        Debug.Log("�������� ������ � ���������!");

    }
}
