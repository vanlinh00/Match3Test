using System;
using UnityEngine;
using static NormalItem;

public class Cell : MonoBehaviour
{
    public int BoardX { get; private set; }

    public int BoardY { get; private set; }

    public Item Item { get; private set; }

    public Cell NeighbourUp { get; set; }

    public Cell NeighbourRight { get; set; }

    public Cell NeighbourBottom { get; set; }

    public Cell NeighbourLeft { get; set; }


    public bool IsEmpty => Item == null;

    public void Setup(int cellX, int cellY)
    {
        this.BoardX = cellX;
        this.BoardY = cellY;
    }

    public bool IsNeighbour(Cell other)
    {
        return BoardX == other.BoardX && Mathf.Abs(BoardY - other.BoardY) == 1 ||
            BoardY == other.BoardY && Mathf.Abs(BoardX - other.BoardX) == 1;
    }


    public void Free()
    {
        Item = null;
    }

    public void Assign(Item item)
    {
        Item = item;
        Item.SetCell(this);
    }

    public void ApplyItemPosition(bool withAppearAnimation)
    {
        Item.SetViewPosition(this.transform.position);

        if (withAppearAnimation)
        {
            Item.ShowAppearAnimation();
        }
    }

    internal void Clear()
    {
        if (Item != null)
        {
            Item.Clear();
            Item = null;
        }
    }

    internal bool IsSameType(Cell other)
    {
        return Item != null && other.Item != null && Item.IsSameType(other.Item);
    }
    public bool IsSameType4neighbors(eNormalType eNormalType)
    {
        bool IsSame = (NeighbourUp != null && NeighbourUp.Item != null && NeighbourUp.Item.IsSameTypeByTypeItem(eNormalType))
                 || (NeighbourBottom != null && NeighbourBottom.Item != null && NeighbourBottom.Item.IsSameTypeByTypeItem(eNormalType))
                 || (NeighbourLeft != null && NeighbourLeft.Item != null && NeighbourLeft.Item.IsSameTypeByTypeItem(eNormalType))
                 || (NeighbourRight != null && NeighbourRight.Item != null && NeighbourRight.Item.IsSameTypeByTypeItem(eNormalType));

        return IsSame;
    }
    internal void ExplodeItem()
    {
        if (Item == null) return;

        Item.ExplodeView();
        Item = null;
    }

    internal void AnimateItemForHint()
    {
        Item.AnimateForHint();
    }

    internal void StopHintAnimation()
    {
        Item.StopAnimateForHint();
    }

    internal void ApplyItemMoveToPosition()
    {
        Item.AnimationMoveToPosition();
    }
}
