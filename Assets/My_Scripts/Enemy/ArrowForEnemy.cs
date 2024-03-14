
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ArrowForEnemy : MonoBehaviour
{
    private Image image;
    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        StartCoroutine(IconScale());
    }

    public void Show() => StartCoroutine(ShowCoroutine());

    public void Hide() => StartCoroutine(HideCoroutine());

    IEnumerator IconScale()
    {
        image.enabled = false;
        yield return new WaitForSeconds(1);
        image.enabled = true;
    }

    IEnumerator ShowCoroutine()
    {
        for (float t = 0; t < 1; t += Time.deltaTime * 2f)
        {
            transform.localScale = new Vector3(t, t, t);
            yield return null;
        }
        transform.localScale = Vector3.one;
        image.enabled = true;
    }

    IEnumerator HideCoroutine()
    {
        for (float t = 1; t > 0; t -= Time.deltaTime)
        {
            transform.localScale = new Vector3(t, t, t);
            yield return null;
        }
        image.enabled = false;
    }

}