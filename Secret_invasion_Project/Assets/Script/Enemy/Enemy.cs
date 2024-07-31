using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Enemy : MonoBehaviour, IKillable<float> {

	protected float health;
	[SerializeField] protected float maxHealth;
	[SerializeField] int coins;
	[SerializeField] protected Transform[] checkPoints;
	[SerializeField] protected Transform target;
	[SerializeField] protected float strength, rotationSpeed;
	[SerializeField] protected Image lifeBar;
	private int targetIndex;
	protected Animator anim;
	// Use this for initialization
	float tColor=0;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		TakeCheckPoints ();

	}

	void Update()
	{
//		tColor += Time.deltaTime / 5;
//		lifeBar.color =Color.Lerp(Color.yellow,Color.red,tColor);
		lifeBar.transform.LookAt (Camera.main.transform.position);
	}
		

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 2) {
			if (other.tag == "End") {
				gameObject.SetActive (false);
				PlayerManager.instance.TakeDamage (strength);
			} else {
				targetIndex++;
				target = checkPoints [targetIndex];
			}
			//StartCoroutine ("RotateToTarget");
		}
	}

	public virtual void TakeCheckPoints()
	{
		GameObject aux = GameObject.Find ("CheckPoints");
		checkPoints = new Transform[aux.transform.childCount];
		for (int i = 0; i < checkPoints.Length; i++) {
			checkPoints [i] = aux.transform.GetChild (i);
		}
		target = checkPoints [0];
		targetIndex = 0;
	}

	IEnumerator RotateToTarget()
	{
//		Vector3 direction;
//		Quaternion lookRotation;
//		direction = target.position - transform.position;
//		lookRotation = Quaternion.LookRotation (direction);
//		float t = 0;
//		while (t<1) {
//			t += Time.deltaTime / rotationSpeed;
//			transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, t);
//			yield return 0;
//		}
//		StopCoroutine ("RotateToTarget");

		Vector3 direction;
		Quaternion lookRotation;
		float t = 0;
		while (true) {
			direction = target.position - transform.position;
			lookRotation = Quaternion.LookRotation (direction);
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
			yield return 0;
		}

	}

	public virtual void Reset()
	{
		health = maxHealth;
		target = checkPoints [0];
		targetIndex = 0;
		lifeBar.fillAmount = 1;
		tColor = 0;
		//lifeBar.color =Color.Lerp(Color.yellow,Color.red,0.5f);
		//StartCoroutine ("RotateToTarget");
	}

	protected virtual void OnEnable()
	{
		
		Reset ();
	}

	public void Kill()
	{
		SoundManager.instance.PlayEnemyDestroy ();
		CoinManager.instance.AddCoins (coins);
		gameObject.SetActive (false);
	}

	public void Hit(float damage)
	{
		//anim.Play ("HIT");
		anim.SetBool("Hit",true);
		health -= damage;
		float fill = health / maxHealth;
		lifeBar.fillAmount = fill;
		//Debug.Log (fill - 1);
		lifeBar.color =Color.Lerp(Color.red,Color.yellow,1-fill);

		if (health <= 0) {
			Kill ();
		}
	}

	public void Spawn(Transform spawnPoint)
	{
		transform.Spawn (spawnPoint);
	}

	public void Spawn(Transform spawnPoint, float y)
	{
		transform.Spawn (spawnPoint);
		transform.Translate (Vector3.up * y);
	}
}
