using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuiManager : MonoBehaviour {
	[SerializeField] GameObject panel;
	[SerializeField] Text name, strength, health, coolDown;
	MainTurret myTurret;
    private bool ready = true;
	public static GuiManager instance;
	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	public void ShowInformation<T>(T turret)
	{
        if (ready)
        {
            if (myTurret != null)

                ChangeTurretColor();
            panel.SetActive(true);
            string type = turret.GetType().ToString();
            switch (type)
            {
                case "MachineGun":
                    MachineGun gun = turret as MachineGun;
                    myTurret = gun.GetComponent<MainTurret>();
                    break;

                case "RocketLauncher":
                    RocketLauncher launcher = turret as RocketLauncher;
                    myTurret = launcher.GetComponent<MainTurret>();
                    break;

            }

            name.text = myTurret.gameObject.name;
            strength.text = ((int)myTurret.myTurret).ToString();
            health.text = myTurret.health.ToString();
            coolDown.text = myTurret.timeToSpawn.ToString();
            ChangeTurretColor(Color.green);
        }
	}

	public void ChangeTurretColor(Color color)
	{
		myTurret.transform.ChangeTurretColor (color);
	}

	public void ChangeTurretColor()
	{
		ChangeTurretColor (Color.white);
	}

    public void SetReady(bool isReady)
    {
        ready = isReady;
    }

    public void UpgradeTurret()
    {
        if (CoinManager.instance.RemoveMoney(myTurret.GetCostToUpgrade()))
        {
            myTurret.UpgradeTurret();
            
            //panel.SetActive(false);
        }
    }
}
