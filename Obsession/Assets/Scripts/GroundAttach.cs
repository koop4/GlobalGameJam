using UnityEngine;
using System.Collections;

public class GroundAttach : MonoBehaviour {

    private Vector3 offset;
	private Vector3 scale;
	private GameObject player;
	private GameObject platform;


    void OnCollisionEnter2D(Collision2D theOther)
    {
		if (theOther.gameObject.CompareTag("Platform"))
        {
			platform = theOther.gameObject;
            player = this.gameObject;
			setOffset (player.transform.position);
	//		setScale (player.transform.localScale);
			setParent(platform);
        }
    }

    void OnCollisionExit2D(Collision2D theOther)
    {
		if (theOther.gameObject.CompareTag ("Platform")) 
		{
			setParent (GameObject.Find ("Level"));
			//player = null;
		}
    }

	private void setOffset(Vector3 theOffset)
	{
		offset = theOffset;
	}


	private void setScale(Vector3 theScale)
	{
		scale = theScale;
	}

	private void setParent(GameObject theObject)
    {
        //Debug.Log("Entra");
		player.transform.SetParent(theObject.transform, true);
	//	player.transform.localScale = scale;
	//	player.transform.position = offset;

	}
}
