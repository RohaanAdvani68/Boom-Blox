using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;

    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void Scored()
    {
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		float m = gameObject.GetComponent<Rigidbody2D> ().mass;
		if (sr.color != Color.green) {
			ScoreKeeper.AddToScore (m);
			sr.color = Color.green;
		}
    }

	internal void OnCollisionEnter2D(Collision2D obj){
		if (obj.gameObject.tag == "Ground")
			Scored ();
	}
}
