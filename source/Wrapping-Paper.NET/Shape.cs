
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
    /// 
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/shape/
    /// </remarks>
    public class Shape : Item
    {
        public Shape(JSObject jsShape)
            : base(jsShape)
        {
        }

        /// <summary>
        /// Creates a circular Shape item.
        /// </summary>
        public static Shape Circle(Point center, double radius)
        {
            JSObject jsCircle = CreateObjectByMethod(
                "paper.Shape.Circle",
                new object[] { center, radius });
            return new Shape(jsCircle);
        }

        /// <summary>
        /// Creates a rectangular Shape item from the passed point and size.
        /// </summary>
        public static Shape Rectangle(Point point, Size size)
        {
            JSObject jsRectangle = CreateObjectByMethod(
                "paper.Shape.Rectangle",
                new object[] { point, size });
            return new Shape(jsRectangle);
        }

        /// <summary>
        /// The size of the shape.
        /// </summary>
        public Size Size
        {
            get
            {
                JSObject jsSize = _jsObject["size"];
                return jsSize == null ? null : new Size(jsSize);
            }
            set
            {
                _jsObject["size"] = value;
            }
        }
    }
}
