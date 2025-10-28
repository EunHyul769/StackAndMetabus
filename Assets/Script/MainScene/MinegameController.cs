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
}//메인으로 돌아가는 용도
