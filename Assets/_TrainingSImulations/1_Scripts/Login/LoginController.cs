using UnityEngine;

public class LoginController : MonoBehaviour
{
    public void OnLoginBtn()
    {
        PlayerPrefs.SetInt("IsLogin", 1);
        WindowManager.Instance.OpenPanel("Lession");
    }
}
