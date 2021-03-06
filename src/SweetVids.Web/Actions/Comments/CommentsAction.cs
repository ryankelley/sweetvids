using System;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using SweetVids.Core.Domain;
using SweetVids.Core.Persistence;
using SweetVids.Web.Actions.Videos;

namespace SweetVids.Web.Actions.Comments
{
    public class CommentsAction
    {
        private readonly IRepository<VideoComment> _repository;

        public CommentsAction(IRepository<VideoComment> repository)
        {
            _repository = repository;
        }

        [UrlForNew(typeof(VideoComment))]
        public FubuContinuation Post(AddCommentRequest request)
        {
            request.Comment.Video = new Video(){Id = request.VideoId};
            _repository.Save(request.Comment);


            return FubuContinuation.RedirectTo(new GetVideoRequest{Id = request.VideoId});}
        }
    }

    public class AddCommentRequest
    {
        public Guid VideoId { get; set; }
        public VideoComment Comment
        {
            get; set;
        }
}