
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;
using System;

namespace PaperJS
{
    /// <summary>
    /// The PaperScope class represents the scope associated with a Paper 
    /// context. When working with PaperScript, these scopes are automatically 
    /// created for us, and through clever scoping the properties and methods 
    /// of the active scope seem to become part of the global scope.
    /// 
    /// When working with normal JavaScript code, PaperScope objects need to 
    /// be manually created and handled.
    /// 
    /// Paper classes can only be accessed through PaperScope objects. Thus in 
    /// PaperScript they are global, while in JavaScript, they are available 
    /// on the global paper object. For JavaScript you can use 
    /// paperScope.install(scope) to install the Paper classes and objects on 
    /// the global scope. Note that when working with more than one scope, 
    /// this still works for classes, but not for objects like 
    /// paperScope.project, since they are not updated in the injected scope 
    /// if scopes are switched.
    /// 
    /// The global paper object is simply a reference to the currently active 
    /// PaperScope.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/view/
    /// </remarks>
    public class PaperScope : BaseWrapper
    {
        public PaperScope(JSObject jsPaperScope)
            : base(jsPaperScope)
        {
        }

        /// <summary>
        /// The currently active project.
        /// </summary>
        public Project Project
        {
            get
            {
                JSObject jsProject = _jsObject["project"];
                return jsProject == null ? null : new Project(jsProject);
            }
        }

        /// <summary>
        /// The list of all open projects within the current Paper.js context.
        /// </summary>
        public Project[] Projects
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The reference to the active project's view. Read only.
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
        /// The version of Paper.js, as a string.
        /// </summary>
        public string Version
        {
            get
            {
                JSValue jsVersion = _jsObject["version"];
                return (string)jsVersion;
            }
        }


    }
}
