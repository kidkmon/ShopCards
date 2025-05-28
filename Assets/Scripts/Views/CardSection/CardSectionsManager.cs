using System;
using System.Collections.Generic;
using UnityEngine;

public class CardSectionsManager : MonoBehaviour
{
    [Header("Card Popup")]
    [SerializeField] CardPopupView _cardPopup;

    [Header("Card Sections References")]
    [SerializeField] List<CardSectionView> _cardSections;

    readonly Action<CardAssetConfig> OnCardClicked;

    void Start()
    {
        foreach (var section in _cardSections)
        {
            section.OnCardClick += OpenCardPopup;
        }
    }

    void OnDestroy()
    {
        foreach (var section in _cardSections)
        {
            section.OnCardClick -= OpenCardPopup;
        }
    }

    void OpenCardPopup(CardPopupPayload cardPopupPayload)
    {
        _cardPopup.gameObject.SetActive(true);
        _cardPopup.Setup(cardPopupPayload);
    }
}
