using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinegameController : MonoBehaviour
{
    public void ReturnToMain()
    {
        SceneController.Instance.LoadMainScene();
    }
}//�������� ���ư��� �뵵
