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
    using uFrame.ECS.UnityUtilities;
    using uFrame.Kernel;
    using UnityEngine;
    
    
    public class InputSystemTriggerEventHandler {
        
        private ViveDB.TriggerEvent _Event;
        
        private uFrame.ECS.Systems.EcsSystem _System;
        
        private object ActionNode9_message = default( System.Object );
        
        private string StringNode10 = "123";
        
        public ViveDB.TriggerEvent Event {
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
            ActionNode9_message = StringNode10;
            // ActionNode
            while (this.DebugInfo("","d16047ab-31ca-4997-abf3-472fdfb8a8ab", this) == 1) yield return null;
            // Visit uFrame.ECS.Actions.DebugLibrary.LogMessage
            uFrame.ECS.Actions.DebugLibrary.LogMessage(ActionNode9_message);
            yield break;
        }
    }
}
