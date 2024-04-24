using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

public class TextAppearScript : MonoBehaviour
{
    public TextMeshProUGUI collisionText;  // Assign this in the inspector

    void OnCollisionEnter(Collision collision)
    {
        collisionText.gameObject.SetActive(true);
    }
}
