#pragma checksum "C:\Users\qXac\source\repos\ceng382_project10\ceng382_project3\Pages\Contacts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "010a99a767320354a0db90ac7f52dfef37afc4da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ceng382_project3.Pages.Pages_Contacts), @"mvc.1.0.razor-page", @"/Pages/Contacts.cshtml")]
namespace ceng382_project3.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\qXac\source\repos\ceng382_project10\ceng382_project3\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\qXac\source\repos\ceng382_project10\ceng382_project3\Pages\_ViewImports.cshtml"
using ceng382_project3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\qXac\source\repos\ceng382_project10\ceng382_project3\Pages\_ViewImports.cshtml"
using ceng382_project3.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\qXac\source\repos\ceng382_project10\ceng382_project3\Pages\_ViewImports.cshtml"
using ceng382_project3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"010a99a767320354a0db90ac7f52dfef37afc4da", @"/Pages/Contacts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cbdbc8cd5e09a7f73a00a8f533acb0267269d66", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Contacts : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("php/contact-form.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contact-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\qXac\source\repos\ceng382_project10\ceng382_project3\Pages\Contacts.cshtml"
  
    ViewData["Title"] = "Contact Page";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Page Heading -->
<section class=""page-heading"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-6"">
                <h1>Contacts</h1>
            </div>
            <div class=""col-md-6"">
                <ul class=""breadcrumb"">
                    <li><a href=""index.html"">Home</a></li>
                    <li class=""active"">Contacts</li>
                </ul>
            </div>
        </div>
    </div>
</section>
<!-- Page Heading / End -->
<!-- Page Content -->
<section class=""page-content"">

    <div class=""container"">

        <!-- Google Map -->
        <div class=""googlemap-wrapper"">
            <div id=""map_canvas"" class=""map-canvas"">
                <!--<iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3064.4811180279085!2d32.56034201563584!3d39.81862949971977!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14d317c30f845953%3A0x5f3e95544c6eecc7!2s%C3%87ankaya%20%C3%9Cniversitesi!5e0!3m2!1str!2str!4v1616255666289!");
            WriteLiteral(@"5m2!1str!2str""  allowfullscreen="""" loading=""lazy""></iframe> -->
                <iframe src=""https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12257.925203365996!2d32.5625307!3d39.8186254!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x5f3e95544c6eecc7!2s%C3%87ankaya%20%C3%9Cniversitesi!5e0!3m2!1str!2str!4v1623067205611!5m2!1str!2str"" width=""1126"" height=""390"" style=""border:0;""");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 1549, "\"", 1567, 0);
            EndWriteAttribute();
            WriteLiteral(@" loading=""lazy""></iframe>
            </div>
        </div>
        <!-- Google Map / End -->

        <div class=""row"">
            <div class=""col-md-4"">
                <hr class=""visible-sm visible-xs lg"">
                <!-- Widget :: Contacts Info -->
                <div class=""contacts-widget widget widget__sidebar"">
                    <h3 class=""widget-title"">Contact Info</h3>
                    <div class=""widget-content"">
                        <ul class=""contacts-info-list"">
                            <li>
                                <i class=""fa fa-map-marker""></i>
                                <div class=""info-item"">
                                    Babysitter Co., Çankaya, Ankara, TURKEY 23000
                                </div>
                            </li>
                            <li>
                                <i class=""fa fa-phone""></i>
                                <div class=""info-item"">
                                    +90 537 537 ");
            WriteLiteral(@"5337<br>
                                    +90 537 537 5338
                                </div>
                            </li>
                            <li>
                                <i class=""fa fa-envelope""></i>
                                <span class=""info-item"">
                                    <a href=""mailto:info@dan-fisher.com"">info@babysitter.com</a>
                                </span>
                            </li>
                            <li>
                                <i class=""fa fa-skype""></i>
                                <div class=""info-item"">
                                    <a href=""#"">baby_sitter</a><br>
                                    <a href=""#"">help_babysitter</a>
                                </div>
                            </li>
                            <li>
                                <i class=""fa fa-clock-o""></i>
                                <div class=""info-item"">
                                    ");
            WriteLiteral(@"Monday - Friday 9:00 - 21:00
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <!-- /Widget :: Contacts Info -->
            </div>
            <div class=""col-md-8"">
                <h2>Contact Form</h2>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "010a99a767320354a0db90ac7f52dfef37afc4da8768", async() => {
                WriteLiteral(@"

                    <div class=""alert alert-success hidden"" id=""contact-alert-success"">
                        <strong>Success!</strong> Thank you for your message. Reply will be in a while!
                    </div>
                    <div class=""alert alert-danger hidden"" id=""contact-alert-error"">
                        <strong>Error!</strong> Something went wrong sending your message.
                    </div>

                    <div class=""row"">
                        <div class=""col-md-5"">
                            <div class=""form-group"">
                                <label>Name <span class=""required"">*</span></label>
                                <input type=""text""");
                BeginWriteAttribute("value", "\r\n                                       value=\"", 4730, "\"", 4778, 0);
                EndWriteAttribute();
                WriteLiteral(@"
                                       data-msg-required=""Please enter your name.""
                                       class=""form-control""
                                       name=""name"" id=""name"">
                            </div>
                            <div class=""form-group"">
                                <label>Email <span class=""required"">*</span></label>
                                <input type=""email""");
                BeginWriteAttribute("value", "\r\n                                       value=\"", 5216, "\"", 5264, 0);
                EndWriteAttribute();
                WriteLiteral(@"
                                       data-msg-required=""Please enter your email address.""
                                       data-msg-email=""Please enter a valid email address.""
                                       class=""form-control""
                                       name=""email""
                                       id=""email"">
                            </div>
                            <div class=""form-group"">
                                <label>Subject</label>
                                <input type=""text""");
                BeginWriteAttribute("value", "\r\n                                       value=\"", 5815, "\"", 5863, 0);
                EndWriteAttribute();
                WriteLiteral(@"
                                       data-msg-required=""Please enter the subject.""
                                       class=""form-control""
                                       name=""subject""
                                       id=""subject"">
                            </div>
                        </div>
                        <div class=""col-md-7"">
                            <div class=""form-group"">
                                <label>Message <span class=""required"">*</span></label>
                                <textarea data-msg-required=""Please enter your message.""
                                          rows=""11""
                                          class=""form-control""
                                          name=""message""
                                          id=""message""></textarea>
                            </div>
                        </div>
                    </div>
                    <div class=""text-right"">
                        <input ty");
                WriteLiteral("pe=\"submit\" value=\"Send Message\" class=\"btn btn-primary\" data-loading-text=\"Loading...\">\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n\r\n</section>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ceng382_project3.Pages.ContactsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ceng382_project3.Pages.ContactsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ceng382_project3.Pages.ContactsModel>)PageContext?.ViewData;
        public ceng382_project3.Pages.ContactsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
