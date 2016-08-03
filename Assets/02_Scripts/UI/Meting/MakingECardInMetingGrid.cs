using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class MakingECardInMetingGrid : MonoBehaviour
{

    //카드 종류 20가지 입력
    public GameObject prefab;
    
    
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




                    if (reader.GetInt32(7) == 1)
                        continue;

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
                    else if (reader.GetInt32(6) == 2)
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



                    // 라벨을 설정해준다.
                    UILabel label1 = obj.transform.GetChild(0).GetComponent<UILabel>();
                    UILabel label2 = obj.transform.GetChild(1).GetComponent<UILabel>();
                    label1.text = "극대화 확률 + " + reader.GetFloat(4) * 100 + "%\n"
                        + "데미지 증가 + " + reader.GetInt32(3) + "\n"
                        + "극대화 데미지 + " + reader.GetFloat(5) * 100 + "%\n"
                        + "쉴드 증가량 + " + reader.GetInt32(2);

                    label2.text = "\n\n\n\n\n\n\n\n       등급 : " + reader.GetInt32(8) + "티어";




                    // 카드 데이터 넣기



                    obj.GetComponent<Card>().idx = reader.GetInt32(0);
                    obj.GetComponent<Card>().cardId = reader.GetInt32(1);
                    obj.GetComponent<Card>().energy = reader.GetInt32(2);
                    obj.GetComponent<Card>().power = reader.GetInt32(3);
                    obj.GetComponent<Card>().criticalRate = reader.GetFloat(4);
                    obj.GetComponent<Card>().criticalDamage = reader.GetFloat(5);
                    obj.GetComponent<Card>().type = reader.GetInt32(6);
                    obj.GetComponent<Card>().IsUsing = reader.GetBoolean(7);



                  
                        obj.transform.parent = this.transform;
                        obj.transform.localPosition = new Vector3(0f, 0f, 0f);
                        obj.transform.localScale = new Vector3(1f, 1f, 1f);
                   

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
        

        foreach (Transform child in childs)
        {
            if (child.name == "UIGrid")
                continue;
            Destroy(child.gameObject);
        }
    }

    public void DeleteCard()
    {
        Transform[] childs = transform.GetComponentsInChildren<Transform>();
        

        foreach (Transform child in childs)
        {
            if (child.name == "UIGrid")
                continue;
            Destroy(child.gameObject);
        }
    }
}