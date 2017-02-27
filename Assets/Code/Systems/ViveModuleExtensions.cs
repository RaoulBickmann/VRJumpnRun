// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace ViveDB {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.Kernel;
    
    
    #region 
static
    public class ViveModuleExtensions {
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<Bullet> BulletManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Bullet>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<Rig> RigManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Rig>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<WandManager> WandManagerManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<WandManager>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<Turret> TurretManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Turret>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<Player> PlayerManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Player>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<Checkpoint> CheckpointManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Checkpoint>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<WandRight> WandRightManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<WandRight>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<Grabable> GrabableManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Grabable>();
        }
        #endregion
        
        #region 
static
        public uFrame.ECS.APIs.IEcsComponentManagerOf<WandLeft> WandLeftManager(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<WandLeft>();
        }
        #endregion
        
        #region 
static
        public List<Bullet> BulletComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Bullet>().Components;
        }
        #endregion
        
        #region 
static
        public List<Rig> RigComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Rig>().Components;
        }
        #endregion
        
        #region 
static
        public List<WandManager> WandManagerComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<WandManager>().Components;
        }
        #endregion
        
        #region 
static
        public List<Turret> TurretComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Turret>().Components;
        }
        #endregion
        
        #region 
static
        public List<Player> PlayerComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Player>().Components;
        }
        #endregion
        
        #region 
static
        public List<Checkpoint> CheckpointComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Checkpoint>().Components;
        }
        #endregion
        
        #region 
static
        public List<WandRight> WandRightComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<WandRight>().Components;
        }
        #endregion
        
        #region 
static
        public List<Grabable> GrabableComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<Grabable>().Components;
        }
        #endregion
        
        #region 
static
        public List<WandLeft> WandLeftComponents(this uFrame.ECS.APIs.IEcsSystem system) {
            return system.ComponentSystem.RegisterComponent<WandLeft>().Components;
        }
        #endregion
    }
    #endregion
}
