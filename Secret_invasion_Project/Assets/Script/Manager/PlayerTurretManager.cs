using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretManager : MonoBehaviour {
	[SerializeField] GameObject turret, ghostTurret;
	public List<GameObject> instantiatedTurrets=new List<GameObject>();
	RaycastHit hit;
	[SerializeField] LayerMask layerMask;
    public static PlayerTurretManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update () {
		if (ghostTurret != null) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)) {
				ghostTurret.transform.position = hit.point;
				if ((hit.collider.gameObject.layer == 0) || (CheckIntersectionsWithTurrets (ghostTurret)))
					ghostTurret.transform.ChangeTurretColor (Color.red);
				else {
					
					ghostTurret.transform.ChangeTurretColor (Color.green);
					if ((Input.GetMouseButton (0))&&(CoinManager.instance.RemoveMoney(turret.GetComponent<MainTurret>().GetCostToBuy()))) {
						GameObject aux = GameObject.Instantiate (turret, hit.point, hit.transform.rotation);
						AddTurret(aux);
					}
				}
					
			}
            if (Input.GetMouseButtonDown(1))
                Reset();
		}

//		if ((Input.GetMouseButtonDown (0)) && (turret!=null))
//		{
//			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//			if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)) {
//				GameObject aux = GameObject.Instantiate (turret, hit.point, hit.transform.rotation);
//				if (!CheckIntersectionsWithTurrets (aux))
//					instantiatedTurrets.Add (aux);
//				else
//					Destroy (aux);
//			}
//
//		}
	}

	private bool CheckIntersectionsWithTurrets(GameObject aux)
	{
		if (instantiatedTurrets.Count == 0)
			return false;
		else
			foreach (GameObject turret in instantiatedTurrets) {
				if (aux.GetComponent<BoxCollider> ().bounds.Intersects (turret.GetComponent<BoxCollider> ().bounds))
					return true;
			}
		return false;
	}

	public void SetTurretType(GameObject turretType)
	{
        if (ghostTurret != null)
            Destroy(ghostTurret);
		turret = turretType;
		ghostTurret = Instantiate (turret);
		ghostTurret.transform.GetChild (0).GetComponent<SphereCollider> ().enabled = false;
        GuiManager.instance.SetReady(false);
    }

    private void Reset()
    {
        GuiManager.instance.SetReady(true);
        turret = null;
        Destroy(ghostTurret);
    }

    public void AddTurret(GameObject turret)
    {
        instantiatedTurrets.Add(turret);
    }

    public void RemoveTurret(GameObject turret)
    {
        instantiatedTurrets.Remove(turret);
    }


}
