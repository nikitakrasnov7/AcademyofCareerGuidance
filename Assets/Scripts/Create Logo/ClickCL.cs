
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickCL : MonoBehaviour, IPointerClickHandler
{
    public GameObject PrefabElement;
    public ControllerCL Controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject newElement = Instantiate(PrefabElement);
        if (Controller.PointerInstatiate != null)
        {
            newElement.transform.parent = Controller.PointerInstatiate.transform;
            newElement.transform.position = Controller.PointerInstatiate.transform.position;
            newElement.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            AddingCollider(newElement);
        }

    }

    public void AddingCollider(GameObject element)
    {
        GameObject collider;
        switch (element.GetComponent<Image>().sprite.name)
        {
            case "Rect":
                collider = Instantiate(Controller.ColliderRect);
                collider.transform.parent = element.transform;
                collider.transform.localPosition = Vector3.zero;
                break;

            case "MinRect":
                collider = Instantiate(Controller.ColliderMinRect);
                collider.transform.parent = element.transform;
                collider.transform.localPosition = Vector3.zero;

                break;

            case "Ell":
                collider = Instantiate(Controller.ColliderEll);
                collider.transform.parent = element.transform;
                collider.transform.localPosition = Vector3.zero;

                break;
            case "Pol":
                collider = Instantiate(Controller.ColliderPol);
                collider.transform.parent = element.transform;
                collider.transform.localPosition = Vector3.zero;

                break;
        }
        
    }
}
