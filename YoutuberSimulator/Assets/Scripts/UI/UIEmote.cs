using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEmote : MonoBehaviour
{
    public Image image;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 100);

        if (transform.localPosition.y > 1000)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetIcon(Sprite icon)
    {
        image.sprite = icon;
        gameObject.SetActive(true);
    }
}
