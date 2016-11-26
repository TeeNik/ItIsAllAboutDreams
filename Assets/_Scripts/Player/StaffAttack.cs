using UnityEngine;
using System.Collections;

public class StaffAttack : MonoBehaviour {

    public GameObject shot;
    public Transform shotPoint;

    Item weapon;

    void FixedUpdate()
    {
        weapon = GameObject.Find("Inventory").GetComponent<Equipment>().weapon;

        CheckStaffAnim();
    }



	void CheckStaffAnim()
    {
        Animator anim = GameObject.Find("Staff").GetComponent<Animator>();

        if (weapon == null) return;

        switch(weapon.ID)
        {
            case 20:
                anim.SetFloat("StaffNumber", 0);
                break;
            case 21:
                anim.SetFloat("StaffNumber", 0.1f);
                break;
            case 22:
                anim.SetFloat("StaffNumber", 0.2f);
                break;
            case 23:
                anim.SetFloat("StaffNumber", 0.3f);
                break;
            case 24:
                anim.SetFloat("StaffNumber", 0.4f);
                break;
            case 25:
                anim.SetFloat("StaffNumber", 0.5f);
                break;
            case 26:
                anim.SetFloat("StaffNumber", 0.6f);
                break;
            case 27:
                anim.SetFloat("StaffNumber", 0.7f);
                break;
        }
    }

    public void Shoot()
    {
        GameObject clone = Instantiate(shot, shotPoint.position, shotPoint.rotation) as GameObject;
        Animator anim = clone.GetComponent<Animator>();

        GetComponent<MagicSpell>().ChooseDirection(clone);

        if (weapon == null) return;

        clone.GetComponent<ProjectileMover>().damage = weapon.Value;


        switch (weapon.ID)
        {
            case 20:
                anim.SetFloat("StaffNumber", 0);
                break;
            case 21:
                anim.SetFloat("StaffNumber", 0.1f);
                break;
            case 22:
                anim.SetFloat("StaffNumber", 0.2f);
                break;
            case 23:
                anim.SetFloat("StaffNumber", 0.3f);
                break;
            case 24:
                anim.SetFloat("StaffNumber", 0.4f);
                break;
            case 25:
                anim.SetFloat("StaffNumber", 0.5f);
                break;
            case 26:
                anim.SetFloat("StaffNumber", 0.6f);
                break;
            case 27:
                anim.SetFloat("StaffNumber", 0.7f);
                break;
        }
    }
}
