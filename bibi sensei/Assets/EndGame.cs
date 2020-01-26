using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject wall;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = endGameCanvas.GetComponent<CanvasGroup>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            endGameCanvas.SetActive(true);

            _canvasGroup.DOFade(1f, 2f);
            
            wall.SetActive(true);

        }
    }
}
