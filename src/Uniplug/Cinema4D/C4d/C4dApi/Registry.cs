//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace C4d {

public class Registry : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Registry(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Registry obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public Registry GetNext() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Registry_GetNext(swigCPtr);
    Registry ret = (cPtr == global::System.IntPtr.Zero) ? null : new Registry(cPtr, false);
    return ret;
  }

  public Registry GetPred() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Registry_GetPred(swigCPtr);
    Registry ret = (cPtr == global::System.IntPtr.Zero) ? null : new Registry(cPtr, false);
    return ret;
  }

  public REGISTRYTYPE GetMainID() {
    REGISTRYTYPE ret = (REGISTRYTYPE)C4dApiPINVOKE.Registry_GetMainID(swigCPtr);
    return ret;
  }

  public int GetSubID() {
    int ret = C4dApiPINVOKE.Registry_GetSubID(swigCPtr);
    return ret;
  }

  public SWIGTYPE_p_void GetData() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.Registry_GetData(swigCPtr);
    SWIGTYPE_p_void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
    return ret;
  }

}

}
