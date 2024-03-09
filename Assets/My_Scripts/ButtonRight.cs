using UnityEngine;

public class ButtonRight : ButtonHandler
{
    private void Update()
    {
        if (isTap)
        {
            Player.transform.Rotate(0, transform.localPosition.y * -2f * Time.deltaTime, 0);
        }
    }
}
