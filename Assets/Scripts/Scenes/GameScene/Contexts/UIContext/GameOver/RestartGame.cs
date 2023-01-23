using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UIContext.GameOver
{
    public class RestartGame : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
