using KetosGames.SceneTransition;
using UnityEngine;
using UnityEngine.SpatialTracking;
using UnityEngine.XR.Management;

public class VRManager : MonoBehaviour
{
    [SerializeField] XRCardboardController XRController;
    [SerializeField] GyroCameraControl GyroController;

    int LessonMode = 0;

    private void Awake()
    {
#if UNITY_EDITOR
        LessonMode = 1;// start VR Mode
#else
        LessonMode = GameManager.Instance.LessonMode;
#endif
    }

    private void Start()
    {
        if (LessonMode == 0)
        {
            GyroController.enabled = true;
            XRController.DisableVR();
        }
        else
            XRController.EnableVR();
    }

    public void onBack()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        StopXR();//SceneLoader.LoadScene(1);
    }

    private void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");

        SceneLoader.LoadScene(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Android close icon or back button tapped.
            onBack();
        }
    }
}
