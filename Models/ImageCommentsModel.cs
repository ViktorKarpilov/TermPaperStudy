using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TermPaper.Models;

namespace TermPaper.Models
{
    public class ImageCommentsModel
    {
        
        public ICollection<CommentModel> Comments{get;set;} = new List<CommentModel>();


    }
}