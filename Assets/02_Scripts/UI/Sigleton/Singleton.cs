using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{


    private static T _instacne;

    private static bool appIsClosing = false;

    public static T Instance
    {
        get
        {
            if (appIsClosing)
            {
                return null;
            }

            if(_instacne == null)
            {
                _instacne = (T)FindObjectOfType(typeof(T));

                if(_instacne == null)
                {
                    GameObject newSingleton = new GameObject();

                    _instacne = newSingleton.AddComponent<T>();

                    newSingleton.name = typeof(T).ToString();
                }

                DontDestroyOnLoad(_instacne);
            }
            return _instacne;
        }
    }

  

    public void Start()
    {


        T[] allInstances = FindObjectsOfType(typeof(T)) as T[];
        
        if (allInstances.Length > 1)
        {
            //발견된 인스턴스에 각각에 대해...
            foreach (T instanceToCheck in allInstances)
            {
                //발견된 인스턴스가 현재 인스턴스가 아니라면
                if (instanceToCheck != Instance)
                {
                    //파괴한다

                    Destroy(instanceToCheck.gameObject);

                }
            }
        }
        Debug.Log(gameObject);
        DontDestroyOnLoad((T)FindObjectOfType(typeof(T)));
    }

    void OnApplicationQuit()
    {

        //...appIsClosing을 true로 설정한다.
        appIsClosing = true;
    }
}
