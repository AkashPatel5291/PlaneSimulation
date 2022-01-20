using UnityEngine;

namespace KetosGames.SceneTransition.Example
{
    public class GoScript : MonoBehaviour
    {
        public string ToScene;

        public void GoToNextScene()
        {
            Debug.Log("GoToNextScene: " + ToScene);
            SceneLoader.LoadScene(ToScene);
        }
    }
}
