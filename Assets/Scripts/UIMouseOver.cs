using UnityEngine;
using UnityEngine.EventSystems;

public class UIMouseOver : MonoBehaviour, 
    IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter!");
    }
}