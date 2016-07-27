

using UnityEngine;
using System.Collections;
 
public class ToggleHandler : MonoBehaviour
{

    // 어떤 버튼이 활성화 되었는지 표시하기 위함.
    public UILabel m_lblMessage;

    // 토글을 제어하기 위해 선언함.
    public UIToggle[] m_arrToggles;

    void Update()
    {
        // 키로 제어하는것 추가.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_arrToggles[0].value = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_arrToggles[1].value = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_arrToggles[2].value = true;
        }
    }
    void OnEnable()
    {
        m_arrToggles[1].optionCanBeNone = true;
        m_arrToggles[1].value = false;
        m_arrToggles[1].optionCanBeNone = false;
        m_arrToggles[0].value = true;
        m_arrToggles[0].gameObject.GetComponent<UIToggledObjects>().Toggle();
        //m_arrToggles[0].gameObject.GetComponent<UIToggledObjects>().Toggle();




    }
    // 토글 버튼이 바뀔 때 발생하는 이벤트
    public void OnChangeToggle()
    {

        

        
        // 현재 상태가 변한 토글버튼을 가져옵니다.
        UIToggle current = UIToggle.current;
        // 우리는 활성화 된 경우만 처리할 예정이므로,
        // 활성화 된것(value가 true)이 아닌경우(false인 경우) return합니다.
        if (current.value == false) return;
        // 확인을 위해 메시지를 뿌립니다.
        m_lblMessage.text = current.name;
        
    }
}

