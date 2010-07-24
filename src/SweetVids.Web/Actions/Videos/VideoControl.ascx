<%@ Control Language="C#" AutoEventWireup="true" Inherits="SweetVids.Web.Actions.Videos.VideoControl" %>
<%@ Import Namespace="SweetVids.Web.Actions.Videos" %>
    <div class="mod prefix_3 grid_10 suffix_3">
        <div class="inner">
            <div class="hd">
                <a href="<%= Urls.UrlFor(new GetVideoRequest{ Id = Model.Id}) %>">
                    <h2 class="lobster color1">
                        <%= Model.Title %></h2>
                </a>
            </div>
            <div class="bd">
                <object width="660" height="525">
                    <param name="movie" value="<%=Model.GetYouTubeUrl() %>"></param>
                    <param name="allowFullScreen" value="true"></param>
                    <param name="allowscriptaccess" value="always"></param>
                    <embed src="<%=Model.GetYouTubeUrl() %>" type="application/x-shockwave-flash" allowscriptaccess="always"
                        allowfullscreen="true" width="660" height="525"></embed></object>
            </div>
            <div class="ft">
                <p class="description">
                    <%=Model.Description %></p>
                <div class="comment-line">
                    Added on:
                    <%= Model.Created.ToLongDateString() %>
                    | (<%=Model.VideoComments.Count()%>) Comments so far | <a href="<%= Urls.UrlFor(new GetVideoRequest{ Id = Model.Id}) %>">
                        add a comment</a>
                </div>
            </div>
         </div>
    </div>