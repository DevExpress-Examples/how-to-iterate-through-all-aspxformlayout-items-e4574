﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxFormLayout;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {  }
    protected void ASPxButton1_Click(object sender, EventArgs e) {
        foreach(var item in layout.Items) {
            if(item is LayoutGroupBase)
                (item as LayoutGroupBase).ForEach(GetNestedControls);
        }
    }
    void GetNestedControls(LayoutItemBase item) {
        foreach(LayoutItemBase c in item.Collection) {
            if(c is LayoutGroup)
                (c as LayoutGroup).ForEach(GetNestedControls);
            if(c is LayoutItem)
                SetValue(c as LayoutItem);
        }
    }
    static void SetValue(LayoutItem c) {
        foreach(Control control in c.LayoutItemNestedControlContainer.Controls) {
            ASPxEdit editor = control as ASPxEdit;
            if(editor != null)
                editor.Value = DateTime.Now.ToString();
        }
    }
}