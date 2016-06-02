using UnityEngine;
using System.Collections;

public class GoalCollisionHandler : MonoBehaviour {

    public bool _isFinalGoal = false;

    public void setIsFinalGoal(bool theValue)
    {
        _isFinalGoal = theValue;
    }

    void OnTriggerEnter2D(Collider2D theOther)
	{

		if(theOther.gameObject.CompareTag("Player"))
		{
			if (_isFinalGoal) 
			{
			    GameObject.Find("Level").GetComponent<LevelHandler>().checkEnd ();
			} 
			else 
			{
				this.gameObject.SetActive(false);
                theOther.gameObject.GetComponent<Inventory>().addItems(this.gameObject);

			}	
		}
	}

    public bool isFinalGoal()
    {
        return _isFinalGoal;
    }



}
