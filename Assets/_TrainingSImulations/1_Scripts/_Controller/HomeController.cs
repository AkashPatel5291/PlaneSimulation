
using KetosGames.SceneTransition;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    private bool _isVrModeEnabled
    {
        get
        {
            return XRGeneralSettings.Instance.Manager.isInitializationComplete;
        }
    }

    public void onLessonModeSelected(int index)
    {
        GameManager.Instance.LessonMode = index;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (index == 1)
            StartCoroutine(StartXR());
        else
            SceneLoader.LoadScene(2);
    }

    private IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return new WaitForSeconds(2f);
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");

            SceneManager.LoadScene(2);
            
        }
    }
}
