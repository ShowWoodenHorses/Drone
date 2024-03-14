using UnityEngine;

public class ButtonLeft : ButtonHandler
{
    private void Update()
    {
        if (isTap)
        {
            Player.transform.Rotate(0, transform.localPosition.y * speedRotate * Time.deltaTime, 0);
        }
    }
}
