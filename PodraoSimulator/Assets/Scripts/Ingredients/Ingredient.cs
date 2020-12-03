using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

[CreateAssetMenu(menuName = "Ingredient")]
public class Ingredient : ScriptableObject {
    public string name;
    public int quantity;
    public float price;
    public int workers = 0;

    public SemaphoreSlim empty = new SemaphoreSlim(999, 999);
    public SemaphoreSlim full = new SemaphoreSlim(0, 999);

    public void Reset() {
        quantity = 0;
        workers = 0;
    }

}
