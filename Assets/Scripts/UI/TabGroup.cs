using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    [Header("Colors Tab State")]
    [SerializeField] Color tabIdleColor;
    [SerializeField] Color tabHoverColor;
    [SerializeField] Color tabActiveColor;

    [Header("Tab References")]
    [SerializeField] List<GameObject> _tabPanels;

    private List<TabButton> _tabButtons;
    private TabButton _currentTab;

    void Start()
    {
        OnTabSelected(_tabButtons[0]);
    }

    public void Subscribe(TabButton button)
    {
        _tabButtons ??= new List<TabButton>();
        _tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (_currentTab == null || button != _currentTab)
        {
            button.background.color = tabHoverColor;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        UpdateTab(button);
        ResetTabs();
        button.background.color = tabActiveColor;
        UpdateTabPanel(button);
    }

    void UpdateTab(TabButton button)
    {
        if (_currentTab != null) _currentTab.Deselect();
        _currentTab = button;
        _currentTab.Select();
    }

    void ResetTabs()
    {
        foreach (TabButton button in _tabButtons)
        {
            if (_currentTab != null && button == _currentTab) continue;
            button.background.color = tabIdleColor;
        }
    }

    void UpdateTabPanel(TabButton button)
    {
        var index = button.transform.GetSiblingIndex();
        for (int i = 0; i < _tabPanels.Count; i++)
        {
            _tabPanels[i].SetActive(i == index);
        }
    }
}
