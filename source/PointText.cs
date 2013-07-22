
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
    /// A PointText item represents a piece of typography in your Paper.js 
    /// project which starts from a certain point and extends by the amount of 
    /// characters contained in it.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/pointtext/
    /// </remarks>
    public class PointText : TextItem
    {
        public PointText(Point point)
            : base(CreateObjectByTypeName("paper.PointText", new object[] { point }))
        {

        }

        /// <summary>
        /// The PointText's anchor point
        /// </summary>
        public Point Point
        {
            get
            {
                JSObject jsPoint = _jsObject["point"];
                return jsPoint == null ? null : new Point(jsPoint);
            }
            set
            {
                _jsObject["point"] = value;
            }
        }
    }
}
