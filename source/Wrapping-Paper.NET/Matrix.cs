
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
    /// An affine transform performs a linear mapping from 2D coordinates to 
    /// other 2D coordinates that preserves the "straightness" and 
    /// "parallelness" of lines.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/matrix/
    /// </remarks>
    public class Matrix : BaseWrapper
    {
        /// <summary>
        /// Creates a 2D affine transform.
        /// Parameters:
        /// a: Number — The scaleX coordinate of the transform
        /// c: Number — The shearY coordinate of the transform
        /// b: Number — The shearX coordinate of the transform
        /// d: Number — The scaleY coordinate of the transform
        /// tx: Number — The translateX coordinate of the transform
        /// ty: Number — The translateY coordinate of the transform
        /// </summary>
        public Matrix(double a, double c, double b, double d, double tx, double ty)
            : base(CreateObjectByTypeName("paper.Matrix", new object[] { a, c, b, d, tx, ty }))
        {
        }

        public Matrix(JSObject jsMatrix)
            : base(jsMatrix)
        {
        }

        /// <summary>
        /// The scaling factor in the x-direction (a).
        /// </summary>
        public double ScaleX
        {
            get
            {
                JSValue jsScaleX = _jsObject["scaleX"];
                return (double)jsScaleX;
            }
            set
            {
                _jsObject["scaleX"] = value;
            }
        }

        /// <summary>
        /// The scaling factor in the y-direction (d).
        /// </summary>
        public double ScaleY
        {
            get
            {
                JSValue jsScaleY = _jsObject["scaleY"];
                return (double)jsScaleY;
            }
            set
            {
                _jsObject["scaleY"] = value;
            }
        }

        /// <summary>
        /// The translation in the x-direction (tx).
        /// </summary>
        public double TranslateX
        {
            get
            {
                JSValue jsTranslateX = _jsObject["translateX"];
                return (double)jsTranslateX;
            }
            set
            {
                _jsObject["translateX"] = value;
            }
        }

        /// <summary>
        ///The translation in the y-direction (ty).
        /// </summary>
        public double TranslateY
        {
            get
            {
                JSValue jsTranslateY = _jsObject["translateY"];
                return (double)jsTranslateY;
            }
            set
            {
                _jsObject["translateY"] = value;
            }
        }
    }
}
