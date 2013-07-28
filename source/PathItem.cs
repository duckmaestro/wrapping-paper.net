
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//

using Awesomium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperJS
{
    /// <summary>
    /// The PathItem class is the base for any items that describe paths and 
    /// offer standardised methods for drawing and path manipulation, such as 
    /// Path and CompoundPath.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/pathitem/
    /// </remarks>
    public class PathItem : Item
    {
        protected PathItem(JSObject jsPathItem)
            : base(jsPathItem)
        {
        }
    }
}
