using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField]  private int currentpoint = 0;
    [SerializeField]  private TextMeshProUGUI textpoint;

    // Start is called before the first frame update
    void Start()
    {
        textpoint.text = currentpoint.ToString();
    }

    public void PointPlus()
    {
        currentpoint += 1;
        textpoint.text = currentpoint.ToString();
    }
}
