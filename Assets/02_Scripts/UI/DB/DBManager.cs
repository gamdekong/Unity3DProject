using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DBManager : Singleton<DBManager> {

    private string m_ConnectionString;
    int randomSeeds;

    int cardId;
    int type;
    int power;
    int energy;
    float criticalRate;
    float criticalDamage;
    float cardTier;
    int tmp;

    // Use this for initialization
    void Awake()
    {
        randomSeeds = (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.seed = randomSeeds;
        
        string m_SQLiteFileName = "PlayerData.sqlite";
        string conn;

#if UNITY_EDITOR
        m_ConnectionString = "URI=file:" + Application.streamingAssetsPath + "/" + m_SQLiteFileName;
        //m_ConnectionString = "URI=file:" + Application.dataPath + "/" + m_SQLiteFileName;
#else
            // check if file exists in Application.persistentDataPath
            var filepath = string.Format("{0}/{1}", Application.persistentDataPath, m_SQLiteFileName);

            if (!File.Exists(filepath))
            {
                // if it doesn't ->
                // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
                WWW loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + m_SQLiteFileName);  // this is the path to your StreamingAssets in android
                loadDb.bytesDownloaded.ToString();
                while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
                // then save to Application.persistentDataPath
                File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                     var loadDb = Application.dataPath + "/Raw/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
                    // then save to Application.persistentDataPath
                    File.Copy(loadDb, filepath);
#elif UNITY_WP8
                    var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
                    // then save to Application.persistentDataPath
                    File.Copy(loadDb, filepath);
#elif UNITY_WINRT
      var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
      // then save to Application.persistentDataPath
      File.Copy(loadDb, filepath);
#else
     var loadDb = Application.dataPath + "/StreamingAssets/" + m_SQLiteFileName;  // this is the path to your StreamingAssets in iOS
     // then save to Application.persistentDataPath
     File.Copy(loadDb, filepath);

#endif
            }

            m_ConnectionString = "URI=file:" + filepath;
#endif

        ///////////////////////////////////////////////////////////////////[DB Path]
       // if (Application.platform == RuntimePlatform.Android)
       // {
      //      conn = "URI=file:" + Application.persistentDataPath + "/PlayerData.sqlite"; //Path to databse on Android
       // }
      //  else { conn = "URI=file:" + Application.streamingAssetsPath + "/PlayerData.sqlite"; } //Path to database Else
                                                                                            ///////////////////////////////////////////////////////////////////[DB Path]


        /////////////////////////////////////////////////////////////////////[DB Connection]
        //IDbConnection dbconn;
        //dbconn = (IDbConnection)new SqliteConnection(conn);
        //dbconn.Open(); //Open connection to the database.
        /////////////////////////////////////////////////////////////////////[DB Connection]


        /////////////////////////////////////////////////////////////////////[DB Query]
        //IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery = "SELECT * " + "FROM TestTable";
        //dbcmd.CommandText = sqlQuery;
        /////////////////////////////////////////////////////////////////////[DB Query]

        /////////////////////////////////////////////////////////////////////[Data Read]
        //IDataReader reader = dbcmd.ExecuteReader();
        //while (reader.Read())
        //{
        //    int value = reader.GetInt32(0);
        //    string name = reader.GetString(1);

        //    Debug.Log("value= " + value + "  name =" + name);
        //}
        /////////////////////////////////////////////////////////////////////[Data Read]

        /////////////////////////////////////////////////////////////////////[DB Connection Close]
        //reader.Close();
        //reader = null;
        //dbcmd.Dispose();
        //dbcmd = null;
        //dbconn.Close();
        //dbconn = null;
        /////////////////////////////////////////////////////////////////////[DB Connection Close]

    }

    // Update is called once per frame
    void Update () {
	
	}

    private void InsertScore(int ID, String name, int Tier, String Type)
    {
        
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("insert into card(ID, Name, Tier, Type) values(\"{0}\",\"{1}\",\"{2}\",\"{3}\");",ID, name,  Tier, Type);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();


                              

            }
        }
    }

    private void GetScroes()
    {
        
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "select * from Card;";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));


                    }
                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                }

            }
        }

     }

    private void DeleteScore(int order)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "delete from card where \"Order\" = " + order;
                Debug.Log(sqlQuery);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }



    public int GetNumOfCard()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT count(*) from mycard;";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(0);

                    
                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                   // return reader.FieldCount;

                }

            }
        }
    }

    public int GetNumOfResource()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT count(*) from myresource;";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    int a = reader.GetInt32(0);
                    


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();
                    return a;
                    // return reader.FieldCount;

                }

            }
        }
    }

    public IDbConnection GetConnetciont()
    {
        IDbConnection dbConnection = new SqliteConnection(m_ConnectionString);
        return dbConnection;
       
           
       
    }
    public int GetPlayerLevel()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(0);  //level


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public int GetNumOfResourceOnId(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "select numofresource from myresource where resourceid =" + id;

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(0);  //StatPoint


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }


    public void setResourceOnId(int id,int amount)
    {

        int pastResource = GetNumOfResourceOnId(id);

        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {


                string sqlQuery = "UPDATE main.Player SET plazma =" + amount +pastResource;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                dbConnection.Close();




            }
            dbConnection.Close();
        }
    }

    public int GetPlayerStat()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(7);  //StatPoint


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public int GetPlayerTier()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(1);  //에너지


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public int GetPlayerStage()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(9);  //스테이지


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public int GetPlayerPlazma()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(8);  //플라즈마


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public int GetPlazmaOnResourceId(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "select * from resourcedata where resourceid ="+ id;

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(3);  //플라즈마


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public int GetPlayerEnergy()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(2);  //에너지


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }
    public int GetPlayerDamage()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(3);  //에너지


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }

    }
    public float GetPlayerCriticalRate()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetFloat(4);  //에너지


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }
    public float GetPlayerCriticalDamage()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from player";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetFloat(5);  //에너지


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public int GetPlayerBasicEnergy()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from basicplayerstat";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(1);  //basicEnergy


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }
    public int GetPlayerBasicDamage()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from basicplayerstat";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(2);  //basicDamgae


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }
    public float GetPlayerBasicCriticalRate()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from basicplayerstat";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetFloat(3);  //basicCriRate


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }
    public float GetPlayerBasicCriticalDamage()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from basicplayerstat";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetFloat(4);  //basicCriDamage


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public int GetCardSlotEnergy()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from cardslot";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(1);  //cardslot Energy


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }
    public int GetCardSlotDamage()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from cardslot";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetInt32(2);  //cardslot Damage


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public float GetCardSlotCriRate()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from cardslot";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetFloat(3);  //cardslot cri


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public float GetCardSlotCriDamage()
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from cardslot";

                dbCmd.CommandText = sqlQuery;



                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
                    reader.Read();
                    return reader.GetFloat(4);  //cardslot Energy


                    //모두 출력후 디비 닫기
                    dbConnection.Close();
                    reader.Close();

                    // return reader.FieldCount;

                }

            }
        }
    }

    public void SetPlayerStat(int energy, int damage, float rate, float cdamage)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {


                string sqlQuery = "UPDATE main.Player SET damage = " + damage;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                sqlQuery = "UPDATE main.Player SET energy = " + energy;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                sqlQuery = "UPDATE main.Player SET criticalRate = " + rate;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                sqlQuery = "UPDATE main.Player SET criticalDamage = " + cdamage;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                dbConnection.Close();




            }
            dbConnection.Close();
        }
    }

    public void SetPlayerPlazma(int plazma)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {


                string sqlQuery = "UPDATE main.Player SET plazma =" + plazma;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                
                dbConnection.Close();




            }
            dbConnection.Close();
        }
    }

    public void DeletePlayerResource(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {


                string sqlQuery = "UPDATE main.myresource SET numofresource = 0 WHERE  resourceID =" + id;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                dbConnection.Close();




            }
            dbConnection.Close();
        }
    }

    public void SetCardSlotStat(int energy, int damage, float rate, float cdamage)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {


                string sqlQuery = "UPDATE main.cardslot SET damage = " + damage;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                sqlQuery = "UPDATE main.cardslot SET energy = " + energy;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                sqlQuery = "UPDATE main.cardslot SET crirate = " + rate;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                sqlQuery = "UPDATE main.cardslot SET cridamage = " + cdamage;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                dbConnection.Close();
                




            }
            
        }
    }


    public void SetPlayerEnergy(int energy)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.Player SET energy = "+energy;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }
    public void SetPlayerDamage(int damage)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                Debug.Log(damage);
                string sqlQuery = "UPDATE main.Player SET damage = " +damage;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }
    public void SetPlayerCriticalRate(float rate)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.Player SET damage = " + rate;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }
    public void SetPlayerCriticalDamage(float damageRate)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.Player SET damage = " + damageRate;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }

    public void IncreaseStage(float damageRate)
    {

        int nowStage = GetPlayerStage();
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.Player SET stage = " + nowStage+1;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }

    public void SetCardUsing(int idx, bool isUsing)
    {
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery;
                if (isUsing)
                {
                    sqlQuery = "UPDATE main.mycard SET isusing = 1 WHERE  idx = " + idx;
                }
                else
                    sqlQuery = "UPDATE main.mycard SET isusing = 0 WHERE  idx = " + idx;
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }
   
    public void MakeCard(Transform card)
    {


       


        CardInfo cardinfo = card.GetComponent<CardInfo>();
        cardId = cardinfo.cardId;
        type = cardinfo.type;
        cardTier = cardinfo.tier;

        if (cardId == 215)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                energy = UnityEngine.Random.Range(30, 39);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                energy = UnityEngine.Random.Range(39, 47);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                energy = UnityEngine.Random.Range(47, 56);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                energy = UnityEngine.Random.Range(56, 74);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                energy = UnityEngine.Random.Range(74, 82);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                energy = UnityEngine.Random.Range(82, 91);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                energy = UnityEngine.Random.Range(91, 101);
            }

            power = cardinfo.AminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;

        }
        else if (cardId == 214)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                energy = UnityEngine.Random.Range(79, 102);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                energy = UnityEngine.Random.Range(102, 125);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                energy = UnityEngine.Random.Range(125, 148);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                energy = UnityEngine.Random.Range(148, 194);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                energy = UnityEngine.Random.Range(194, 217);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                energy = UnityEngine.Random.Range(217, 240);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                energy = UnityEngine.Random.Range(240, 264);
            }

            power = cardinfo.AminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 213)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                energy = UnityEngine.Random.Range(208, 269);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                energy = UnityEngine.Random.Range(269, 329);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                energy = UnityEngine.Random.Range(329, 390);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                energy = UnityEngine.Random.Range(390, 510);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                energy = UnityEngine.Random.Range(511, 571);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                energy = UnityEngine.Random.Range(572, 633);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                energy = UnityEngine.Random.Range(633, 694);
            }

            power = cardinfo.AminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 212)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                energy = UnityEngine.Random.Range(548, 708);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                energy = UnityEngine.Random.Range(708, 867);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                energy = UnityEngine.Random.Range(867, 1027);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                energy = UnityEngine.Random.Range(1027, 1347);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                energy = UnityEngine.Random.Range(1347, 1507);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                energy = UnityEngine.Random.Range(1507, 1666);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                energy = UnityEngine.Random.Range(1666, 1827);
            }

            power = cardinfo.AminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 211)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                energy = UnityEngine.Random.Range(1461, 1887);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                energy = UnityEngine.Random.Range(1887, 2313);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                energy = UnityEngine.Random.Range(2313, 2739);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                energy = UnityEngine.Random.Range(2739, 3591);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                energy = UnityEngine.Random.Range(3591, 4017);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                energy = UnityEngine.Random.Range(4017, 4443);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                energy = UnityEngine.Random.Range(4443, 4870);
            }

            power = cardinfo.AminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 225)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                power = UnityEngine.Random.Range(30, 39);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                power = UnityEngine.Random.Range(39, 47);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                power = UnityEngine.Random.Range(47, 56);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                power = UnityEngine.Random.Range(56, 74);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                power = UnityEngine.Random.Range(74, 82);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                power = UnityEngine.Random.Range(82, 91);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                power = UnityEngine.Random.Range(91, 101);
            }

            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 224)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                power = UnityEngine.Random.Range(79, 102);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                power = UnityEngine.Random.Range(102, 125);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                power = UnityEngine.Random.Range(125, 148);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                power = UnityEngine.Random.Range(148, 194);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                power = UnityEngine.Random.Range(194, 217);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                power = UnityEngine.Random.Range(217, 240);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                power = UnityEngine.Random.Range(240, 264);
            }

            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 223)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                power = UnityEngine.Random.Range(208, 269);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                power = UnityEngine.Random.Range(269, 329);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                power = UnityEngine.Random.Range(329, 390);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                power = UnityEngine.Random.Range(390, 510);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                power = UnityEngine.Random.Range(511, 571);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                power = UnityEngine.Random.Range(572, 633);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                power = UnityEngine.Random.Range(633, 694);
            }

            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 222)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                power = UnityEngine.Random.Range(548, 708);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                power = UnityEngine.Random.Range(708, 867);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                power = UnityEngine.Random.Range(867, 1027);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                power = UnityEngine.Random.Range(1027, 1347);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                power = UnityEngine.Random.Range(1347, 1507);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                power = UnityEngine.Random.Range(1507, 1666);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                power = UnityEngine.Random.Range(1666, 1827);
            }

            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 221)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                power = UnityEngine.Random.Range(1461, 1887);
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                power = UnityEngine.Random.Range(1887, 2313);
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                power = UnityEngine.Random.Range(2313, 2739);
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                power = UnityEngine.Random.Range(2739, 3591);
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                power = UnityEngine.Random.Range(3591, 4017);
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                power = UnityEngine.Random.Range(4017, 4443);
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                power = UnityEngine.Random.Range(4443, 4870);
            }

            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;
            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 235)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(50, 65);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(65, 79);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(79, 94);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(94, 123);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(123, 137);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(137, 152);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(152, 168);
                criticalRate = ((float)tmp) / 10000;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;

            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 234)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(133, 172);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(172, 211);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(211, 250);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(250, 328);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(328, 367);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(367, 406);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(406, 445);
                criticalRate = ((float)tmp) / 10000;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;

            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 233)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(356, 459);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(459, 563);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(563, 667);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(667, 874);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(874, 978);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(978, 1081);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(1081, 1186);
                criticalRate = ((float)tmp) / 10000;
            }


            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;

            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 232)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(1067, 1267);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(1267, 1467);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(1467, 1667);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(1667, 2067);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(2067, 2267);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(2267, 2467);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(2467, 2268);
                criticalRate = ((float)tmp) / 10000;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;

            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 231)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(2400, 2850);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(2850, 3300);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(3300, 3650);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(3650, 4550);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(4550, 5100);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(5100, 5550);
                criticalRate = ((float)tmp) / 10000;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(5550, 6001);
                criticalRate = ((float)tmp) / 10000;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;

            criticalDamage = cardinfo.DminF;
        }
        else if (cardId == 245)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(103, 109);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(109, 115);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(115, 122);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(122, 135);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(135, 141);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(141, 148);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(148, 154);
                criticalDamage = ((float)tmp) / 100;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;

        }
        else if (cardId == 244)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(122, 129);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(129, 137);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(137, 144);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(144, 160);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(160, 167);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(167, 175);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(175, 184);
                criticalDamage = ((float)tmp) / 100;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;

        }
        else if (cardId == 243)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(144, 153);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(153, 162);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(162, 171);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(171, 189);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(189, 198);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(198, 207);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(207, 217);
                criticalDamage = ((float)tmp) / 100;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;

        }
        else if (cardId == 242)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(171, 182);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(182, 192);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(192, 203);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(203, 224);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(224, 235);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(235, 246);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(246, 258);
                criticalDamage = ((float)tmp) / 100;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;

        }
        else if (cardId == 241)
        {
            int num = UnityEngine.Random.Range(0, 100);

            if (num >= 0 && num <= 4)  // 5%
            {
                tmp = UnityEngine.Random.Range(205, 218);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 5 && num <= 14)  // 10%
            {
                tmp = UnityEngine.Random.Range(218, 231);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 15 && num <= 29)  //  15%
            {
                tmp = UnityEngine.Random.Range(231, 244);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 30 && num <= 69)  //  40%
            {
                tmp = UnityEngine.Random.Range(244, 269);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 70 && num <= 84)  //  15%
            {
                tmp = UnityEngine.Random.Range(269, 282);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 85 && num <= 94)  //  10%
            {
                tmp = UnityEngine.Random.Range(282, 295);
                criticalDamage = ((float)tmp) / 100;
            }
            else if (num >= 95 && num <= 99)  //  5%
            {
                tmp = UnityEngine.Random.Range(295, 309);
                criticalDamage = ((float)tmp) / 100;
            }

            power = cardinfo.AminInt;
            energy = cardinfo.EminInt;
            criticalRate = cardinfo.RminF;

        }
        else
            Debug.Log("Item ID is insane");

        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

          


            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "INSERT INTO main.mycard(cardid, energy, power, criticalrate, criticaldamage, type , tier) VALUES(" + cardId + "," + energy + "," + power + "," + criticalRate + "," + criticalDamage + "," + type +"," + cardTier + ")";
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }



    }

    public void SetStatMinus()
    {
        int stat = GetPlayerStat();
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.player SET stat = " + (stat - 1);
                Debug.Log("minus1");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }

    public void PlusEnergyStat()
    {
        int energy = GetPlayerBasicEnergy();
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.basicplayerstat SET energy = " + (energy + 1);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }

    public void PlusDamageStat()
    {
        int damage = GetPlayerBasicDamage();
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.basicplayerstat SET damage = " + (damage + 1);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }

    public void PlusCriRateStat()
    {
        float criRate = GetPlayerBasicCriticalRate();
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.basicplayerstat SET criticalrate = " + (criRate + 0.0003);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }

    public void PlusCriDamageStat()
    {
        float criDamage = GetPlayerBasicCriticalDamage();
        using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
        {
            // 디비에 연결
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE main.basicplayerstat SET criticaldamage = " + (criDamage + 0.001);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();




            }
        }
    }



    //public int GetCardIdx(int idx)
    //{
    //    using (IDbConnection dbConnection = new SqliteConnection(m_ConnectionString))
    //    {
    //        // 디비에 연결
    //        dbConnection.Open();

    //        using (IDbCommand dbCmd = dbConnection.CreateCommand())
    //        {
    //            string sqlQuery = "SELECT idx FROM mycard where idx =" + idx ;

    //            dbCmd.CommandText = sqlQuery;



    //            using (IDataReader reader = dbCmd.ExecuteReader())
    //            {

    //                //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1));
    //                reader.Read();
    //                return reader.GetInt32(0);


    //                //모두 출력후 디비 닫기
    //                dbConnection.Close();
    //                reader.Close();

    //                // return reader.FieldCount;

    //            }

    //        }
    //    }


    //}
}
