using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player")]
public class Player : ScriptableObject {
    public float money;
    public int workers;
    public int totalWorkers;
    public float workerPrice;
    float  baseWorkerPrice = 100;

    public void Reset() {
        money = 0;
        workers = 0;
        totalWorkers = 0;
        workerPrice = baseWorkerPrice;
    }

    public void Buy(Ingredient ing) {
        if(money >= ing.price) {
            money -= ing.price;
            ing.quantity++;
        }
    }

    public void Sell(Recipe rec) {
        if(rec.checkIng()) {
            rec.makeRecipe();
            money += rec.sellPrice;
        }
    }

    public void BuyWorker() {
        if(money > workerPrice) {
            money -= workerPrice;
            workers++;
            totalWorkers++;
            workerPrice = baseWorkerPrice * (float) Math.Pow(1.15,(double)totalWorkers);
        }
    }

    public void AddWorkerIng(Ingredient a) {
        if(workers > 0) {
            a.workers++;
            workers--;
        }
    }

    public void RemoveWorkerIng(Ingredient a) {
        if(a.workers > 0) {
            a.workers--;
            workers++;
        }
    }

    public void AddWorkerRec(Recipe a) {
        if(workers > 0) {
            a.workers++;
            workers--;
        }
    }

    public void RemoveWorkerRec(Recipe a) {
        if(a.workers > 0) {
            a.workers--;
            workers++;
        }
    }
}
