
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;

namespace PaperJS
{
    /// <summary>
    /// The Layer item represents a layer in a Paper.js project.
    ///
    /// The layer which is currently active can be accessed through 
    /// project.activeLayer.
    ///
    /// An array of all layers in a project can be accessed through 
    /// project.layers.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/layer/
    /// </remarks>
    public class Layer : Group
    {
        /// <summary>
        /// Creates a new Layer item and places it at the end of the 
        /// project.layers array. The newly created layer will be activated, 
        /// so all newly created items will be placed within it.
        /// </summary>
        public Layer(Item[] children)
            : base(CreateObjectByTypeName("paper.Layer", new object[] { children }))
        {
        }

        public Layer(JSObject jsLayer)
            : base(jsLayer)
        {
        }

        /// <summary>
        /// Activates the layer.
        /// </summary>
        public void Active()
        {
            _jsObject.Invoke("activate");
        }
    }
}
