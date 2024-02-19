using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] skins;

    private void Start()
    {
        int scinsID = PlayerPrefs.GetInt("scinsID");

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = skins[scinsID];
    }
}
