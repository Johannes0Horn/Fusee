//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.8
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace C4d {

public class InExcludeData : CustomDataType {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal InExcludeData(global::System.IntPtr cPtr, bool cMemoryOwn) : base(C4dApiPINVOKE.InExcludeData_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(InExcludeData obj) {
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

  public bool InsertObject(BaseList2D pObject, int lFlags) {
    bool ret = C4dApiPINVOKE.InExcludeData_InsertObject(swigCPtr, BaseList2D.getCPtr(pObject), lFlags);
    return ret;
  }

  public int GetObjectIndex(BaseDocument doc, BaseList2D pObject) {
    int ret = C4dApiPINVOKE.InExcludeData_GetObjectIndex(swigCPtr, BaseDocument.getCPtr(doc), BaseList2D.getCPtr(pObject));
    return ret;
  }

  public bool DeleteObject(BaseDocument doc, BaseList2D pObject) {
    bool ret = C4dApiPINVOKE.InExcludeData_DeleteObject__SWIG_0(swigCPtr, BaseDocument.getCPtr(doc), BaseList2D.getCPtr(pObject));
    return ret;
  }

  public int GetFlags(int lIndex) {
    int ret = C4dApiPINVOKE.InExcludeData_GetFlags__SWIG_0(swigCPtr, lIndex);
    return ret;
  }

  public void SetFlags(int lIndex, int lFlags) {
    C4dApiPINVOKE.InExcludeData_SetFlags(swigCPtr, lIndex, lFlags);
  }

  public int GetFlags(BaseDocument doc, BaseList2D pObject) {
    int ret = C4dApiPINVOKE.InExcludeData_GetFlags__SWIG_1(swigCPtr, BaseDocument.getCPtr(doc), BaseList2D.getCPtr(pObject));
    return ret;
  }

  public BaseContainer GetData(int lIndex) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.InExcludeData_GetData__SWIG_0(swigCPtr, lIndex);
    BaseContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseContainer(cPtr, false);
    return ret;
  }

  public BaseContainer GetData(BaseDocument doc, BaseList2D pObject) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.InExcludeData_GetData__SWIG_1(swigCPtr, BaseDocument.getCPtr(doc), BaseList2D.getCPtr(pObject));
    BaseContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseContainer(cPtr, false);
    return ret;
  }

  public BaseList2D ObjectFromIndex(BaseDocument doc, int lIndex) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.InExcludeData_ObjectFromIndex(swigCPtr, BaseDocument.getCPtr(doc), lIndex);
    BaseList2D ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseList2D(cPtr, false);
    return ret;
  }

  public InclusionTable BuildInclusionTable(BaseDocument doc, int hierarchy_bit) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.InExcludeData_BuildInclusionTable__SWIG_0(swigCPtr, BaseDocument.getCPtr(doc), hierarchy_bit);
    InclusionTable ret = (cPtr == global::System.IntPtr.Zero) ? null : new InclusionTable(cPtr, false);
    return ret;
  }

  public InclusionTable BuildInclusionTable(BaseDocument doc) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.InExcludeData_BuildInclusionTable__SWIG_1(swigCPtr, BaseDocument.getCPtr(doc));
    InclusionTable ret = (cPtr == global::System.IntPtr.Zero) ? null : new InclusionTable(cPtr, false);
    return ret;
  }

  public bool DeleteObject(int lIndex) {
    bool ret = C4dApiPINVOKE.InExcludeData_DeleteObject__SWIG_1(swigCPtr, lIndex);
    return ret;
  }

  public int GetObjectCount() {
    int ret = C4dApiPINVOKE.InExcludeData_GetObjectCount(swigCPtr);
    return ret;
  }

}

}
