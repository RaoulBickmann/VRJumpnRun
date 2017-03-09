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
    
    
    [uFrame.Attributes.ComponentId(10)]
    [uFrame.Attributes.uFrameIdentifier("78ac5fd9-2b18-485f-913e-85465df62c83")]
    public partial class Turret : uFrame.ECS.Components.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private Int32 _Counter;
        
        [UnityEngine.SerializeField()]
        private GameObject _Bullet;
        
        private Subject<PropertyChangedEvent<Int32>> _CounterObservable;
        
        private PropertyChangedEvent<Int32> _CounterEvent;
        
        private Subject<PropertyChangedEvent<GameObject>> _BulletObservable;
        
        private PropertyChangedEvent<GameObject> _BulletEvent;
        
        public override int ComponentId {
            get {
                return 10;
            }
        }
        
        public IObservable<PropertyChangedEvent<Int32>> CounterObservable {
            get {
                return _CounterObservable ?? (_CounterObservable = new Subject<PropertyChangedEvent<Int32>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<GameObject>> BulletObservable {
            get {
                return _BulletObservable ?? (_BulletObservable = new Subject<PropertyChangedEvent<GameObject>>());
            }
        }
        
        public Int32 Counter {
            get {
                return _Counter;
            }
            set {
                SetCounter(value);
            }
        }
        
        public GameObject Bullet {
            get {
                return _Bullet;
            }
            set {
                SetBullet(value);
            }
        }
        
        public virtual void SetCounter(Int32 value) {
            SetProperty(ref _Counter, value, ref _CounterEvent, _CounterObservable);
        }
        
        public virtual void SetBullet(GameObject value) {
            SetProperty(ref _Bullet, value, ref _BulletEvent, _BulletObservable);
        }
    }
}