using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
    [SerializeField]
    private Image damageImage;

    void Start()
    {
        damageImage.enabled = false;
    }

    public void ShowDamageImage()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        damageImage.enabled = true;

        yield return new WaitForSeconds(0.5f);

        damageImage.enabled = false;
    }
}
