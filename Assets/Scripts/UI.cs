using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Text score;
    void Update()
    {
        //i set the score text on screen
        score.text = GameManager.Instance.score.ToString();
    }
}
