// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace uFrameECSExample {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.ECS.UnityUtilities;
    using uFrame.Kernel;
    using UnityEngine;
    
    
    public class WeaponSystemUpdateHandler {
        
        public ShootingGuns Group;
        
        private uFrame.ECS.APIs.ISystemUpdate _Event;
        
        private uFrame.ECS.Systems.EcsSystem _System;
        
        private float ActionNode15_Result = default( System.Single );
        
        private float ActionNode14_a = default( System.Single );
        
        private float ActionNode14_b = default( System.Single );
        
        private bool ActionNode14_Result = default( System.Boolean );
        
        private float ActionNode43_a = default( System.Single );
        
        private float ActionNode43_b = default( System.Single );
        
        private float ActionNode43_Result = default( System.Single );
        
        private UnityEngine.GameObject ActionNode18_gameObject = default( UnityEngine.GameObject );
        
        private UnityEngine.Vector3 ActionNode18_position = default( UnityEngine.Vector3 );
        
        private UnityEngine.Vector3 ActionNode18_rotation = default( UnityEngine.Vector3 );
        
        private UnityEngine.GameObject ActionNode18_Result = default( UnityEngine.GameObject );
        
        private UnityEngine.GameObject ActionNode19_gameObject = default( UnityEngine.GameObject );
        
        private float ActionNode19_time = default( System.Single );
        
        private float FloatNode20 = 3F;
        
        public uFrame.ECS.APIs.ISystemUpdate Event {
            get {
                return _Event;
            }
            set {
                _Event = value;
            }
        }
        
        public uFrame.ECS.Systems.EcsSystem System {
            get {
                return _System;
            }
            set {
                _System = value;
            }
        }
        
        public virtual System.Collections.IEnumerator Execute() {
            // ActionNode
            while (this.DebugInfo("d8bd337f-c92c-44cf-b857-186f17c3eca3","2252575f-9688-4187-a178-6b2c29a81a4c", this) == 1) yield return null;
            // Visit uFrame.ECS.Actions.TimeLibrary.GetTime
            ActionNode15_Result = uFrame.ECS.Actions.TimeLibrary.GetTime();
            ActionNode14_a = ActionNode15_Result;
            ActionNode14_b = Group.Gun.NextFire;
            // ActionNode
            while (this.DebugInfo("2252575f-9688-4187-a178-6b2c29a81a4c","57020c9c-e9fd-47c3-bbd9-aa216b4a073a", this) == 1) yield return null;
            // Visit uFrame.ECS.Actions.Comparisons.GreaterThan
            ActionNode14_Result = uFrame.ECS.Actions.Comparisons.GreaterThan(ActionNode14_a, ActionNode14_b, ()=> { System.StartCoroutine(ActionNode14_yes()); }, ()=> { System.StartCoroutine(ActionNode14_no()); });
            yield break;
        }
        
        private System.Collections.IEnumerator ActionNode14_yes() {
            ActionNode43_a = ActionNode15_Result;
            ActionNode43_b = Group.Gun.FireRate;
            // ActionNode
            while (this.DebugInfo("57020c9c-e9fd-47c3-bbd9-aa216b4a073a","60555062-54c8-43d6-8aae-ae790ceafde0", this) == 1) yield return null;
            // Visit uFrame.ECS.Actions.FloatLibrary.Add
            ActionNode43_Result = uFrame.ECS.Actions.FloatLibrary.Add(ActionNode43_a, ActionNode43_b);
            // SetVariableNode
            while (this.DebugInfo("60555062-54c8-43d6-8aae-ae790ceafde0","a764ce20-dcbb-4dee-9388-dfcdd94ab113", this) == 1) yield return null;
            Group.Gun.NextFire = (System.Single)ActionNode43_Result;
            ActionNode18_gameObject = Group.Gun.ProjectilePrefab;
            ActionNode18_position = Group.Entity.transform.position;
            // ActionNode
            while (this.DebugInfo("a764ce20-dcbb-4dee-9388-dfcdd94ab113","bae9d444-633b-4d85-ba9a-a84de0387bb2", this) == 1) yield return null;
            // Visit uFrame.ECS.Actions.GameObjects.Instantiate
            ActionNode18_Result = uFrame.ECS.Actions.GameObjects.Instantiate(ActionNode18_gameObject, ActionNode18_position, ActionNode18_rotation);
            ActionNode19_gameObject = ActionNode18_Result.gameObject;
            ActionNode19_time = FloatNode20;
            // ActionNode
            while (this.DebugInfo("bae9d444-633b-4d85-ba9a-a84de0387bb2","839b59b8-7241-4620-940d-6cdc3329e40c", this) == 1) yield return null;
            // Visit uFrame.ECS.Actions.DestroyLibrary.DestroyGameObject
            uFrame.ECS.Actions.DestroyLibrary.DestroyGameObject(ActionNode19_gameObject, ActionNode19_time);
            yield break;
        }
        
        private System.Collections.IEnumerator ActionNode14_no() {
            yield break;
        }
    }
}
