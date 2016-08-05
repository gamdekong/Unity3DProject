using UnityEngine;
using System.Collections;

public class DragAndDropMakingCard : UIDragDropItem
{
    /// <summary>
    /// Prefab object that will be instantiated on the DragDropSurface if it receives the OnDrop event.
    /// </summary>

    public GameObject prefab;
    public Transform CardGrid;
    public Transform Slot;

    public GameObject Tier5;
    public GameObject Tier4;
    public GameObject Tier3;
    public GameObject Tier2;
    public GameObject Tier1;

    /// <summary>
    /// Drop a 3D game object onto the surface.
    /// </summary>

    protected override void OnDragDropRelease(GameObject surface)
    {
        if (!cloneOnDrag)
        {
            // Re-enable the collider
            if (mButton != null) mButton.isEnabled = true;
            else if (mCollider != null) mCollider.enabled = true;
            else if (mCollider2D != null) mCollider2D.enabled = true;

            // Is there a droppable container?
            UIDragDropContainer container = surface ? NGUITools.FindInParents<UIDragDropContainer>(surface) : null;

            if (container != null)
            {
                Debug.Log(surface.name);
                // Container found -- parent this object to the container
                if (surface.name == "makingslot")
                {
                    if(surface.transform.childCount > 0 )
                    {
                        Transform targetTransfrom;

                        targetTransfrom = surface.transform.GetChild(0);

                        if (targetTransfrom.GetComponent<CardInfo>().tier == 5)
                        {
                            targetTransfrom.parent = Tier5.transform;
                            targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier5.transform.GetChild(0));
                        }
                        else if (targetTransfrom.GetComponent<CardInfo>().tier == 4)
                        {
                            targetTransfrom.parent = Tier4.transform;
                            targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier4.transform.GetChild(0));
                        }
                        else if (targetTransfrom.GetComponent<CardInfo>().tier == 3)
                        {
                            targetTransfrom.parent = Tier3.transform;
                            targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier3.transform.GetChild(0));
                        }
                        else if (targetTransfrom.GetComponent<CardInfo>().tier == 2)
                        {
                            targetTransfrom.parent = Tier2.transform;
                            targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier2.transform.GetChild(0));
                        }
                        else if (targetTransfrom.GetComponent<CardInfo>().tier == 1)
                        {
                            targetTransfrom.parent = Tier1.transform;
                            targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier1.transform.GetChild(0));
                        }

                    }


                    mTrans.parent = (container.reparentTarget != null) ? container.reparentTarget : container.transform;

                    //Vector3 pos = mTrans.localPosition;
                    //Vector3 pos = mTrans.parent.position; //부모의 위치로 자신의 위치를 수정
                    Vector3 pos = mTrans.parent.position;
                    pos.z = 0f;
                    mTrans.localPosition = pos;

                    surface.GetComponent<CreationCardSlotManager>().SetNumOfMyResourcse(GetComponent<CardInfo>().tier);

                   


                }
                else if (surface.transform.parent.name == "makingslot")
                {
                   
                    //Debug.Log(surface.transform.GetChild(0));
                    Transform targetTransfrom;

                    targetTransfrom = surface.transform;  // 슬롯이 가지고 있는 기존 자식

                    //targetTransfrom.parent = mParent;  //기존 자식의 부모를  그리드로 바꾼다.

                    if(targetTransfrom.GetComponent<CardInfo>().tier == 5)
                    {
                        targetTransfrom.parent = Tier5.transform;
                        targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier5.transform.GetChild(0));
                    }
                    else if (targetTransfrom.GetComponent<CardInfo>().tier == 4)
                    {
                        targetTransfrom.parent = Tier4.transform;
                        targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier4.transform.GetChild(0));
                    }
                    else if (targetTransfrom.GetComponent<CardInfo>().tier == 3)
                    {
                        targetTransfrom.parent = Tier3.transform;
                        targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier3.transform.GetChild(0));
                    }
                    else if (targetTransfrom.GetComponent<CardInfo>().tier == 2)
                    {
                        targetTransfrom.parent = Tier2.transform;
                        targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier2.transform.GetChild(0));
                    }
                    else if (targetTransfrom.GetComponent<CardInfo>().tier == 1)
                    {
                        targetTransfrom.parent = Tier1.transform;
                        targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(Tier1.transform.GetChild(0));
                    }





                    targetTransfrom.GetComponent<DragAndDropMakingCard>().ResetPosition(mParent.GetChild(0));

                    Vector3 pos = targetTransfrom.position;
                    pos.z = 0;
                    targetTransfrom.position = pos;

                    //Vector3 pos = mTrans.parent.position;
                    //pos.z = 0f;
                    //mTrans.localPosition = pos;


                    mTrans.parent = (container.reparentTarget != null) ? container.reparentTarget : container.transform;

                    //Vector3 pos = mTrans.localPosition;
                    //Vector3 pos = mTrans.parent.position; //부모의 위치로 자신의 위치를 수정
                    pos = mTrans.parent.position;
                    pos.z = 0f;
                    mTrans.localPosition = pos;

                    
                    GameObject.Find("makingslot").GetComponent<CreationCardSlotManager>().SetNumOfMyResourcse(GetComponent<CardInfo>().tier);

                }
                else
                {
                    if(container.reparentTarget != null)
                    {
                        if (mTrans.GetComponent<CardInfo>().tier == 5)
                            mTrans.parent = Tier5.transform;
                        else if (mTrans.GetComponent<CardInfo>().tier == 4)
                            mTrans.parent = Tier4.transform;
                        else if (mTrans.GetComponent<CardInfo>().tier == 3)
                            mTrans.parent = Tier3.transform;
                        else if (mTrans.GetComponent<CardInfo>().tier == 2)
                            mTrans.parent = Tier2.transform;
                        else if (mTrans.GetComponent<CardInfo>().tier == 1)
                            mTrans.parent = Tier1.transform;
                    }
                    else
                    {
                        mTrans.parent = container.transform;
                    }

                    //mTrans.parent = (container.reparentTarget != null) ? container.reparentTarget : container.transform;

                    Vector3 pos = mTrans.localPosition;
                    pos.z = 0f;
                    mTrans.localPosition = pos;


                }
            }
            else
            {

                // No valid container under the mouse -- revert the item's parent
                if (mParent.GetComponent<UIGrid>() == null)
                {
                    mTrans.parent = mParent;
                    mTrans.localPosition = mTrans.parent.position;

                }
                else
                {
                    mTrans.parent = mParent;
                    mTrans.localPosition = mParent.position;
                }
            }

            // Update the grid and table references
            mParent = mTrans.parent;


            mGrid = NGUITools.FindInParents<UIGrid>(mParent);

            mTable = NGUITools.FindInParents<UITable>(mParent);


            // Re-enable the drag scroll view script
            if (mDragScrollView != null)
                Invoke("EnableDragScrollView", 0.001f);

            // Notify the widgets that the parent has changed
            NGUITools.MarkParentAsChanged(gameObject);

            if (mTable != null) mTable.repositionNow = true;
            if (mGrid != null) mGrid.repositionNow = true;
        }
        else NGUITools.Destroy(gameObject);

        // We're now done
        OnDragDropEnd();
    }


}