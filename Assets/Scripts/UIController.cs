using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController I;
    
    [SerializeField] private TMP_Text _blocksDestroyed;
    [SerializeField] private TMP_Text _timeLeft;
    [SerializeField] private UIEmphasizer _emphasizer;

    public void Emphasize() => _emphasizer.Emphasize(0.3f);

    private void Awake()
    {
        I = this;
    }

    private void Update()
    {
        _blocksDestroyed.text = "Blocks Destroyed: " + GameManager.BlocksDestroyed;
        _timeLeft.text = "Time Left: " + Mathf.Round(GameManager.TimeLeft) + "s";
    }
}