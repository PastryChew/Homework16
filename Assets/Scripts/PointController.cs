using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private int currentpoint;
    public TextMeshProUGUI textpoint;

    // Start is called before the first frame update
    void Start()
    {
        textpoint = GetComponent<TextMeshProUGUI>();
        textpoint.text = currentpoint.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textpoint.text = currentpoint.ToString();
    }

    public void PointPlus()
    {
        currentpoint++;
    }
}
