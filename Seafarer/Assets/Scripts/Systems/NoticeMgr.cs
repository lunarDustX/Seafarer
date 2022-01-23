using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeMgr : MonoBehaviour
{
    #region Singleton
    public static NoticeMgr Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public Text messageBoard;
    private float timer;

    public GameObject placeBoard;
    public Text placeTxt;

    private void Start()
    {
        messageBoard.text = "";
        placeTxt.text = "";
    }

    // 普通提示（获得物品）
    public void ShowMessage(string _msg)
    {
        messageBoard.text = _msg;
        timer = 2f;

        #region tween
        LeanTween.cancel(messageBoard.GetComponent<RectTransform>());
        messageBoard.GetComponent<RectTransform>().localScale = Vector3.one;
        LeanTween.scale(messageBoard.GetComponent<RectTransform>(), Vector3.one * 1.6f, 0.2f).setLoopPingPong(1);
        #endregion
    }

    // 高等级提示（地名提示）
    public void ShowReminder(string _reminder)
    {
        placeTxt.text = _reminder;
        placeBoard.SetActive(true);
    }

    public void HideReminder()
    {
        placeBoard.SetActive(false);
    }

    private void Update()
    {
        if (messageBoard.text != "")
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                messageBoard.text = "";
            }
        }

    }
}
