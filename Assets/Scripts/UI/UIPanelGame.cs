using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelGame : MonoBehaviour,IMenu
{
    public Text LevelConditionView;

    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnResart;

    private UIMainManager m_mngr;

    private void Awake()
    {
        btnPause.onClick.AddListener(OnClickPause);
        btnResart.onClick.AddListener(OnClickResart);
    }

    private void OnClickPause()
    {
        m_mngr.ShowPauseMenu();
    }
    private void OnClickResart()
    {
        GameManager.instance.SetState(GameManager.eStateGame.Game_RESART);
        StartCoroutine(BoardController.Instance.RefillBoardCoroutine());
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
