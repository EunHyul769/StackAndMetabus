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
        // Ȥ�� �Ҵ� �� ���� �� �ڵ����� ã�� (������ġ)
        if (pressEText == null)
        {
            pressEText = GetComponentInChildren<TextMeshPro>(true);
        }

        // ���� �� �ؽ�Ʈ �����
        if (pressEText != null)
            pressEText.gameObject.SetActive(false);
    }

    void Update()
    {
        //���� �����̰� �ϴ� ȿ��
        if (pressEText != null && pressEText.gameObject.activeSelf)
        {
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * 2f)); //2�� �ֱ� �����Ÿ�
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
            //��ġ ���� �� �̴ϰ��Ӿ����� ��ȯ
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[TriggerEnter2D] ������ ������Ʈ: {other.name}");
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("EŰ�� ���� ��ȣ�ۿ�");

            // �ؽ�Ʈ ǥ��
            if (pressEText != null)
                pressEText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"[TriggerExit2D] ���� ����: {other.name}");
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // �ؽ�Ʈ �����
            if (pressEText != null)
                pressEText.gameObject.SetActive(false);
        }
    }
}
