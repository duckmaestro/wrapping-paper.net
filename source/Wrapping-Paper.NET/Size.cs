
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
    /// The Size object is used to describe the size or dimensions of 
    /// somethign, through its width and height properties.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/size/
    /// </remarks>
    public class Size : BaseWrapper
    {
        /// <summary>
        /// Creates a Size object with the given width and height values.
        /// </summary>
        public Size(double width, double heght)
            : base(CreateObjectByTypeName("paper.Size", new object[] { width, heght }))
        {
        }

        public Size(JSObject jsSize)
            : base(jsSize)
        {
        }

        /// <summary>
        /// The width of the size
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
        /// The height of the size
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
