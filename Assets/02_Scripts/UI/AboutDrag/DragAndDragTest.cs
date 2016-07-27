using UnityEngine;

[AddComponentMenu("NGUI/Examples/Drag and Drop Item (Example)")]
public class DragAndDragTest : UIDragDropItem
{
    /// <summary>
    /// Prefab object that will be instantiated on the DragDropSurface if it receives the OnDrop event.
    /// </summary>

    public GameObject prefab;
    public Transform CardGrid;
    public Transform Slot;

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
                if (surface.name == "Slot1" || surface.name == "Slot2" || surface.name == "Slot3" )
                {
                    mTrans.parent = (container.reparentTarget != null) ? container.reparentTarget : container.transform;

                    //Vector3 pos = mTrans.localPosition;
                    //Vector3 pos = mTrans.parent.position; //부모의 위치로 자신의 위치를 수정
                    Vector3 pos = new Vector3(mTrans.parent.position.x - 5f, mTrans.parent.position.y + 5f, mTrans.parent.position.z);
                    pos.z = 0f;
                    mTrans.localPosition = pos;

                    DBManager.Instance.SetCardUsing(mTrans.GetComponent<Card>().idx, true);  //  사용중으로 변경

                    GameObject.Find("UIManager").GetComponent<SetPlayerStat>().SetStat();


                }
                else if (surface.transform.parent.name == "Slot1" || surface.transform.parent.name == "Slot2" || surface.transform.parent.name == "Slot3" )                     
                {
                    //Debug.Log(surface.transform.GetChild(0));
                    Transform targetTransform;

                    targetTransform = surface.transform;  // 슬롯이 가지고 있는 기존 자식

                    targetTransform.parent = mParent;  //기존 자식의 부모를  그리드로 바꾼다.

                    targetTransform.GetComponent<DragAndDragTest>().ResetPosition(mParent.GetChild(0));

                    mTrans.parent = (container.reparentTarget != null) ? container.reparentTarget : container.transform;

                    //Vector3 pos = mTrans.localPosition;
                    //Vector3 pos = mTrans.parent.position; //부모의 위치로 자신의 위치를 수정
                    Vector3 pos = new Vector3(mTrans.parent.position.x - 5f, mTrans.parent.position.y + 5f, mTrans.parent.position.z);
                    pos.z = 0f;
                    mTrans.localPosition = pos;

                    DBManager.Instance.SetCardUsing(mTrans.GetComponent<Card>().idx, true);  //  사용중으로 변경
                    DBManager.Instance.SetCardUsing(targetTransform.GetComponent<Card>().idx, false);
                    Debug.Log(mTrans.GetComponent<Card>().idx);

                    GameObject.Find("UIManager").GetComponent<SetPlayerStat>().SetStat();
                }
                else
                {
                    
                    mTrans.parent = (container.reparentTarget != null) ? container.reparentTarget : container.transform;

                    //Vector3 pos = mTrans.localPosition;
                    //Vector3 pos = mTrans.parent.position; //부모의 위치로 자신의 위치를 수정
                    //pos.z = 0f;
                    Quaternion rotation = Quaternion.Euler(0f, -8f, 0);
                    mTrans.localRotation = rotation;

                    DBManager.Instance.SetCardUsing(mTrans.GetComponent<Card>().idx, false);  //  비사용중으로 변경

                    GameObject.Find("UIManager").GetComponent<SetPlayerStat>().SetStat();
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
                    mTrans.parent = mParent;
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