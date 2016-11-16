using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

	void Destruct(){
		GameObject.Destroy (gameObject);
	}

	void Boom(){
		PointEffector2D obj = gameObject.GetComponent<PointEffector2D> ();
		obj.enabled = true;
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		sr.enabled = false;
		Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
		Invoke ("Destruct", 0.1f);
	}

	internal void OnCollisionEnter2D(Collision2D obj){
		if (obj.relativeVelocity.magnitude >= ThresholdForce)
			Boom ();
	}
}
