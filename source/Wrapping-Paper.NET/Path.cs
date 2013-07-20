
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
    /// The Path item represents a path in a Paper.js project.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/path/
    /// </remarks>
    public class Path : Item
    {
        public Path() :
            base(CreateObjectByTypeName("paper.Path", null))
        {

        }

        public Path(JSObject jsPath)
            : base(jsPath)
        {
        }

        public static Path Circle(Point center, double radius)
        {
            JSObject jsCircle = CreateObjectByMethod(
                "paper.Path.Circle", 
                new object[] { center, radius });
            return new Path(jsCircle);
        }
    }
}
