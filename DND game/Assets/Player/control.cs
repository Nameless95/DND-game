// GENERATED AUTOMATICALLY FROM 'Assets/Player/control.inputactions'

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
                },
                {
                    ""name"": ""hold"",
                    ""type"": ""Button"",
                    ""id"": ""ef9ae089-475c-4285-9b34-a2b93bbad79c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""wpn_right"",
                    ""type"": ""Button"",
                    ""id"": ""5f573e20-3c06-4435-b35f-0d0c9a49d068"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""wpn_left"",
                    ""type"": ""Button"",
                    ""id"": ""fc29262d-8cbd-4189-bd90-e6f982de119a"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""00f04636-8a26-49f0-8159-99c1457992d0"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4057c289-2946-4a49-a383-7b08ee0046dd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""wpn_right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45730f09-9dde-444e-9908-3b11c6efce58"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""wpn_left"",
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
        m_cont_hold = m_cont.FindAction("hold", throwIfNotFound: true);
        m_cont_wpn_right = m_cont.FindAction("wpn_right", throwIfNotFound: true);
        m_cont_wpn_left = m_cont.FindAction("wpn_left", throwIfNotFound: true);
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
    private readonly InputAction m_cont_hold;
    private readonly InputAction m_cont_wpn_right;
    private readonly InputAction m_cont_wpn_left;
    public struct ContActions
    {
        private @Control m_Wrapper;
        public ContActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @shoot => m_Wrapper.m_cont_shoot;
        public InputAction @hold => m_Wrapper.m_cont_hold;
        public InputAction @wpn_right => m_Wrapper.m_cont_wpn_right;
        public InputAction @wpn_left => m_Wrapper.m_cont_wpn_left;
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
                @hold.started -= m_Wrapper.m_ContActionsCallbackInterface.OnHold;
                @hold.performed -= m_Wrapper.m_ContActionsCallbackInterface.OnHold;
                @hold.canceled -= m_Wrapper.m_ContActionsCallbackInterface.OnHold;
                @wpn_right.started -= m_Wrapper.m_ContActionsCallbackInterface.OnWpn_right;
                @wpn_right.performed -= m_Wrapper.m_ContActionsCallbackInterface.OnWpn_right;
                @wpn_right.canceled -= m_Wrapper.m_ContActionsCallbackInterface.OnWpn_right;
                @wpn_left.started -= m_Wrapper.m_ContActionsCallbackInterface.OnWpn_left;
                @wpn_left.performed -= m_Wrapper.m_ContActionsCallbackInterface.OnWpn_left;
                @wpn_left.canceled -= m_Wrapper.m_ContActionsCallbackInterface.OnWpn_left;
            }
            m_Wrapper.m_ContActionsCallbackInterface = instance;
            if (instance != null)
            {
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
                @hold.started += instance.OnHold;
                @hold.performed += instance.OnHold;
                @hold.canceled += instance.OnHold;
                @wpn_right.started += instance.OnWpn_right;
                @wpn_right.performed += instance.OnWpn_right;
                @wpn_right.canceled += instance.OnWpn_right;
                @wpn_left.started += instance.OnWpn_left;
                @wpn_left.performed += instance.OnWpn_left;
                @wpn_left.canceled += instance.OnWpn_left;
            }
        }
    }
    public ContActions @cont => new ContActions(this);
    public interface IContActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnHold(InputAction.CallbackContext context);
        void OnWpn_right(InputAction.CallbackContext context);
        void OnWpn_left(InputAction.CallbackContext context);
    }
}
