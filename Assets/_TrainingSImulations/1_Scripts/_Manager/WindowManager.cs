using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    public static WindowManager Instance;

    [System.Serializable]
    public class WindowItem
    {
        public string windowName = "My Window";
        public GameObject windowObject;
    }

    public List<WindowItem> windows = new List<WindowItem>();

    public List<WindowItem> notification = new List<WindowItem>();

    public int currentWindowIndex = 0;
    public int previousWindowIndex = 0;
    private int newWindowIndex;

    public string windowFadeIn = "Window In";
    public string windowFadeOut = "Window Out";

    private GameObject currentWindow;
    private GameObject nextWindow;

    private Animator currentWindowAnimator;
    private Animator nextWindowAnimator;


    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("IsLogin", 0) == 1)
            currentWindowIndex = 1;//Lession selection panel
        else
            currentWindowIndex = 0;//Login panel

        currentWindow = windows[currentWindowIndex].windowObject;
        currentWindowAnimator = currentWindow.GetComponent<Animator>();
        currentWindowAnimator.Play(windowFadeIn);
    }

    public void RegisterBtnClick()
    {
        PlayerPrefs.SetInt("IsAgreed", PlayerPrefs.GetInt("IsAgreed", 0));
        if (PlayerPrefs.GetInt("IsAgreed") == 1)
            OpenPanel("Register");
        else
            OpenPanel("PrivacyPolicy");
    }

    public void OpenPanel(string newPanel)
    {
        for (int i = 0; i < windows.Count; i++)
        {
            if (windows[i].windowName == newPanel)
                newWindowIndex = i;
        }

        if (newWindowIndex != currentWindowIndex)
        {
            currentWindow = windows[currentWindowIndex].windowObject;
            previousWindowIndex = currentWindowIndex;
            currentWindowIndex = newWindowIndex;
            nextWindow = windows[currentWindowIndex].windowObject;

            currentWindowAnimator = currentWindow.GetComponent<Animator>();
            nextWindowAnimator = nextWindow.GetComponent<Animator>();

            currentWindowAnimator.Play(windowFadeOut);
            nextWindowAnimator.Play(windowFadeIn);
        }
    }

    public void BackToPreviousWindow() {

        newWindowIndex = previousWindowIndex;

        if (newWindowIndex != currentWindowIndex)
        {
            currentWindow = windows[currentWindowIndex].windowObject;
            
            previousWindowIndex = currentWindowIndex;
            currentWindowIndex = newWindowIndex;
            nextWindow = windows[currentWindowIndex].windowObject;

            currentWindowAnimator = currentWindow.GetComponent<Animator>();
            nextWindowAnimator = nextWindow.GetComponent<Animator>();

            currentWindowAnimator.Play(windowFadeOut);
            nextWindowAnimator.Play(windowFadeIn);
        }
    }

    int currentErrorPanel;
    public void OpenErrorPanel(string panelName) {

        for (int i = 0; i < notification.Count; i++)
        {
            if (notification[i].windowName == panelName)
                currentErrorPanel = i;
        }

        notification[currentErrorPanel].windowObject.GetComponent<Animator>().Play(windowFadeIn);
    }

    public void CloseErrorPanel() {

        notification[currentErrorPanel].windowObject.GetComponent<Animator>().Play(windowFadeOut);
    }

    public void LogOut()
    {
        string str = PlayerPrefs.GetString("UserEmailID");
        //ToDo : Clear all playerPref
        PlayerPrefs.DeleteAll();

        //Clear all user Data
        PlayerPrefs.SetString("UserEmailID", str);
        OpenPanel("Login");
    }
}



