using UnityEngine;
using System.Collections;

public class MakeCard : MonoBehaviour {

    public GameObject slot;
    public GameObject grid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
	
	}

    public void MakeCardStart()
    {
        if (slot.transform.childCount > 0)
        {
            Transform card = slot.transform.GetChild(0).transform;
            card.parent = grid.transform;

            Vector3 pos = card.localPosition;
            pos.z = 0f;
            card.localPosition = pos;

            card.GetComponent<DragAndDropMakingCard>().ResetPosition(grid.transform.GetChild(0));

            DBManager.Instance.MakeCard(card);
        }
    }
}
