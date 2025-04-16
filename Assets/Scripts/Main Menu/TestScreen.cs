

using UnityEngine;
using UnityEngine.UI;

public class TestScreen : MonoBehaviour
{
    public Camera renderCamera;      // Камера для рендеринга в RenderTexture
    public RawImage rawImage;        // RawImage для отображения скриншота
    public RenderTexture renderTexture;  // RenderTexture
    public bool useMainCameraCullingMask = false; // Дополнительный параметр

    public Image image;

    void Start()
    {
        //Отключение камеры в начале
       // renderCamera.enabled = false;
    }

    public void TakeScreenshot()
    {
        //Включение камеры для захвата
        renderCamera.enabled = true;

        // Если нужно использовать culling mask от основной камеры:
        if (useMainCameraCullingMask)
        {
            renderCamera.cullingMask = Camera.main.cullingMask;
        }

        // Рендеринг в RenderTexture
        renderCamera.Render();

        // Создание текстуры из RenderTexture
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();
        RenderTexture.active = null;

        // Создание спрайта из текстуры
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);

        // Установка спрайта на RawImage
        image.sprite = sprite;

        //Выключение камеры
        renderCamera.enabled = false;

    }
    public void Deb()
    {
        Debug.Log("Скриншот сделан и отображен!");

    }
}
