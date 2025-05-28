
public class HomeTabGroup : TabGroup
{

    void Start()
    {
        OnTabSelected(TabButtons[1]);
        InventorySystem.Instance.OnInventoryUpdated += SwitchToInventoryTab;
    }

    void OnDestroy()
    {
        InventorySystem.Instance.OnInventoryUpdated -= SwitchToInventoryTab;
    }

    void SwitchToInventoryTab(int _)
    {
        OnTabSelected(TabButtons[1]);
    }
}
