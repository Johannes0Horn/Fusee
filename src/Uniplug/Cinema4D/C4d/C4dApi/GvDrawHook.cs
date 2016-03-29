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

public class GvDrawHook : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GvDrawHook(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GvDrawHook obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~GvDrawHook() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_GvDrawHook(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public GvDrawHook() : this(C4dApiPINVOKE.new_GvDrawHook(), true) {
  }

  public BaseDocument document {
    set {
      C4dApiPINVOKE.GvDrawHook_document_set(swigCPtr, BaseDocument.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvDrawHook_document_get(swigCPtr);
      BaseDocument ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseDocument(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_void user {
    set {
      C4dApiPINVOKE.GvDrawHook_user_set(swigCPtr, SWIGTYPE_p_void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvDrawHook_user_get(swigCPtr);
      SWIGTYPE_p_void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
      return ret;
    } 
  }

  public BaseDraw base_draw {
    set {
      C4dApiPINVOKE.GvDrawHook_base_draw_set(swigCPtr, BaseDraw.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvDrawHook_base_draw_get(swigCPtr);
      BaseDraw ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseDraw(cPtr, false);
      return ret;
    } 
  }

  public BaseDrawHelp draw_help {
    set {
      C4dApiPINVOKE.GvDrawHook_draw_help_set(swigCPtr, BaseDrawHelp.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvDrawHook_draw_help_get(swigCPtr);
      BaseDrawHelp ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseDrawHelp(cPtr, false);
      return ret;
    } 
  }

  public BaseThread base_thread {
    set {
      C4dApiPINVOKE.GvDrawHook_base_thread_set(swigCPtr, BaseThread.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvDrawHook_base_thread_get(swigCPtr);
      BaseThread ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseThread(cPtr, false);
      return ret;
    } 
  }

  public int flags {
    set {
      C4dApiPINVOKE.GvDrawHook_flags_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.GvDrawHook_flags_get(swigCPtr);
      return ret;
    } 
  }

}

}
