using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnimationEndHandler : MonoBehaviour
{
    // �� �Լ��� �ִϸ��̼� �̺�Ʈ�� ���� ȣ��
    public void OnTitleAnimationHideEnd()
    {
        // MainMenu ������ ��ȯ
        SceneManager.LoadScene("MainMenu");
    }
}
