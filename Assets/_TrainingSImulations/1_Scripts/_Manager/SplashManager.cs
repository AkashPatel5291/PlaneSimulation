using UnityEngine;
using UnityEngine.UI;
using KetosGames.SceneTransition;

public class SplashManager : MonoBehaviour
{
    [SerializeField] float fillSpeed = 0.5f;
    [SerializeField] Slider fillbar;
    [SerializeField] Image fillImg;
    [SerializeField] TMPro.TMP_Text amt;

    bool startProgress = false;
    void Start()
    {
        //Invoke("onStartProgress", 0.5f);
        Invoke("jumpScreen", 3.25f);
    }

    void onStartProgress()
    {
        amt.text = "0%";
        startProgress = true;
    }

    void jumpScreen()
    {
        SceneLoader.LoadScene(1);
    }

    void Update()
    {
        if (startProgress)
        {
            if (fillbar.value < 1f)
            {
                float progress = fillSpeed * Time.deltaTime;
                fillbar.value += progress;
                fillImg.fillAmount += progress;
                float str = fillbar.value * 100f;
                int t = (int)str;
                amt.text = t.ToString() + "%";
            }
            else
            {
                startProgress = false;
                SceneLoader.LoadScene(1);
            }
        }
    }
}
