using System.Collections.Generic;

namespace TermPaper.Models
{
    public class PhotoModel
    {
        public ICollection<string> Urls{get;set;} = new List<string>();
        public ImageCommentsModel CommentsModel { get; set; }
    }
}