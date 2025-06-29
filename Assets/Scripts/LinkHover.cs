using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class LinkHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text linkText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        linkText.color = new Color32(128, 0, 128, 255); // viola
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        linkText.color = new Color32(0, 0, 238, 255); // blu link
    }
}
