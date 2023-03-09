using Assets.ScriptsCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Creep
{
    void Start()
    {
        health = 50;
        damage = 5;
        Speed = 2;

        // Lấy type từ Factory
        type = TypeFactory.Instance.GetCreepType("worm", 5, 25, 2, 3, 1);

        animator = gameObject.GetComponent<Animator>();
        mainCamera = Camera.main;
        healthBar = transform.Find("ControlHealthCreep").gameObject;
        controlHealth = healthBar.GetComponent<HealthBar>();

        audioDeath = GetComponent<AudioSource>();
        // Put the eye to the body
        Eye = transform.Find("Eye").gameObject;
        if (Eye == null)
        {
            // Kiếm con mắt trong kho assets;
            Eye = (GameObject)Resources.Load(PrefabPath.CREEP_EYE);

            // Gắn con mắt làm gameObject con
            Eye.transform.parent = transform;
        }
        // Set born position
        bornPosition = transform.position;

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = standDuration;

        animator.SetTrigger("idle");
        controlHealth.SetMaxHealth((int)health);
    }

    public override void AttachMain()
    {
        // Không cần attack cận chiến
    }  
}
