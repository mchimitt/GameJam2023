using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarmaMeter : MonoBehaviour
{
    [SerializeField] private Image _karmaMeter;
    // Start is called before the first frame update
    public void UpdateKarmaMeter(float maxKarma, float currentKarma)
    {
        _karmaMeter.fillAmount = currentKarma / maxKarma;
    }
}
