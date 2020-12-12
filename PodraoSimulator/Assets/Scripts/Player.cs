using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

[CreateAssetMenu(menuName = "Player")]
public class Player : ScriptableObject {
    public float money;
    public int workers;
    public int totalWorkers;
    public float workerPrice;
    float  baseWorkerPrice = 100;
    public Semaphore mutex = new Semaphore(1,1);

    public void Reset() {
        money = 100;
        workers = 1;
        totalWorkers = 1;
        workerPrice = baseWorkerPrice;
    }
    
    //semaforos dentro da função buy, para caso a funcao seja chamada pelo jogador ou pela thread, funcione da mesma forma
    public void Buy(Ingredient ing) {//produtor
        ing.empty.Wait();
        mutex.WaitOne();
        if(money >= ing.price) {//regiao critica, subtrai o dinheiro
            money -= ing.price;
            ing.quantity++;
        }
        mutex.Release();
        ing.full.Release();
    }

    public void Sell(Recipe rec) { //consumidor
        foreach(var ing in rec.ingredients) {//para cada ingrediente da receita, da wait no semaforo full
            ing.full.Wait();
        }

        if(rec.checkIng()) {
            rec.makeRecipe();
            money += rec.sellPrice;
        }

        foreach(var ing in rec.ingredients) {
            ing.empty.Release();
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
