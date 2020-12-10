using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] Recipe[] recipes;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI workerText;
    bool Running;

    // Update is called once per frame
    void Update() {
        moneyText.text = "Dinheiro: R$ " + player.money + "\n" +
                         "Funcionários: " + player.workers + "/" + player.totalWorkers;
        workerText.text = "Contratar Funcionario: \nR$" + player.workerPrice;
    }

    void Start() {
        Running = true;

        Thread p0 = new Thread(()=>Produtor(0));
        Thread p1 = new Thread(()=>Produtor(1));
        Thread p2 = new Thread(()=>Produtor(2));
        Thread p3 = new Thread(()=>Produtor(3));
        Thread p4 = new Thread(()=>Produtor(4));
        Thread p5 = new Thread(()=>Produtor(5));
        Thread p6 = new Thread(()=>Produtor(6));
        Thread p7 = new Thread(()=>Produtor(7));
        Thread p8 = new Thread(()=>Produtor(8));

        Thread c0 = new Thread(()=>Consumidor(0));
        Thread c1 = new Thread(()=>Consumidor(1));
        Thread c2 = new Thread(()=>Consumidor(2));
        Thread c3 = new Thread(()=>Consumidor(3));
        Thread c4 = new Thread(()=>Consumidor(4));
        Thread c5 = new Thread(()=>Consumidor(5));
        Thread c6 = new Thread(()=>Consumidor(6));
        Thread c7 = new Thread(()=>Consumidor(7));
        Thread c8 = new Thread(()=>Consumidor(8));
        Thread c9 = new Thread(()=>Consumidor(9));
        Thread c10 = new Thread(()=>Consumidor(10));
        Thread c11 = new Thread(()=>Consumidor(11));
        Thread c12 = new Thread(()=>Consumidor(12));

        
        p0.Start(); p1.Start(); p2.Start(); p3.Start(); p4.Start();
        p5.Start(); p6.Start(); p7.Start(); p8.Start();

        c0.Start(); c1.Start(); c2.Start(); c3.Start(); 
        c4.Start(); c5.Start(); c6.Start(); c7.Start();
        c8.Start(); c9.Start(); c10.Start(); c11.Start();
        c12.Start();
    }

    void Produtor(int i) {
            while (Running) {
                if (ingredients[i].workers != 0) {
                    ingredients[i].empty.Wait();
                    player.Buy(ingredients[i]);
                    ingredients[i].full.Release();
                    Thread.Sleep(2000 / ingredients[i].workers);
                }
            }
    }

    void Consumidor(int i) {
        while (Running) {
            if (recipes[i].workers != 0) {
                foreach(var ing in recipes[i].ingredients)
                    ing.full.Wait();

                player.Sell(recipes[i]);

                foreach(var ing in recipes[i].ingredients)
                    ing.empty.Release();

                Thread.Sleep(5000 / recipes[i].workers);
            }
        }
    }

    void OnApplicationQuit() {
        Running = false;
    }

    public void MasterReset() {
        player.Reset();
        foreach(Ingredient ing in ingredients) ing.Reset();
        foreach(Recipe rec in recipes) rec.Reset();
    }
}
