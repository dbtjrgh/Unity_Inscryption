using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnimationEndHandler : MonoBehaviour
{
    // 이 함수는 애니메이션 이벤트에 의해 호출됩니다.
    public void OnTitleAnimationHideEnd()
    {
        // MainMenu 씬으로 전환합니다.
        SceneManager.LoadScene("MainMenu");
    }
}
