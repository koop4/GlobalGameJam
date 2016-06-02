using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public List<GameObject> goalItems;

    public List<GameObject> getInventory()
    {
        return goalItems;
    }

    public bool hasAllGoalItems(List<GameObject> theGoalItemsRequired)
    {
        bool answer = true;
        foreach (GameObject goalObj in theGoalItemsRequired)
        {
            if (!(goalItems.Contains(goalObj)))
                answer = false; 
        }
        return answer;
    }

    public void addItems(GameObject theItem)
    {
        goalItems.Add(theItem);
    }
}
