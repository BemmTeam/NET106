#pragma checksum "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee8738abbf71cf8eb6b3fbb40d4f064a257379fe"
// <auto-generated/>
#pragma warning disable 1591
namespace ASM.SERVER.Pages.Product
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using ASM.SERVER;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using ASM.SERVER.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using ASM.SHARE.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using ASM.SERVER.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using Smart.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Study\NET106\ASM\ASM.SERVER\_Imports.razor"
using ASM.SERVER.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
using System.Reflection;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
using System.ComponentModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
using ASM.SHARE.Helper;

#line default
#line hidden
#nullable disable
    public partial class DetailProductModal : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "modal fade show ");
            __builder.AddAttribute(2, "id", "myModal");
            __builder.AddAttribute(3, "style", "display:block; background-color: rgba(10,10,10,.8); ");
            __builder.AddAttribute(4, "aria-modal", "true");
            __builder.AddAttribute(5, "role", "dialog");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "modal-dialog modal-dialog-centered ");
            __builder.AddAttribute(8, "style", "min-width:50%");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "modal-content");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "modal-header  bg-dark ");
            __builder.OpenElement(13, "h5");
            __builder.AddAttribute(14, "class", "modal-title text-light");
            __builder.AddAttribute(15, "id", "exampleModalLabel");
            __builder.AddContent(16, 
#nullable restore
#line 11 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                   Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n        ");
            __builder.OpenElement(18, "button");
            __builder.AddAttribute(19, "type", "button");
            __builder.AddAttribute(20, "class", "btn-close btn-danger text-light fs-3");
            __builder.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                                      ModalCancel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(22, "data-bs-dismiss", "modal");
            __builder.AddAttribute(23, "aria-label", "Close");
            __builder.AddContent(24, "X");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n      ");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "modal-body");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "row");
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "col-6");
            __builder.AddMarkupContent(32, "<div class=\"col-sm-12  fw-bold fs-5\">Tên sản phẩm</div>\r\n\r\n                  ");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "col-sm-10 font-monospace");
            __builder.OpenElement(35, "span");
            __builder.AddAttribute(36, "style", " white-space: nowrap;   overflow: hidden; text-overflow: ellipsis; /* text-overflow: clip; */");
            __builder.AddContent(37, 
#nullable restore
#line 22 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                                                                                       Model.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n                       <hr>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n            \r\n\r\n    \r\n             ");
            __builder.OpenElement(40, "div");
            __builder.AddAttribute(41, "class", "col-6");
            __builder.AddMarkupContent(42, "<div class=\"col-sm-12  fw-bold fs-5\">Giá sản phẩm</div>\r\n\r\n                  ");
            __builder.OpenElement(43, "div");
            __builder.AddAttribute(44, "class", "col-sm-10 font-monospace");
            __builder.OpenElement(45, "span");
            __builder.AddAttribute(46, "style", " white-space: nowrap;   overflow: hidden; text-overflow: ellipsis; /* text-overflow: clip; */");
            __builder.AddContent(47, 
#nullable restore
#line 34 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                                                                                       Model.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n                       <hr>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n            \r\n   \r\n\r\n\r\n   \r\n             ");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "col-6");
            __builder.AddMarkupContent(52, "<div class=\"col-sm-12  fw-bold fs-5\">Số lượng</div>\r\n\r\n                  ");
            __builder.OpenElement(53, "div");
            __builder.AddAttribute(54, "class", "col-sm-10 font-monospace");
            __builder.OpenElement(55, "span");
            __builder.AddAttribute(56, "style", " white-space: nowrap;   overflow: hidden; text-overflow: ellipsis; /* text-overflow: clip; */");
            __builder.AddContent(57, 
#nullable restore
#line 48 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                                                                                       Model.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                       <hr>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n            \r\n    \r\n\r\n\r\n    \r\n             ");
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "class", "col-6");
            __builder.AddMarkupContent(62, "<div class=\"col-sm-12  fw-bold fs-5\">Danh mục</div>\r\n\r\n                  ");
            __builder.OpenElement(63, "div");
            __builder.AddAttribute(64, "class", "col-sm-10 font-monospace");
            __builder.OpenElement(65, "span");
            __builder.AddAttribute(66, "style", " white-space: nowrap;   overflow: hidden; text-overflow: ellipsis; /* text-overflow: clip; */");
            __builder.AddContent(67, 
#nullable restore
#line 62 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                                                                                       Model.Category.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n                       <hr>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n            \r\n   \r\n\r\n      \r\n             ");
            __builder.OpenElement(70, "div");
            __builder.AddAttribute(71, "class", "col-6");
            __builder.AddMarkupContent(72, "<div class=\"col-sm-12  fw-bold fs-5\">Địa chỉ</div>\r\n\r\n                  ");
            __builder.OpenElement(73, "div");
            __builder.AddAttribute(74, "class", "col-sm-10 font-monospace");
            __builder.OpenElement(75, "span");
            __builder.AddAttribute(76, "style", " white-space: nowrap;   overflow: hidden; text-overflow: ellipsis; /* text-overflow: clip; */");
            __builder.AddContent(77, 
#nullable restore
#line 75 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                                                                                       Model.Address

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(78, "\r\n                       <hr>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n            \r\n     \r\n\r\n  \r\n             ");
            __builder.OpenElement(80, "div");
            __builder.AddAttribute(81, "class", "col-6");
            __builder.AddMarkupContent(82, "<div class=\"col-sm-12  fw-bold fs-5\">Mô tả</div>\r\n\r\n                  ");
            __builder.OpenElement(83, "div");
            __builder.AddAttribute(84, "class", "col-sm-10 font-monospace");
            __builder.OpenElement(85, "span");
            __builder.AddAttribute(86, "style", " white-space: nowrap;   overflow: hidden; text-overflow: ellipsis; /* text-overflow: clip; */");
            __builder.AddContent(87, 
#nullable restore
#line 88 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                                                                                       Model.Desc

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n                       <hr>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n            \r\n    \r\n      \r\n             ");
            __builder.OpenElement(90, "div");
            __builder.AddAttribute(91, "class", "col-6");
            __builder.AddMarkupContent(92, "<div class=\"col-sm-12  fw-bold fs-5\">Hình ảnh</div>\r\n\r\n                  ");
            __builder.OpenElement(93, "div");
            __builder.AddAttribute(94, "class", "col-sm-10 font-monospace");
            __builder.OpenElement(95, "img");
            __builder.AddAttribute(96, "src", 
#nullable restore
#line 100 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                     Model.ThumbString

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(97, "width", "300");
            __builder.AddAttribute(98, "height", "250");
            __builder.CloseElement();
            __builder.AddMarkupContent(99, "\r\n                       <hr>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\r\n            \r\n   \r\n\r\n    \r\n             ");
            __builder.OpenElement(101, "div");
            __builder.AddAttribute(102, "class", "col-6");
            __builder.AddMarkupContent(103, "<div class=\"col-sm-12  fw-bold fs-5\">QR code</div>\r\n\r\n                  ");
            __builder.OpenElement(104, "div");
            __builder.AddAttribute(105, "class", "col-sm-10 font-monospace");
            __builder.OpenElement(106, "img");
            __builder.AddAttribute(107, "src", 
#nullable restore
#line 113 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                     qRCodeHelper.GenerateQrCodeString(Model.QrCodeUrl)

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(108, "width", "300");
            __builder.AddAttribute(109, "height", "250");
            __builder.CloseElement();
            __builder.AddMarkupContent(110, "\r\n                       <hr>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(111, "\r\n  \r\n\r\n\r\n      ");
            __builder.OpenElement(112, "div");
            __builder.AddAttribute(113, "class", "modal-footer");
            __builder.OpenElement(114, "button");
            __builder.AddAttribute(115, "type", "button");
            __builder.AddAttribute(116, "class", "btn btn-secondary");
            __builder.AddAttribute(117, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 124 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
                                                                    ModalCancel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(118, "data-bs-dismiss", "modal");
            __builder.AddContent(119, "Close");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 131 "D:\Study\NET106\ASM\ASM.SERVER\Pages\Product\DetailProductModal.razor"
       

     [Inject]
        private QRcodeHelper qRCodeHelper { get; set; }

    [Parameter]
    public Product Model { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public EventCallback<bool> OnClose { get; set; }

    protected override Task OnInitializedAsync()
    {

        return base.OnInitializedAsync();
    }

    private Task ModalCancel()
    {
        return OnClose.InvokeAsync(false);
    }

    private Task ModalOk()
    {
        return OnClose.InvokeAsync(true);
    }



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
