using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNumber : MonoBehaviour
{
    [SerializeField] TextMesh textMesh;
    [SerializeField] Color[] initialTextColor;
    [SerializeField] Color endTextColor;
    [SerializeField] float timeToLive = 1;
    [SerializeField] float speed = 3;
    [SerializeField] float colourChangeSpeed =1;

    public void SetupText(int value) {
        int colorIndex = value-1;
        if (value>=initialTextColor.Length) colorIndex = initialTextColor.Length-1;
        textMesh.color = initialTextColor[colorIndex];
        textMesh.text = "+" + value.ToString();
        Destroy(gameObject, timeToLive);
    }
    private void Update() {
        textMesh.color = Color.Lerp(textMesh.color, endTextColor, Time.deltaTime * colourChangeSpeed);
        transform.position += Vector3.up * speed *Time.deltaTime;
    }
}
