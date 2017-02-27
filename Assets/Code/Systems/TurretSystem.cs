namespace ViveDB {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS.APIs;
    using uFrame.ECS.Components;
    using uFrame.ECS.Systems;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    using ViveDB;
    
    
    public partial class TurretSystem
    {

        protected override void TurretSystemFixedUpdateHandler(Turret group)
        {
            base.TurretSystemFixedUpdateHandler(group);
            if (group.Counter == 33)
            {
                GameObject bullet = Instantiate(group.Bullet, group.transform.position + group.transform.forward * 0.2f, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = group.transform.forward;
                Destroy(bullet, 5);
                group.Counter = 0;
            }
            else
            {
                group.Counter++;
            }
        }
    }
}
