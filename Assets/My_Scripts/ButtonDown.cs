﻿using UnityEngine;

public class ButtonDown : ButtonHandler
{
    private void Update()
    {
        if (isTap)
        {
            Vector3 moveDown = (new Vector3(0f, -speedUpDown * Time.deltaTime, 0f));
            Player.transform.Translate(moveDown);
        }
    }
}
