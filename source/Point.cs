
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
    /// The Point object represents a point in the two dimensional space of 
    /// the Paper.js project. It is also used to represent two dimensional 
    /// vector objects.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/point/
    /// </remarks>
    public class Point : BaseWrapper
    {
        public Point(double x, double y)
            : base(CreateObjectByTypeName("paper.Point", new object[] { x, y }))
        {
        }

        public Point(JSObject jsPoint)
            : base(jsPoint)
        {
        }

        /// <summary>
        /// The x coordinate of the point
        /// </summary>
        public double X
        {
            get
            {
                JSValue jsX = _jsObject["x"];
                return (double)jsX;
            }
        }

        /// <summary>
        /// The y coordinate of the point
        /// </summary>
        public double Y
        {
            get
            {
                JSValue jsY = _jsObject["y"];
                return (double)jsY;
            }
        }
    }
}
