using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Utilities.Interfaces;

namespace Utilities.Bootstrapper
{
    /// <summary>
    /// This is not a full implementation, just a template!
    /// Incomplete implementation of a single entry point of the project.
    /// Regulates the initialization order of all scene components.
    /// </summary>
    [Serializable]
    public class AtStartup : LinkingBehavior, IPreload, ICleanUp
    {
        /// <summary>
        /// You can also use events,
        /// and subscribe to this component in 'Awake' or something else.
        /// Every component is not subscribed here, only the main modules of the systems.
        /// </summary>
        public Action InitializationStackHasBeenDeployed;

        private static List<IBootstrapComponent> BootstrapComponents = new List<IBootstrapComponent>();
        
        /// <summary>
        /// The original implementation makes a call from main Bootstrapper.cs
        /// </summary>
        [SerializeField] private bool DebugInitializationAtStartScene = false;

        private new static bool IsInitialized = false;

        private protected void Start()
        {
            if (DebugInitializationAtStartScene)
            {
                Debug.LogError($"Attention, {this.name} is running in debug mode!");
                Initialization();
            }
        }

        private void OnDestroy()
        {
            BootstrapComponents.Clear();
            IsInitialized = false;
        }
        
        /// <summary>
        /// Caching of components at needed.
        /// </summary>
        public override void LinkingNecessaryComponents()
        {
        }

        /// <summary>
        /// Entry point.
        /// </summary>
        public override async void Initialization()
        {
            base.Initialization();

            await Preload();
            await CleanUp();

            foreach (var bootstrapComponent in BootstrapComponents)
            {
                bootstrapComponent.Initialization();
            }
           
            InitializationStackHasBeenDeployed?.Invoke();
            IsInitialized = true;
        }

        public static void AddToInitializationOrder(IBootstrapComponent bootstrapComponent)
        {
            if (IsInitialized)
                throw new FieldAccessException();

            if (bootstrapComponent.BootstrapPriority)
            {
                BootstrapComponents.Insert(0, bootstrapComponent);
                return;
            }

            BootstrapComponents.Add(bootstrapComponent);
        }
        
        /// <summary>
        /// We load all the complex elements immediately after loading the scene,
        /// and then clear the buffer.
        /// </summary>
        public async Task Preload()
        {
            //await PreloadMaterialsData();
        }

        public async Task CleanUp()
        {
            //await AssetsCleanUp();
        }
    }
}