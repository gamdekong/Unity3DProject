using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class MakingCardInMeltingGrid3 : MonoBehaviour
{

    //카드 종류 20가지 입력


    public GameObject prefab;


    void Start()
    {

    }

    public void CardSet()
    {
        int numOfResource = DBManager.Instance.GetNumOfResource();


        // 디비에 연결
        IDbConnection dbConnection = DBManager.Instance.GetConnetciont();

        dbConnection.Open();

        using (IDbCommand dbCmd = dbConnection.CreateCommand())
        {
            string sqlQuery = "SELECT * FROM myresource";

            dbCmd.CommandText = sqlQuery;



            using (IDataReader reader = dbCmd.ExecuteReader())
            {



                for (int i = 0; i < numOfResource; i++)
                {
                    reader.Read();  //디비 순서대로 실행


                    //if (slot1.transform.childCount > 0)
                    //{
                    //    if (slot1.transform.GetChild(0).GetComponent<Card>().idx == reader.GetInt32(0))
                    //    {
                    //        continue;

                    //    }
                    //}



                    // 오브젝트를 생성한 뒤 부모를 설정해준다.
                    if (reader.GetInt32(1) == 0)
                        continue;
                    if (reader.GetInt32(2) != 3)
                        continue;

                    GameObject obj = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
                    //obj.transform.parent = this.transform;
                    obj.name = "Resource" + i;



                    //sprite 설정
                    //test.text = reader.GetInt32(1).ToString();   //개수로 바꾸기
                    if (reader.GetInt32(0) == 115 || reader.GetInt32(0) == 114 || reader.GetInt32(0) == 113 || reader.GetInt32(0) == 112 || reader.GetInt32(0) == 111)
                    {
                        obj.GetComponent<UISprite>().spriteName = "titanium";
                    }
                    else if (reader.GetInt32(0) == 125 || reader.GetInt32(0) == 124 || reader.GetInt32(0) == 123 || reader.GetInt32(0) == 122 || reader.GetInt32(0) == 121)
                    {
                        obj.GetComponent<UISprite>().spriteName = "uranium";
                    }
                    else if (reader.GetInt32(0) == 135 || reader.GetInt32(0) == 134 || reader.GetInt32(0) == 133 || reader.GetInt32(0) == 132 || reader.GetInt32(0) == 131)
                    {
                        obj.GetComponent<UISprite>().spriteName = "ruderpodium";
                    }
                    else if (reader.GetInt32(0) == 145 || reader.GetInt32(0) == 144 || reader.GetInt32(0) == 143 || reader.GetInt32(0) == 142 || reader.GetInt32(0) == 141)
                    {
                        obj.GetComponent<UISprite>().spriteName = "plutonium";
                    }


                    //    switch (reader.GetInt32(6))
                    //{
                    //    case 1:

                    //        break;
                    //    case 2:
                    //        test.text = "크리티컬 카드 부름";

                    //        break;
                    //    case 3:

                    //        break;
                    //    case 4:

                    //        break;
                    //    default:
                    //        break;

                    //}


                    // 라벨을 설정해준다.
                    UILabel label1 = obj.transform.GetChild(0).GetComponent<UILabel>();
                    UILabel label2 = obj.transform.GetChild(1).GetComponent<UILabel>();
                    label2.text = reader.GetInt32(1).ToString();


                    label1.text = reader.GetInt32(2).ToString() + "등급";




                    // 카드 데이터 넣기

                    obj.GetComponent<Resource>().resourceId = reader.GetInt32(0);
                    obj.GetComponent<Resource>().numOfResource = reader.GetInt32(1);
                    obj.GetComponent<Resource>().tier = reader.GetInt32(2);
                    obj.GetComponent<Resource>().plazma = reader.GetInt32(3);
                    //obj.GetComponent<Card>().idx = reader.GetInt32(0);
                    //obj.GetComponent<Card>().cardId = reader.GetInt32(1);
                    //obj.GetComponent<Card>().energy = reader.GetInt32(2);
                    //obj.GetComponent<Card>().power = reader.GetInt32(3);
                    //obj.GetComponent<Card>().criticalRate = reader.GetFloat(4);
                    //obj.GetComponent<Card>().criticalDamage = reader.GetFloat(5);
                    //obj.GetComponent<Card>().type = reader.GetInt32(6);
                    //obj.GetComponent<Card>().IsUsing = reader.GetBoolean(7);



                    //어느 부모에 넣을꺼냐
                    //if (obj.GetComponent<Card>().IsUsing == false)
                    //{
                    obj.transform.parent = this.transform;
                    obj.transform.localPosition = new Vector3(0f, 0f, 0f);
                    obj.transform.localScale = new Vector3(1f, 1f, 1f);
                    //}
                    //else
                    //{
                    //    if (slot1.transform.childCount == 0)
                    //    {
                    //        obj.transform.parent = slot1.transform;
                    //        obj.GetComponent<UIPlayTween>().Play(true);
                    //        Vector3 pos = new Vector3(slot1.transform.position.x - 5f, slot1.transform.position.y + 5f, 0);
                    //        obj.transform.localPosition = pos;


                    //    }

                    //    else
                    //        Debug.Log("빈슬롯이 없는데 사용중 에러");
                    //}
                    // NGUI 오브젝트이므로 localPosition과 localScale을 초기화해주자.

                    obj.transform.localRotation = transform.localRotation;

                }











                //모두 출력후 디비 닫기
                dbConnection.Close();
                reader.Close();

                // return reader.FieldCount;







            }

        }




        // 그리드를 리셋해준다.
        GetComponent<UIGrid>().Reposition();

        // 스크롤 뷰를 리셋해준다.
        GetComponentInParent<UIScrollView>().ResetPosition();
    }


    void OnEnable()
    {
        CardSet();
    }

    void OnDisable()
    {
        Transform[] childs = transform.GetComponentsInChildren<Transform>();
        Debug.Log(childs[0]);

        foreach (Transform child in childs)
        {
            if (child.name == "UIGrid")
                continue;
            Destroy(child.gameObject);
        }

    }

    public void Delete()
    {
        Transform[] childs = transform.GetComponentsInChildren<Transform>();
        Debug.Log(childs[0]);

        foreach (Transform child in childs)
        {
            if (child.name == "UIGrid")
                continue;
            Destroy(child.gameObject);
        }
    }
}