
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
    /// A Rectangle specifies an area that is enclosed by it's top-left point 
    /// (x, y), its width, and its height. It should not be confused with a 
    /// rectangular path, it is not an item.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/rectangle/
    /// </remarks>
    public class Rectangle : BaseWrapper
    {
        public Rectangle(JSObject jsRectangle)
            : base(jsRectangle)
        {
        }

        /// <summary>
        /// The x position of the rectangle.
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
        /// The y position of the rectangle.
        /// </summary>
        public double Y
        {
            get
            {
                JSValue jsY = _jsObject["y"];
                return (double)jsY;
            }
        }

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        public double Width
        {
            get
            {
                JSValue jsWidth = _jsObject["width"];
                return (double)jsWidth;
            }
        }

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        public double Height
        {
            get
            {
                JSValue jsHeight = _jsObject["height"];
                return (double)jsHeight;
            }
        }

    }
}
