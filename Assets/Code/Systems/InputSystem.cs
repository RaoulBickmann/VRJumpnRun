using uFrame.ECS.UnityUtilities;

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
    
    
    public partial class InputSystem
    {

        private SteamVR_Controller.Device leftController;
        private SteamVR_Controller.Device rightController;
        private GameObject grabbedGameObject;



		public int i = 0;

		protected LineRenderer lineRenderer;
		protected Vector3[] lineRendererVertices;

        //k_EButton_System = 0,
	    //k_EButton_ApplicationMenu = 1,
	    //k_EButton_Grip = 2,
	    //k_EButton_DPad_Left = 3,
	    //k_EButton_DPad_Up = 4,
	    //k_EButton_DPad_Right = 5,
	    //k_EButton_DPad_Down = 6,
	    //k_EButton_A = 7,
	    //k_EButton_ProximitySensor = 31,
	    //k_EButton_Axis0 = 32,
	    //k_EButton_Axis1 = 33,
	    //k_EButton_Axis2 = 34,
	    //k_EButton_Axis3 = 35,
	    //k_EButton_Axis4 = 36,
	    //k_EButton_SteamVR_Touchpad = 32,
	    //k_EButton_SteamVR_Trigger = 33,
	    //k_EButton_Dashboard_Back = 2,
	    //k_EButton_Max = 64,

        private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
        private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
		private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;


        protected override void InputSystemKernelLoadedHandler(KernelLoadedEvent data, WandManager group)
        {
            base.InputSystemKernelLoadedHandler(data, group);
            leftController = SteamVR_Controller.Input ((int)group.Left.GetComponent<SteamVR_TrackedObject>().index);
			rightController = SteamVR_Controller.Input ((int)group.Right.GetComponent<SteamVR_TrackedObject>().index);

			//// Initialize our LineRenderer
			//lineRenderer = gameObject.AddComponent<LineRenderer>();
			//lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			//lineRenderer.SetWidth(0.01f, 0.01f);
			//lineRenderer.SetVertexCount(2);

			//// Initialize our vertex array. This will just contain
			//// two Vector3's which represent the start and end locations
			//// of our LineRenderer
			//lineRendererVertices = new Vector3[2];
        }

        protected override void InputSystemUpdateLeftHandler(WandLeft group)
        {
            base.InputSystemUpdateLeftHandler(group);
            if (leftController.GetTouch(touchPad))
            {
                var moveEvent = new PlayerMoveEvent();
                moveEvent.movement = leftController.GetAxis(touchPad) * Time.deltaTime;
                Publish(moveEvent);
            }
            if (leftController.GetPressDown(triggerButton))
            {
                Publish(new JumpEvent());
            }
        }

        protected override void InputSystemUpdateRightHandler(WandRight group)
        {
            base.InputSystemUpdateRightHandler(group);
            if (rightController.GetTouch(touchPad))
            {
                var moveEvent = new RigMoveEvent();
                moveEvent.movement = rightController.GetAxis(touchPad) * Time.deltaTime;
                Publish(moveEvent);
            }
            if (!rightController.GetPress(triggerButton) && grabbedGameObject != null)
            {
                grabbedGameObject.transform.SetParent(null);
            }
        }

        protected override void InputSystemOnTriggerEnterHandler(OnTriggerEnterDispatcher data, Grabable collider, WandRight source)
        {
            base.InputSystemOnTriggerEnterHandler(data, collider, source);
            Debug.Log("Enter");
            Debug.Log(collider + "" + source);

        }

        protected override void InputSystemOnTriggerStayHandler(OnTriggerStayDispatcher data, Grabable collider, WandRight source)
        {
            base.InputSystemOnTriggerStayHandler(data, collider, source);
            if (grabbedGameObject == null)
            {
                grabbedGameObject = collider.gameObject;
                grabbedGameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            if (rightController.GetPress(triggerButton) && grabbedGameObject.transform.parent != source.gameObject.transform)
            {
                grabbedGameObject.transform.SetParent(source.transform, true);
            }
        }


        protected override void InputSystemOnTriggerExitHandler(OnTriggerExitDispatcher data, Grabable collider, WandRight source)
        {
            base.InputSystemOnTriggerExitHandler(data, collider, source);
            Debug.Log("Exit");
            if(grabbedGameObject != null)
            {
                if(grabbedGameObject.transform.parent != source.gameObject.transform)
                {
                    grabbedGameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                    grabbedGameObject = null;
                }

            }

        }

        //protected override void InputSystemUpdateHandler(WandManager group) {
        //	base.InputSystemUpdateHandler (group);
        //	if (trackedContrRight.triggerPressed) {
        //		Publish (new ShootEvent());
        //	}

        //	if (trackedContrRight.padPressed) {
        //		Publish (new TeleportEvent());
        //	}

        //	if (trackedContrRight.padTouched) {
        //		var moveEvent = new MoveEvent ();
        //		moveEvent.movement = GetTouchpadAxis () * Time.deltaTime;
        //		Publish (moveEvent);
        //	}

        //	// Update our LineRenderer
        //	if (lineRenderer && lineRenderer.enabled)
        //	{
        //		RaycastHit hit;
        //		Vector3 startPos = trackedContrRight.transform.position;;

        //		// If our raycast hits, end the line at that position. Otherwise,
        //		// just make our line point straight out for 1000 meters.
        //		// If the raycast hits, the line will be green, otherwise it'll be red.
        //		if (Physics.Raycast(startPos, trackedContrRight.transform.forward, out hit, 1000.0f))
        //		{
        //			lineRendererVertices[1] = hit.point;
        //			lineRenderer.SetColors(Color.green, Color.green);
        //		}
        //		else
        //		{
        //			lineRendererVertices[1] = startPos + trackedContrRight.transform.forward * 1000.0f;
        //			lineRenderer.SetColors(Color.red, Color.red);
        //		}

        //		lineRendererVertices[0] = trackedContrRight.transform.position;
        //		lineRenderer.SetPositions(lineRendererVertices);
        //	}




        //}

        //public Vector2 GetTouchpadAxis()
        //{
        //			return controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
        //}

        //protected override void InputSystemShootEventHandler(ViveDB.ShootEvent data, WandManager group) {
        //	if ((i % 5 == 0)) {
        //		base.InputSystemShootEventHandler (data, group);
        //		var cube = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        //		cube.transform.position = trackedContrRight.transform.position;
        //		cube.transform.localScale *= 0.1f;
        //		cube.AddComponent<Rigidbody> ();
        //		cube.GetComponent<Rigidbody> ().velocity = trackedContrRight.transform.forward * 100;
        //	} else {
        //		i++;
        //	}

        //}

        //protected override void InputSystemTeleportEventHandler(ViveDB.TeleportEvent data, WandManager group) {
        //	Debug.Log("Teleport");

        //	base.InputSystemTeleportEventHandler (data, group);
        //	// We want to move the whole [CameraRig] around when we teleport,
        //	// which should be the parent of this controller. If we can't find the
        //	// [CameraRig], we can't teleport, so return.
        //	if (trackedContrRight.transform.parent == null)
        //		return;

        //	RaycastHit hit;
        //	Vector3 startPos = trackedContrRight.transform.position;

        //	// Perform a raycast starting from the controller's position and going 1000 meters
        //	// out in the forward direction of the controller to see if we hit something to teleport to.
        //	if (Physics.Raycast(startPos, trackedContrRight.transform.forward, out hit, 1000.0f))
        //	{
        //		trackedContrRight.transform.parent.position = hit.point;
        //	}
        //}

        //protected override void InputSystemMoveEventHandler(MoveEvent data, Player group) {
        //	base.InputSystemMoveEventHandler (data, group);
        //	Debug.Log (data.movement);
        //	group.transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        //	//group.transform.Translate (new Vector3(group.transform.forward.x * data.movement.x, 0, group.transform.forward.y * data.movement.y), Space.World);
        //	group.transform.Translate (new Vector3(data.movement.x, 0, data.movement.y), Space.Self);

        //}
    }
}


