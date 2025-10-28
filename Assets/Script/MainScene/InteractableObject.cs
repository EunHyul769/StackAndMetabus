using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    private bool isPlayerNearby;

    [SerializeField] private TextMeshPro pressEText;

    void Start()
    {
        // 혹시 할당 안 됐을 때 자동으로 찾기 (안전장치)
        if (pressEText == null)
        {
            pressEText = GetComponentInChildren<TextMeshPro>(true);
        }

        // 시작 시 텍스트 숨기기
        if (pressEText != null)
            pressEText.gameObject.SetActive(false);
    }

    void Update()
    {
        //문구 깜빡이게 하는 효과
        if (pressEText != null && pressEText.gameObject.activeSelf)
        {
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * 2f)); //2초 주기 깜빡거림
            pressEText.color = new Color(pressEText.color.r, pressEText.color.g, pressEText.color.b, alpha);
        }

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                SceneController.Instance.lastPlayerPosition = player.transform.position;
            }

            SceneController.Instance.LoadMiniGameScene();
            //위치 저장 후 미니게임씬으로 전환
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[TriggerEnter2D] 감지된 오브젝트: {other.name}");
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("E키를 눌러 상호작용");

            // 텍스트 표시
            if (pressEText != null)
                pressEText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"[TriggerExit2D] 감지 종료: {other.name}");
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // 텍스트 숨기기
            if (pressEText != null)
                pressEText.gameObject.SetActive(false);
        }
    }
}
