﻿using System.Collections.Generic;
using Fusee.Base.Common;
using Fusee.Engine.Common;
using Fusee.Math.Core;

namespace Fusee.Engine.Core
{
    /// <summary>
    /// Use instances of this class to store a set of render states that need to be applied as a whole. 
    /// Instances are used in the effects system to set a couple of states before a render pass is performed.
    /// </summary>
    public class RenderStateSet
    {
        private readonly Dictionary<RenderState, uint> _states = new Dictionary<RenderState, uint>();

        public void SetRenderStates(Dictionary<uint, uint> renderStateContainer)
        {
            foreach (var renderState in renderStateContainer)
            {
                _states[(RenderState)renderState.Key] = renderState.Value;
            }
        }

        #region Butter and bread states
        /////// =======================

        /// <summary>
        /// A value from the <see cref="T:Fusee.Engine.FillMode"/> enumeration that represents the fill mode to apply when rendering triangles.
        /// </summary>
        public FillMode FillMode
        {
            get { return (FillMode)_states[RenderState.FillMode]; }
            set { _states[RenderState.FillMode] = (uint)value; }
        }

        /// <summary>
        /// A value from the <see cref="T:Fusee.Engine.Cull"/> enumeration specifying if and how to cull the two different sides of a triangle.
        /// </summary>
        public Cull CullMode
        {
            get { return (Cull)_states[RenderState.CullMode]; }
            set { _states[RenderState.CullMode] = (uint)value; }
        }

        /// <summary>
        /// Enables or disables primitive (triangle) clipping. Set to true to enable primitive clipping, or false to disable it.
        /// </summary>
        public bool Clipping
        {
            get { return _states[RenderState.Clipping] != 0; }
            set { _states[RenderState.Clipping] = value ? 1U : 0U; }
        }
        #endregion

        #region Blend states
        /////// ============

        /// <summary>
        /// Set to true to enable alpha-blended transparency, or false to disable it.
        /// The type of alpha blending is determined by the <see cref="SourceBlend"/> and <see cref="DestinationBlend"/> render states.
        /// </summary>
        /// <remarks>
        /// Blending describes the process how the pixel generated by the pixel shader is written into the render target buffer. Typically
        /// it is just copied at its respective pixel position, but several operations are possible to perform a calculation between the 
        /// pixel vlaue (rgb and a) already in the buffer and the pixel value (rgb and a) created by the pixel shader. The general blending
        /// assignment is  (always independent for rgb and alpha): 
        /// <code>
        ///      OUTrgb = SRCrgb * SourceBlend       {BlendOperation: [+|-|-inv|min|max]}        DSTrgb * DestinationBlend;
        ///      OUTa   = SRCa   * SourceBlendAlpha  {BlendOperationAlpha: [+|-|-inv|min|max]}   DSTa   * DestinationBlendAlpha;
        /// </code>
        /// where:
        /// <list type="bullet">
        /// <item><description>OUT: The new pixel written to the output buffer</description></item>
        /// <item><description>SRC: The pixel generated by the pixel shader</description></item>
        /// <item><description>DST: The pixel already in the output buffer</description></item>
        /// <item><description>SourceBlend: See the <see cref="SourceBlend"/> attribute</description></item>
        /// <item><description>DestinationBlend: See the <see cref="DestinationBlend"/> attribute</description></item>
        /// <item><description>SourceBlendAlpha: See the <see cref="SourceBlendAlpha"/> attribute</description></item>
        /// <item><description>DestinationBlendAlpha: See the <see cref="DestinationBlendAlpha"/> attribute</description></item>
        /// </list>
        /// The following example shows how to set-up the combiner to use the alpha value passed to gl_FragColor.a in the 
        /// pixel shader as the opacity of the resulting pixel's color. The color is blended between the pixel shader's 
        /// RGB output and the RGB color already in the output buffer.
        /// <code>
        ///     // Switch alpha blending ON
        ///     RC.SetRenderState(new RenderStateSet
        ///     {
        ///         AlphaBlendEnable = true,
        ///         SourceBlend = Blend.SourceAlpha,
        ///         DestinationBlend = Blend.InvSourceAlpha,
        ///         BlendOperation = BlendOperation.Add,
        ///         // In case of particles:
        ///         ZEnable = true,
        ///         ZWriteEnable = false,
        ///     });
        /// 
        ///     // Switch alpha blending OFF
        ///     RC.SetRenderState(RenderState.AlphaBlendEnable, 0);
        /// </code>
        /// </remarks>
        public bool AlphaBlendEnable
        {
            get { return _states[RenderState.AlphaBlendEnable] != 0; }
            set { _states[RenderState.AlphaBlendEnable] = value ? 1U : 0U; }
        }

        /// <summary>
        /// The blend operation to perform for blending rgb values (one of add, subtract, inverted subtract, max, or min).
        /// </summary>
        /// <seealso cref="AlphaBlendEnable"/>
        public BlendOperation BlendOperation
        {
            get { return (BlendOperation)_states[RenderState.BlendOperation]; }
            set { _states[RenderState.BlendOperation] = (uint)value; }
        }

        /// <summary>
        /// The blend operation to perform for blending alpha values (one of add, subtract, inverted subtract, max, or min).
        /// </summary>
        /// <seealso cref="AlphaBlendEnable"/>  
        public BlendOperation BlendOperationAlpha
        {
            get { return (BlendOperation)_states[RenderState.BlendOperationAlpha]; }
            set { _states[RenderState.BlendOperationAlpha] = (uint)value; }
        }

        /// <summary>
        /// Contains a member of the <see cref="T:Fusee.Engine.Blend"/> enumeration that represents the source. 
        /// </summary>
        /// <seealso cref="AlphaBlendEnable"/>
        public Blend SourceBlend
        {
            get { return (Blend)_states[RenderState.SourceBlend]; }
            set { _states[RenderState.SourceBlend] = (uint)value; }
        }

        /// <summary>
        /// Contains a member of the <see cref="T:Fusee.Engine.Blend"/> enumeration that represents the destination. 
        /// </summary>
        /// <seealso cref="AlphaBlendEnable"/>
        public Blend DestinationBlend
        {
            get { return (Blend)_states[RenderState.DestinationBlend]; }
            set { _states[RenderState.DestinationBlend] = (uint)value; }
        }

        /// <summary>
        /// A member of the Blend enumeration that represents the source.
        /// </summary>
        /// <seealso cref="AlphaBlendEnable"/>
        public Blend SourceBlendAlpha
        {
            get { return (Blend)_states[RenderState.SourceBlendAlpha]; }
            set { _states[RenderState.SourceBlendAlpha] = (uint)value; }
        }

        /// <summary>
        /// A member of the Blend enumeration that represents the destination.
        /// </summary>
        /// <seealso cref="AlphaBlendEnable"/>
        public Blend DestinationBlendAlpha
        {
            get { return (Blend)_states[RenderState.DestinationBlendAlpha]; }
            set { _states[RenderState.DestinationBlendAlpha] = (uint)value; }
        }

        /// <summary>
        /// A <see cref="T:Fusee.Math.float4"/> object representing a color used for a constant blend factor during alpha blending.
        /// </summary>
        /// <seealso cref="AlphaBlendEnable"/>
        public float4 BlendFactor
        {
            get { return (float4)(ColorUint)(_states[RenderState.BlendFactor]); }
            set { _states[RenderState.BlendFactor] = (uint)(ColorUint)value; }
        }
        #endregion

        #region Z States
        /////// ========

        /// <summary>
        /// Enables or disables z-buffering (depth buffering).
        /// </summary>
        public bool ZEnable
        {
            get { return _states[RenderState.ZEnable] != 0; }
            set { _states[RenderState.ZEnable] = value ? 1U : 0U; }
        }

        /// <summary>
        /// Determines the comparison function for the z-buffer test. Valid values are members of the <see cref="T:Fusee.Engine.Compare"/> enumeration.
        /// The depth value of the pixel is compared to the z-buffer value. If the depth value of the pixel passes the comparison function, the pixel is written.
        /// </summary>
        public Compare ZFunc
        {
            get { return (Compare)_states[RenderState.ZFunc]; }
            set { _states[RenderState.ZFunc] = (uint)value; }
        }

        /// <summary>
        /// Enables or disables depth buffer writing.
        /// </summary>
        public bool ZWriteEnable

        {
            get { return _states[RenderState.ZWriteEnable] != 0; }
            set { _states[RenderState.ZWriteEnable] = value ? 1U : 0U; }
        }
        #endregion

        /* TODO: Implement texture wrapping rahter as a texture property than a "global" render state. This is most
         * convenient to implment with OpenGL/TK and easier to mimic in DirectX than the other way round.
        
        #region Texture states
        /////// ==============

        /// <summary>
        /// Texture-wrapping behavior for multiple sets of texture coordinates.
        /// Valid values for this render state can be any combination of <see cref="T:Fusee.Engine.TextureWrapping"/>. 
        /// These cause the system to wrap in the direction of the first, second, third, and fourth dimensions, 
        /// sometimes referred to as the u/v/w or the s/t/r/q directions for a given texture.
        /// </summary>
        public TextureWrapping Wrap0
        {
            get { return (TextureWrapping)_states[RenderState.Wrap0]; }
            set { _states[RenderState.Wrap0] = (uint)value; }
        }
            
        /// <summary>
        /// See <see cref="Wrap0"/>.
        /// </summary>
        public TextureWrapping Wrap1
        {
            get { return (TextureWrapping)_states[RenderState.Wrap1]; }
            set { _states[RenderState.Wrap1] = (uint)value; }
        }

        /// <summary>
        /// See <see cref="Wrap0"/>.
        /// </summary>
        public TextureWrapping Wrap2
        {
            get { return (TextureWrapping)_states[RenderState.Wrap2]; }
            set { _states[RenderState.Wrap2] = (uint)value; }
        }

        /// <summary>
        /// See <see cref="Wrap0"/>.
        /// </summary>
        public TextureWrapping Wrap3
        {
            get { return (TextureWrapping)_states[RenderState.Wrap3]; }
            set { _states[RenderState.Wrap3] = (uint)value; }
        }
        #endregion
        */


        /// <summary>
        /// Enumerate this set of render states for its contents
        /// </summary>
        /// <value>An enumerator to be used in loops returning a key and its respective value.</value>
        /// <example>
        /// Use this enumerator in loops to query a RenderStateSet's contents.
        /// <code>
        /// RenderStateSet aRenderStateSet = ...;
        /// foreach (var state in aRenderStateSet.States)
        ///     DoSomethingWithState(state.Key, state.Value);
        /// </code>
        /// </example>
        public IEnumerable<KeyValuePair<RenderState, uint>> States
        {
            get { return _states; }
        }

        // Currently not supported by FUSEE:
        //==================================
        // StencilEnable;
        // StencilFail;
        // StencilZFail;
        // StencilPass;
        // StencilFunc;
        // StencilRef;
        // StencilMask;
        // StencilWriteMask;
        // PointSize;
        // PointSizeMin;
        // PointSpriteEnable;
        // PointScaleEnable;
        // PointScaleA;
        // PointScaleB;
        // PointScaleC;
        // Wrap4;
        // Wrap5;
        // Wrap6;
        // Wrap7;
        // Wrap8;
        // Wrap9;
        // Wrap10;
        // Wrap11;
        // Wrap12;
        // Wrap13;
        // Wrap14;
        // Wrap15;
        // MultisampleAntialias;
        // MultisampleMask;
        // PatchEdgeStyle;
        // DebugMonitorToken;
        // PointSizeMax;
        // IndexedVertexBlendEnable;
        // ColorWriteEnable;
        // TweenFactor;
        // PositionDegree;
        // NormalDegree;
        // ScissorTestEnable;
        // SlopeScaleDepthBias;
        // AntialiasedLineEnable;
        // MinTessellationLevel;
        // MaxTessellationLevel;
        // AdaptiveTessX;
        // AdaptiveTessY;
        // AdaptiveTessZ;
        // AdaptiveTessW;
        // EnableAdaptiveTessellation;
        // TwoSidedStencilMode;
        // CcwStencilFail;
        // CcwStencilZFail;
        // CcwStencilPass;
        // CcwStencilFunc;
        // ColorWriteEnable1;
        // ColorWriteEnable2;
        // ColorWriteEnable3;
        // SrgbWriteEnable;
        // DepthBias;



        // Obsolete with Shaders: 
        //=======================
        // ShadeMode ShadeMode;
        // ZWriteEnable;
        // AlphaRef;
        // AlphaFunc;
        // DitherEnable;
        // FogEnable;
        // SpecularEnable;
        // FogColor;
        // FogTableMode;
        // FogStart;
        // FogEnd;
        // FogDensity;
        // RangeFogEnable;
        // TextureFactor;
        // Lighting;
        // Ambient;
        // FogVertexMode;
        // ColorVertex;
        // LocalViewer;
        // NormalizeNormals;
        // DiffuseMaterialSource;
        // SpecularMaterialSource;
        // AmbientMaterialSource;
        // EmissiveMaterialSource;
        // VertexBlend;
        // ClipPlaneEnable;

        /* Obsolete - separate alpha is always enabled. Older graphics hardware implementation is not supported
        /// <summary>
        /// Enables or disables the separate for the alpha channel.
        /// When set to false, the render target blending factors and operations applied to alpha are forced to be the same as those defined for color. 
        /// A number of graphics hardware and implementations do not support handling seprate alpha. In this case, this render state behaves as if set to false.
        /// The type of separate alpha blending is controlled by <see cref="SourceBlendAlpha"/> and <see cref="DestinationBlendAlpha"/>.
        /// </summary>
        public bool SeparateAlphaBlendEnable
        {
            get { return _states[RenderState.SeparateAlphaBlendEnable] != 0; }
            set { _states[RenderState.SeparateAlphaBlendEnable] = value ? 1U : 0U; }
        }
        */



    }
}