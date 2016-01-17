/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace C4d {

public class CAPoseMorphTag : BaseTag {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal CAPoseMorphTag(global::System.IntPtr cPtr, bool cMemoryOwn) : base(C4dApiPINVOKE.CAPoseMorphTag_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CAPoseMorphTag obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static CAPoseMorphTag Alloc() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.CAPoseMorphTag_Alloc();
    CAPoseMorphTag ret = (cPtr == global::System.IntPtr.Zero) ? null : new CAPoseMorphTag(cPtr, false);
    return ret;
  }

  public static void Free(SWIGTYPE_p_p_CAPoseMorphTag pTag) {
    C4dApiPINVOKE.CAPoseMorphTag_Free(SWIGTYPE_p_p_CAPoseMorphTag.getCPtr(pTag));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public int GetMorphCount() {
    int ret = C4dApiPINVOKE.CAPoseMorphTag_GetMorphCount(swigCPtr);
    return ret;
  }

  public CAMorph GetMorph(int index) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.CAPoseMorphTag_GetMorph(swigCPtr, index);
    CAMorph ret = (cPtr == global::System.IntPtr.Zero) ? null : new CAMorph(cPtr, false);
    return ret;
  }

  public DescID GetMorphID(int index) {
    DescID ret = new DescID(C4dApiPINVOKE.CAPoseMorphTag_GetMorphID(swigCPtr, index), true);
    return ret;
  }

  public int GetActiveMorphIndex() {
    int ret = C4dApiPINVOKE.CAPoseMorphTag_GetActiveMorphIndex(swigCPtr);
    return ret;
  }

  public int GetMode() {
    int ret = C4dApiPINVOKE.CAPoseMorphTag_GetMode(swigCPtr);
    return ret;
  }

  public CAMorph GetActiveMorph() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.CAPoseMorphTag_GetActiveMorph(swigCPtr);
    CAMorph ret = (cPtr == global::System.IntPtr.Zero) ? null : new CAMorph(cPtr, false);
    return ret;
  }

  public CAMorph GetMorphBase() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.CAPoseMorphTag_GetMorphBase(swigCPtr);
    CAMorph ret = (cPtr == global::System.IntPtr.Zero) ? null : new CAMorph(cPtr, false);
    return ret;
  }

  public CAMorph AddMorph() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.CAPoseMorphTag_AddMorph(swigCPtr);
    CAMorph ret = (cPtr == global::System.IntPtr.Zero) ? null : new CAMorph(cPtr, false);
    return ret;
  }

  public void RemoveMorph(int index) {
    C4dApiPINVOKE.CAPoseMorphTag_RemoveMorph(swigCPtr, index);
  }

  public void InitMorphs() {
    C4dApiPINVOKE.CAPoseMorphTag_InitMorphs(swigCPtr);
  }

  public void UpdateMorphs(BaseDocument doc) {
    C4dApiPINVOKE.CAPoseMorphTag_UpdateMorphs__SWIG_0(swigCPtr, BaseDocument.getCPtr(doc));
  }

  public void UpdateMorphs() {
    C4dApiPINVOKE.CAPoseMorphTag_UpdateMorphs__SWIG_1(swigCPtr);
  }

  public int GetMorphIndex(CAMorph morph) {
    int ret = C4dApiPINVOKE.CAPoseMorphTag_GetMorphIndex(swigCPtr, CAMorph.getCPtr(morph));
    return ret;
  }

  public bool ExitEdit(BaseDocument doc, bool apply) {
    bool ret = C4dApiPINVOKE.CAPoseMorphTag_ExitEdit(swigCPtr, BaseDocument.getCPtr(doc), apply);
    return ret;
  }

  public void SetActiveMorphIndex(int index) {
    C4dApiPINVOKE.CAPoseMorphTag_SetActiveMorphIndex(swigCPtr, index);
  }

}

}