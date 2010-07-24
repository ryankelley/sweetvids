<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Videos.aspx.cs" Inherits="SweetVids.Web.Actions.Videos.Videos"
    MasterPageFile="~/Shared/Site.Master" %>

<%@ Import Namespace="SweetVids.Web" %>

<%@ Import Namespace="SweetVids.Web.Actions.Videos" %>
<asp:Content ContentPlaceHolderID="_headerContent" runat="server">
    <script type="text/javascript">
        jQuery(function ($) {
            $('#video-form-wrapper').slideToggle();

            $('#submit-button').click(function () {
                $('#video-form-wrapper').slideToggle('open');
            });
        });
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="_mainContent" runat="server">
    <div class="grid_16">
        <div class="grid_3 prefix_1 suffix_1 alpha ">
            <a href="#" id="submit-button">
                <h6 class="color1">
                    submit a sweet vid</h6>
            </a>
        </div>
        <div class="grid_3 suffix_8 omega">
            <a href="#" id="hater-button">
                <h6 class="color1">
                    send us hate mail</h6>
            </a>
        </div>
    </div>
    <% this.Partial(new AddVideoFormRequest()); %>
    <%= this.PartialForEach(x => x.Videos).Using<VideoControl>() %>

    <div class="mod grid_16">
        <div class="inner">
           <div class="bd grid_10 prefix_3 suffix_3 comment-line">
              <%= this.Pagination(Urls.UrlFor(new ListVideosRequest(){}),Model.Page, Model.Total) %>
           </div>
        </div>
    </div>
</asp:Content>
