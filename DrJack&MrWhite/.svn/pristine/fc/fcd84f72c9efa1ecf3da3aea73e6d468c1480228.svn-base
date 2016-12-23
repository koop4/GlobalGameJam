using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour
{
	public CharacterScript giocatore;
		private float Speed;
		private float earthRadius = 4.6f;
		
		private float _offset = 0;
		private float vSpeed = 0;
		
		private float timeCounter;
		
		//riferimenti agli altri oggetti
		public WorldScript world;
		
		
		//flags
		
		// Use this for initialization
		void Start ()
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{        
		Speed = giocatore.Speed;
			this.transform.position = new Vector3(-Mathf.Cos(this.timeCounter * this.Speed) * (this.earthRadius + this._offset), Mathf.Sin(this.timeCounter * this.Speed) * (this.earthRadius + this._offset), this.transform.position.z);
			this.timeCounter += Time.deltaTime;
			
			//ottengo il radius del mondo a seconda della sua dimensione
			this.earthRadius = this.world.GetGameRadius();
			this._offset += vSpeed;
			
			
			//agiorno posizione camera
			Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
			                                             }
			                                             
			                                             
			                                             
			                                             
			

}

