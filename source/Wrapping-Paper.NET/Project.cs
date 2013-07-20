
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
    /// A Project object in Paper.js is what usually is referred to as the 
    /// document: The top level object that holds all the items contained in 
    /// the scene graph. As the term document is already taken in the browser 
    /// context, it is called Project.
    ///
    /// Projects allow the manipluation of the styles that are applied to all 
    /// newly created items, give access to the selected items, and will in 
    /// future versions offer ways to query for items in the scene graph 
    /// defining specific requirements, and means to persist and load from 
    /// different formats, such as SVG and PDF.
    /// 
    /// The currently active project can be accessed through the 
    /// paperScope.project variable.
    /// 
    /// An array of all open projects is accessible through the 
    /// paperScope.projects variable.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/project/
    /// </remarks>
    public class Project : BaseWrapper
    {
        public Project(JSObject jsProject)
            : base(jsProject)
        {
        }

        /// <summary>
        /// The reference to the project's view.
        /// </summary>
        public View View
        {
            get
            {
                JSObject jsView = _jsObject["view"];
                return jsView == null ? null : new View(jsView);
            }
        }

        /// <summary>
        /// The index of the project in the paperScope.projects list. 
        /// Read only.
        /// </summary>
        public double Index
        {
            get
            {
                JSValue jsIndex = _jsObject["index"];
                return (double)jsIndex;
            }
        }

        public Layer ActiveLayer
        {
            get
            {
                JSObject jsLayer = _jsObject["activeLayer"];
                return jsLayer == null ? null : new Layer(jsLayer);
            }
            set
            {
                Item valueAsItem = value;
                _jsObject["activeLayer"] = value;
            }
        }
    }
}
