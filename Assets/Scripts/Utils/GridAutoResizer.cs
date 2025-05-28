using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridAutoResizer : MonoBehaviour
{
    RectTransform _rectTransform;
    GridLayoutGroup _grid;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _grid = GetComponent<GridLayoutGroup>();
    }

    public void Resize()
    {
        int childCount = 0;

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
                childCount++;
        }

        int columns = 1;

        switch (_grid.constraint)
        {
            case GridLayoutGroup.Constraint.FixedColumnCount:
                columns = _grid.constraintCount;
                break;
            case GridLayoutGroup.Constraint.FixedRowCount:
                columns = Mathf.CeilToInt((float)childCount / _grid.constraintCount);
                break;
        }

        int rows = Mathf.CeilToInt((float)childCount / columns);

        float height = (rows * _grid.cellSize.y)
                     + ((rows - 1) * _grid.spacing.y)
                     + _grid.padding.top
                     + _grid.padding.bottom;

        _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, height);
    }
}
