
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;

namespace cfg
{
public partial class Tables
{
    public TBJump TBJump {get; }
    public TBPopupWindow TBPopupWindow {get; }

    public Tables(System.Func<string, JSONNode> loader)
    {
        TBJump = new TBJump(loader("tbjump"));
        TBPopupWindow = new TBPopupWindow(loader("tbpopupwindow"));
        ResolveRef();
    }
    
    private void ResolveRef()
    {
        TBJump.ResolveRef(this);
        TBPopupWindow.ResolveRef(this);
    }
}

}
