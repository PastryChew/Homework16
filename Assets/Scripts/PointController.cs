using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public int currentpoint;
    public TextMeshProUGUI textpoint;

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
