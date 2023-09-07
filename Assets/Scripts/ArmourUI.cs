using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArmourUI : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateArmourUI(int armour)
    {
        text.text = armour.ToString();
    }
}
