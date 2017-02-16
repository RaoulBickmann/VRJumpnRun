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
    using uFrame.ECS.Components;
    using uFrame.Json;
    using UniRx;
    using UnityEngine;
    
    
    [uFrame.Attributes.ComponentId(6)]
    [uFrame.Attributes.uFrameIdentifier("8d90ad11-fd0b-42e0-bba8-582cabb45d14")]
    public partial class Player : uFrame.ECS.Components.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private KeyCode _space;
        
        private Subject<PropertyChangedEvent<KeyCode>> _spaceObservable;
        
        private PropertyChangedEvent<KeyCode> _spaceEvent;
        
        public override int ComponentId {
            get {
                return 6;
            }
        }
        
        public IObservable<PropertyChangedEvent<KeyCode>> spaceObservable {
            get {
                return _spaceObservable ?? (_spaceObservable = new Subject<PropertyChangedEvent<KeyCode>>());
            }
        }
        
        public KeyCode space {
            get {
                return _space;
            }
            set {
                Setspace(value);
            }
        }
        
        public virtual void Setspace(KeyCode value) {
            SetProperty(ref _space, value, ref _spaceEvent, _spaceObservable);
        }
    }
}
