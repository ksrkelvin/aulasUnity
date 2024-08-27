using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeItems : MonoBehaviour
{

    [Header("Current Items")]
    public float currentWood;
    public float currentWater;
    public float currentCarrots;
    public float currentFishes;
    
    [Header("Limits")]    
    public float totalWaterLimit;
    public float totalWoodLimit;
    public float totalCarrotLimit;
    public float totalFishLimit;



    public void GetWater(float water){
        if(currentWater < totalWaterLimit){
            currentWater += water;
        }else if(currentWater > totalWaterLimit){
            currentWater = totalWaterLimit;
        }
    }

    public void GetCarrot(float carrot){
        if(currentCarrots < totalCarrotLimit){
            currentCarrots += carrot;
        }else if(currentCarrots > totalCarrotLimit){
            currentCarrots = totalCarrotLimit;
        }
    }

    public void GetWood(float wood){
        if(currentWood < totalWoodLimit){
            currentWood += wood;
        }else if(currentWood > totalWoodLimit){
            currentWood = totalWoodLimit;
        }
    }

    public void GetFish(float fish){
        if(currentFishes < totalWoodLimit){
            currentFishes += fish;
        }else if(currentFishes > totalWoodLimit){
            currentFishes = totalFishLimit;
        }
    }




}
