using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] TabGroup _tabGroup;
    [HideInInspector] public Image background;

    public event Action OnTabSelected;
    public event Action OnTabDeselected;

    void Awake()
    {
        background = GetComponent<Image>();
        _tabGroup.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tabGroup.OnTabExit(this);
    }

    public void Select()
    {
        OnTabSelected?.Invoke();
    }

    public void Deselect()
    {
        OnTabDeselected?.Invoke();
    }
}
