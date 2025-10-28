using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public Image fadeImage; 
    public float fadeDuration = 1f;

    public Vector3 lastPlayerPosition;

    private void Awake()
    {
        // 싱글톤 패턴 — 씬 전환해도 유지
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 시작 시 페이드인
        if (fadeImage != null)
            StartCoroutine(FadeIn());
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    public void LoadMainScene() => LoadScene("MainScene");
    public void LoadMiniGameScene() => LoadScene("MiniGameScene");

    private IEnumerator FadeAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeOut()); // 화면 어두워짐
        yield return SceneManager.LoadSceneAsync(sceneName); // 씬 로드

        // 원래 위치 복원
        if (sceneName == "MainScene")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = lastPlayerPosition;
            }
        }

        if (fadeImage == null)
        {
            Image newFade = FindObjectOfType<Image>(includeInactive: true);
            if (newFade != null) fadeImage = newFade;
        }
        //페이드이미지 다시 찾기
        //씬 바뀔떄마다 이미지 갱신해서 정상 작동하게 함

        yield return StartCoroutine(FadeIn());  //  화면 밝아짐
    }

    private IEnumerator FadeOut()
    {
        float t = 0;
        Color c = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float t = 0;
        Color c = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
    }





    ///// <summary>
    ///// 지정한 씬으로 이동
    ///// </summary>
    //public void LoadScene(string sceneName)
    //{
    //    Debug.Log($"씬 전환: {sceneName}");
    //    SceneManager.LoadScene(sceneName);
    //}

    ///// <summary>
    ///// 메인 씬으로 이동
    ///// </summary>
    //public void LoadMainScene()
    //{
    //    LoadScene("MainScene");
    //}

    ///// <summary>
    ///// 미니게임 씬으로 이동
    ///// </summary>
    //public void LoadMiniGameScene()
    //{
    //    LoadScene("MiniGameScene");
    //}

    ///// <summary>
    ///// 현재 씬 다시 불러오기 (재시작용)
    ///// </summary>
    //public void ReloadCurrentScene()
    //{
    //    string current = SceneManager.GetActiveScene().name;
    //    LoadScene(current);
}

