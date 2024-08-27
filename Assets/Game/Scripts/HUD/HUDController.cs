using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishUIBar;

    [Header("Tools")]
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color unselectedColor;

    private PlayeItems playerItems;
    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        playerItems = player.GetComponent<PlayeItems>();
   
    }
    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIBar();
        ChangeToolColor();
    }

    void UpdateUIBar(){
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.totalWaterLimit;
        woodUIBar.fillAmount = playerItems.currentWood / playerItems.totalWoodLimit;
        carrotUIBar.fillAmount = playerItems.currentCarrots / playerItems.totalCarrotLimit;
        fishUIBar.fillAmount = playerItems.currentFishes / playerItems.totalFishLimit;

    }

    void ChangeToolColor(){
        for (int i = 0; i < toolsUI.Count; i++)
        {
            if (i == player.handlingObj)
            {
                toolsUI[i].color = selectedColor;
            }
            else
            {
                toolsUI[i].color = unselectedColor;
            }
        }
    }
}
