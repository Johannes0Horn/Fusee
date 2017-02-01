﻿using System.Collections.Generic;
using System.Linq;
using Fusee.Base.Core;
using Fusee.Jometri.DCEL;
using Fusee.Math.Core;

namespace Fusee.Jometri
{
    /// <summary>
    /// Provides utility methodes used in the Jometri project.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Calculates the vertex position so that it is parallel to the x-y plane.
        /// </summary>
        /// <param name="vertPos">Original vertex position.</param>
        /// <param name="normal">The normal of the polygon the vertex belongs to. Used as new Z axis</param>
        /// <returns></returns>
        internal static float3 Reduce2D(this float3 vertPos, float3 normal)
        {
            //Set of orthonormal vectors
            normal.Normalize(); //new z axis

            /*if (normal == float3.UnitZ)
            {
                var rotMat = float4x4.CreateRotationY(M.Pi);
                return vertPos * rotMat;
            }*/

            var v2 = float3.Cross(normal, float3.UnitZ); //rotation axis - new x axis

            //float3.Cross ==  float3.Zero if the two vectors are parallel to each other - if the normal is parallel to the z  axis the z component of the vertPos must be 0 already
            if (v2 == float3.Zero)
                return vertPos;

            v2.Normalize();
            var v3 = float3.Cross(normal, v2); //new y axis
            v3.Normalize();

            //Calculate change-of-basis matrix (orthonormal matrix).
            var row1 = new float3(v3.x, v2.x, normal.x);
            var row2 = new float3(v3.y, v2.y, normal.y);
            var row3 = new float3(v3.z, v2.z, normal.z);

            //vector in new basis * changeOfBasisMat = vector in old basis
            var changeOfBasisMat = new float3x3(row1, row2, row3);

            //In an orthonomal matrix the inverse equals the transpose, therefor the transpose can be used to calculate vector in new basis (transpose * vector = vector in new basis).
            var transposeMat = new float3x3(changeOfBasisMat.Row0, changeOfBasisMat.Row1, changeOfBasisMat.Row2);
            transposeMat.Transpose();

            var newVert = transposeMat * vertPos;


            //Round to get rid of potential exponent representation
            var vecX = System.Math.Round((decimal)newVert.x, 5);
            var vecY = System.Math.Round((decimal)newVert.y, 5);
            var vecZ = System.Math.Round((decimal)newVert.z, 5);

            newVert = new float3((float)vecX, (float)vecY, (float)vecZ);

            return newVert;
        }


        /// <summary>
        /// Sets the normal of the face in its FaceData.
        /// </summary>
        /// <param name="geometry">The geometry the face belongs to.</param>
        /// <param name="faceOuterVertices">All vertices of the outer boundary of the face.</param>
        /// <param name="face">The face in question.</param>
        public static void SetFaceNormal(this Geometry geometry, IList<Vertex> faceOuterVertices, Face face)
        {
            var normal = CalculateFaceNormal(faceOuterVertices);

            var cur = geometry.DictFaces[face.Handle];
            var faceData = face.FaceData;
            faceData.FaceNormal = normal;
            cur.FaceData = faceData;
            geometry.DictFaces[face.Handle] = cur;

        }

        //Newell's Method - see Graphics Gems III, p. 232.
        /// <summary>
        /// Calculates a face normal from three vertices. The vertices have to be coplanar and part of the face.
        /// </summary>
        /// <param name="faceOuterVertices">All vertices of the outer boundary of the face.</param>
        /// <returns></returns>
        private static float3 CalculateFaceNormal(IList<Vertex> faceOuterVertices)
        {
            var normal = new float3();
            for (var i = 0; i < faceOuterVertices.Count; i++)
            {
                var vCur = faceOuterVertices[i].VertData.Pos;
                var vNext = faceOuterVertices[(i + 1) % faceOuterVertices.Count].VertData.Pos;

                normal.x += (vCur.y - vNext.y) * (vCur.z + vNext.z);
                normal.y += (vCur.z - vNext.z) * (vCur.x + vNext.x);
                normal.z += (vCur.x - vNext.x) * (vCur.y + vNext.y);
            }
            normal = normal * -1;
            normal.Normalize();

            return normal;

        }

        //Vertices need to be reduced to 2D
        //see Akenine-Möller, Tomas; Haines, Eric; Hoffman, Naty (2016): Real-Time Rendering, p. 754
        /// <summary>
        /// Tests if a point/vertex lies inside or outside a face - only works for polygons parallel to the xy plane!
        /// </summary>
        /// <param name="geometry">The geometry to which the polygon (here: face) belongs.</param>
        /// <param name="face">The face to perform the test on.</param>
        /// <param name="v">The vertex to be tested.</param>
        /// <returns></returns>
        public static bool IsPointInPolygon(this Geometry geometry, Face face, Vertex v)
        {
            var inside = false;
            var faceVerts = geometry.GetFaceVertices(face.Handle).ToList();

            var vPos = geometry.Get2DVertPos(face, v.Handle);

            var v1 = geometry.GetVertexByHandle(faceVerts.LastItem().Handle);
            var v1Pos = geometry.Get2DVertPos(face, v1.Handle);

            var y0 = v1Pos.y >= vPos.y;

            foreach (var vert in faceVerts)
            {
                var e1Pos = geometry.Get2DVertPos(face, vert.Handle);

                var y1 = e1Pos.y >= vPos.y;
                if (y0 != y1)
                {
                    if ((e1Pos.y - vPos.y) * (v1Pos.x - e1Pos.x) >=
                        (e1Pos.x - vPos.x) * (v1Pos.y - e1Pos.y) == y1)
                    {
                        inside = !inside;
                    }
                }
                y0 = y1;
                v1Pos = e1Pos;
            }
            return inside;
        }

        //Vertices need to be reduced to 2D.
        /// <summary>
        /// Determines if the angle between two vectors, formed by three vertices, is greater 180°.
        /// Vector one will be created from v1 and v2, vector two from v2 and v3.
        /// </summary>
        /// <param name="geom">The geometry the vertices belong to.</param>
        /// <param name="face">The face the vertices belong to. Needed to correctly reduce the vertex positions to 2D.</param>
        /// <param name="v1">Vertex one</param>
        /// <param name="v2">Vertex two</param>
        /// <param name="v3">Vertex three</param>
        /// <returns></returns>
        public static bool IsAngleGreaterPi(this Geometry geom, Face face, Vertex v1, Vertex v2, Vertex v3)
        {
            var v1Pos = geom.Get2DVertPos(face, v1.Handle);
            var v2Pos = geom.Get2DVertPos(face, v2.Handle);
            var v3Pos = geom.Get2DVertPos(face, v3.Handle);

            var firstVec = v1Pos - v2Pos;
            var secondVec = v3Pos - v2Pos;

            var det = firstVec.x * secondVec.y - firstVec.y * secondVec.x; //determinant / Z component of the cross product / sine / y
            var dot = float3.Dot(firstVec, secondVec); // cosine / x

            var angle = (float)System.Math.Atan2(det, dot);

            if ((angle * -1).Equals(M.Pi))
                return false;
            return angle < 0;
        }

        //Vertices need to be reduced to 2D.
        /// <summary>
        /// Determines if the angle between two vectors, formed by three vertices, is greater or equal 180°.
        /// Vector one will be created from v1 and v2, vector two from v2 and v3.
        /// </summary>
        /// <param name="geom">The geometry the vertices belong to.</param>
        /// <param name="face">The face the vertices belong to. Needed to correctly reduce the vertex positions to 2D.</param>
        /// <param name="v1">Vertex one</param>
        /// <param name="v2">Vertex two</param>
        /// <param name="v3">Vertex three</param>
        /// <returns></returns>
        public static bool IsAngleGreaterOrEqualPi(this Geometry geom, Face face, Vertex v1, Vertex v2, Vertex v3)
        {
            var v1Pos = geom.Get2DVertPos(face, v1.Handle);
            var v2Pos = geom.Get2DVertPos(face, v2.Handle);
            var v3Pos = geom.Get2DVertPos(face, v3.Handle);

            var firstVec = v1Pos - v2Pos;
            var secondVec = v3Pos - v2Pos;

            var cross = firstVec.x * secondVec.y - firstVec.y * secondVec.x; //Z component of the cross product.
            var dot = float3.Dot(firstVec, secondVec);

            var angle = (float)System.Math.Atan2(cross, dot);

            return angle <= 0;
        }

        /// <summary>
        /// Tests if a vertex is a direct neighbour of an other vertex. Use this only if you know the vertices incident half edges. 
        /// </summary>
        /// <param name="geometry">The geometry the vertex belongs to.</param>
        /// <param name="p">First vertex</param>
        /// <param name="q">Secound vertex</param>
        /// <param name="vertPStartHe">p incident half edge </param>
        /// <param name="vertQStartHe">q incident half edge</param>
        /// <returns></returns>
        public static bool IsVertexAdjacentToVertex(this Geometry geometry, int p, int q, HalfEdge vertPStartHe, HalfEdge vertQStartHe)
        {
            var nextHeP = geometry.GetHalfEdgeByHandle(vertPStartHe.NextHalfEdge);
            var nextHeQ = geometry.GetHalfEdgeByHandle(vertQStartHe.NextHalfEdge);

            return nextHeP.OriginVertex == q || nextHeQ.OriginVertex == p;
        }

        /// <summary>
        /// Contains the half edges from a source collection of half edges - with opposite winding.
        /// </summary>
        /// <param name="geometry"></param>
        /// <param name="originHEdges"></param>
        /// <returns></returns>
        public static IEnumerable<HalfEdge> GetHalfEdgesWChangedWinding(this Geometry geometry, IEnumerable<HalfEdge> originHEdges)
        {
            foreach (var hEdge in originHEdges)
            {
                var he = hEdge;
                var next = he.PrevHalfEdge;
                var prev = he.NextHalfEdge;

                he.NextHalfEdge = next;
                he.PrevHalfEdge = prev;

                var newOrigin = geometry.GetHalfEdgeByHandle(he.PrevHalfEdge).OriginVertex;
                he.OriginVertex = newOrigin;

                yield return he;

                var vertToUpdate = geometry.DictVertices[newOrigin];
                vertToUpdate.IncidentHalfEdge = he.Handle;
                geometry.DictVertices[newOrigin] = vertToUpdate;
            }
        }

        //For an explanation of this algorythm see: http://blog.element84.com/polygon-winding.html
        /// <summary>
        /// Checks whether a polygon, parallel to the xy plane, has a ccw winding.
        /// This methode does NOT support polygons parallel to the yz or xz plane!
        /// To guarantee a correct output make sure the polygon does not degenerate when the z coordinates are ignored.
        /// </summary>
        /// <param name="source">The polygon, represented as list of float3.</param>
        /// <returns></returns>
        public static bool IsCounterClockwise(this IList<float3> source)
        {
            var sum = 0f;

            for (var i = 0; i < source.Count; i++)
            {
                var current = source[i]; //new float2(source[i].x, source[i].y);
                var next = source[(i + 1) % source.Count]; //new float2(source[(i + 1) % source.Count].x, source[(i + 1) % source.Count].y);

                sum += (next.x - current.x) * (next.y + current.y);
            }
            return sum < 0;
        }

        //See: Antionio, Franklin - Faster line intersection (1992)
        //Points need to be reduced to 2D!
        //UNTESTED!!
        /// <summary>
        /// Checks if two lines intersect.
        /// </summary>
        /// <param name="p1">First control point of the first line</param>
        /// <param name="p2">Second control point of the first line</param>
        /// <param name="p3">First point of the second line</param>
        /// <param name="p4">Second point of the secornd line</param>
        /// <returns></returns>
        public static bool AreLinesIntersecting(float3 p1, float3 p2, float3 p3, float3 p4)
        {
            var a = p2 - p1;
            var b = p3 - p4;
            var c = p1 - p3;

            var tNumerator = b.y * b.x - b.x * c.y;
            var iNumerator = a.x * c.y - a.y * c.x;

            var denominator = a.y * b.x - a.x * b.y;

            if (denominator > 0)
            {
                if (tNumerator < 0 || tNumerator > denominator)
                    return false;
            }
            else
            {
                if (tNumerator > 0 || tNumerator < denominator)
                    return false;
            }

            if (denominator > 0)
            {
                if (iNumerator < 0 || iNumerator > denominator)
                    return false;
            }
            else
            {
                if (iNumerator > 0 || iNumerator < denominator)
                    return false;
            }

            return true;
        }
    }
}
