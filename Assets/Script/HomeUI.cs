using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{

    Button startbtn;
    Button exitbtn;

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        startbtn = transform.Find("Startbtn").GetComponent<Button>();
        exitbtn = transform.Find("Exitbtn").GetComponent<Button>();

        startbtn.onClick.AddListener(OnClickStartButton);
        exitbtn.onClick.AddListener(OnClickExitButton);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
