using UnityEngine;

public class ButtonUp : ButtonHandler
{
    private void Update()
    {
        if (isTap)
        {
            Vector3 moveUp = (new Vector3(0f, 5f * Time.deltaTime, 0f));
            Player.transform.Translate(moveUp);
        }
    }
}
