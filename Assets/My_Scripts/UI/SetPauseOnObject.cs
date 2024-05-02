using UnityEngine;

public class SetPauseOnObject : MonoBehaviour
{
    private void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
    }
}
