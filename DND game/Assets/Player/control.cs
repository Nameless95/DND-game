// GENERATED AUTOMATICALLY FROM 'Assets/control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Control : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""control"",
    ""maps"": [
        {
            ""name"": ""cont"",
            ""id"": ""7af73690-b512-4a97-ac80-54b10c53edc4"",
            ""actions"": [
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""9b8327ca-3841-4b3e-9631-c5b1fdd4e067"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2ce587f6-bc19-411b-95b1-88fe2caeb628"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81d175b5-97e9-4cbc-9263-d0f6f055c8e8"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // cont
        m_cont = asset.FindActionMap("cont", throwIfNotFound: true);
        m_cont_shoot = m_cont.FindAction("shoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // cont
    private readonly InputActionMap m_cont;
    private IContActions m_ContActionsCallbackInterface;
    private readonly InputAction m_cont_shoot;
    public struct ContActions
    {
        private @Control m_Wrapper;
        public ContActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @shoot => m_Wrapper.m_cont_shoot;
        public InputActionMap Get() { return m_Wrapper.m_cont; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ContActions set) { return set.Get(); }
        public void SetCallbacks(IContActions instance)
        {
            if (m_Wrapper.m_ContActionsCallbackInterface != null)
            {
                @shoot.started -= m_Wrapper.m_ContActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_ContActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_ContActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_ContActionsCallbackInterface = instance;
            if (instance != null)
            {
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
            }
        }
    }
    public ContActions @cont => new ContActions(this);
    public interface IContActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
