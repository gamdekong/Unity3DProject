using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class MakingCardInGrid : MonoBehaviour
{

    //카드 종류 20가지 입력
    public GameObject prefab;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public UILabel test;


    void Start()
    {
        
    }

    public void CardSet()
    {
        int numOfCard = DBManager.Instance.GetNumOfCard();


        // 디비에 연결
        IDbConnection dbConnection = DBManager.Instance.GetConnetciont();

        dbConnection.Open();

        using (IDbCommand dbCmd = dbConnection.CreateCommand())
        {
            string sqlQuery = "SELECT * FROM mycard";

            dbCmd.CommandText = sqlQuery;



            using (IDataReader reader = dbCmd.ExecuteReader())
            {
                


                for (int i = 0; i < numOfCard; i++)
                {
                    reader.Read();  //디비 순서대로 실행
                    
                    
                    if (slot1.transform.childCount > 0 )
                    {
                        if (slot1.transform.GetChild(0).GetComponent<Card>().idx == reader.GetInt32(0))
                        {
                            continue;

                        }
                    }
                    if (slot2.transform.childCount > 0)
                    {
                        if (slot2.transform.GetChild(0).GetComponent<Card>().idx == reader.GetInt32(0))
                        {
                            continue;

                        }
                    }
                    if (slot3.transform.childCount > 0)
                    {
                        if (slot3.transform.GetChild(0).GetComponent<Card>().idx == reader.GetInt32(0))
                        {
                            continue;

                        }
                    }
                    

                    // 오브젝트를 생성한 뒤 부모를 설정해준다.
                    GameObject obj = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
                    //obj.transform.parent = this.transform;
                    obj.name = "Card" + i;

                    

                    //sprite 설정
                    //test.text = reader.GetInt32(6).ToString();
                    if (reader.GetInt32(6) == 1)
                    {
                        obj.GetComponent<UISprite>().spriteName = "damageCard";
                    }
                    else if(reader.GetInt32(6) == 2)
                    {
                        obj.GetComponent<UISprite>().spriteName = "energyCard";
                    }
                    else if (reader.GetInt32(6) == 3)
                    {
                        obj.GetComponent<UISprite>().spriteName = "CriticalRateCard";
                    }
                    else if (reader.GetInt32(6) == 4)
                    {
                        obj.GetComponent<UISprite>().spriteName = "criticalDamageCard";
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
                    label1.text = "극대화 확률 + " + reader.GetFloat(4) * 100 + "%\n"
                        + "데미지 증가 + " + reader.GetInt32(3) + "\n"
                        + "극대화 데미지 + " + reader.GetFloat(5)*100 + "%\n"
                        + "쉴드 증가량 + " + reader.GetInt32(2);

                    label2.text = "\n\n\n\n\n\n\n\n\n\n\n        등급 : " + reader.GetInt32(8)+"티어";




                    // 카드 데이터 넣기



                    obj.GetComponent<Card>().idx = reader.GetInt32(0);
                    obj.GetComponent<Card>().cardId = reader.GetInt32(1);
                    obj.GetComponent<Card>().energy = reader.GetInt32(2);
                    obj.GetComponent<Card>().power = reader.GetInt32(3);
                    obj.GetComponent<Card>().criticalRate = reader.GetFloat(4);
                    obj.GetComponent<Card>().criticalDamage = reader.GetFloat(5);
                    obj.GetComponent<Card>().type = reader.GetInt32(6);
                    obj.GetComponent<Card>().IsUsing = reader.GetBoolean(7);



                    //어느 부모에 넣을꺼냐
                    if (obj.GetComponent<Card>().IsUsing == false)
                    {
                        obj.transform.parent = this.transform;
                        obj.transform.localPosition = new Vector3(0f, 0f, 0f);
                        obj.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else
                    {
                        if (slot1.transform.childCount == 0)
                        {
                            obj.transform.parent = slot1.transform;
                            obj.GetComponent<UIPlayTween>().Play(true);
                            Vector3 pos = new Vector3(slot1.transform.position.x - 5f, slot1.transform.position.y + 5f, 0);
                            obj.transform.localPosition = pos;
                           

                        }
                        else if (slot2.transform.childCount == 0)
                        {
                            obj.transform.parent = slot2.transform;
                            obj.GetComponent<UIPlayTween>().Play(true);
                            Vector3 pos = new Vector3(slot2.transform.position.x - 5f, slot2.transform.position.y + 5f, 0);
                            obj.transform.localPosition = pos;
                        }
                        else if (slot3.transform.childCount == 0)
                        {
                            obj.transform.parent = slot3.transform;
                            obj.GetComponent<UIPlayTween>().Play(true);
                            Vector3 pos = new Vector3(slot3.transform.position.x - 5f, slot3.transform.position.y + 5f, 0);
                            obj.transform.localPosition = pos;
                        }
                        else
                            Debug.Log("빈슬롯이 없는데 사용중 에러");
                    }
                    // NGUI 오브젝트이므로 localPosition과 localScale을 초기화해주자.
                    
                    //  obj.transform.localRotation = transform.localRotation;

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

        foreach(Transform child in childs )
        {
            if (child.name == "UIGrid")
                continue;
            Destroy(child.gameObject);
        }
    }
}