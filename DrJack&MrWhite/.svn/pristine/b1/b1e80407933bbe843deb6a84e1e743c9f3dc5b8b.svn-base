using UnityEngine;
using System.Collections;

public class sc_HUEShift : MonoBehaviour {

    public Color startColor,endColor;
    public float speed = 1.0f;

    private float cycleProgress;
    private short cycleProgressDirection = 1;

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
    {
        this.sprite = this.GetComponent<SpriteRenderer>();
        if (this.sprite == null)
            Debug.LogError("this script must be attached to a UILabel object");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Color col = Color.white;
        col.r = startColor.r + ((endColor.r - startColor.r) * this.cycleProgress);
        col.g = startColor.g + ((endColor.g - startColor.g) * this.cycleProgress);
        col.b = startColor.b + ((endColor.b - startColor.b) * this.cycleProgress);
        col.a = startColor.a;

        this.sprite.color = col;

        this.cycleProgress += Time.deltaTime * speed * this.cycleProgressDirection;

        if (cycleProgressDirection == 1 && this.cycleProgress >= 1.0f)
        {
            this.cycleProgress = 1.0f;
            this.cycleProgressDirection = -1;
        }
        if (cycleProgressDirection == -1 && this.cycleProgress <= 0.0f)
        {
            this.cycleProgress = 0.0f;
            this.cycleProgressDirection = 1;
        }
	}
}
